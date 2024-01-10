using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Puerts;
using UnityEditor;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace TSF.Oolong
{
    public class OolongEnvironment : ILoader, IResolvableLoader
    {
        internal class OolongUpdate : OolongSubSystem
        {
            protected override void Invoke()
            {
                JsEnv?.Tick();
                OnPreUpdate?.Invoke();
                OnUpdate?.Invoke();
            }
        }

        internal class OolongFixedUpdate : OolongSubSystem
        {
            protected override void Invoke()
            {
                OnFixedUpdate?.Invoke();
            }
        }

        internal class OolongLateUpdate : OolongSubSystem
        {
            protected override void Invoke()
            {
                OnLateUpdate?.Invoke();
            }
        }

        private static OolongEnvironment s_instance;

        public delegate void JsUpdate();
        public static event JsUpdate OnPreUpdate;
        public static event JsUpdate OnUpdate;
        public static event JsUpdate OnFixedUpdate;
        public static event JsUpdate OnLateUpdate;

        internal delegate void JsAttach(ScriptBehaviour instanceId, JSObject scriptClass, string jsonData);
        private JsAttach _scriptAttach;
        internal delegate void JsDetach(int instanceId);
        private JsDetach _scriptDetach;

        private JsEnv _environment;
        private ILoader _defaultLoader;

#if UNITY_EDITOR
        private Task _waitDebuggerTask;
        private HotReload _hotReload;
        public static HotReload HotReload => s_instance?._hotReload;
#endif

        public static JsEnv JsEnv => s_instance?._environment;
        public static OolongEnvironment Instance => s_instance;
        public static Action OnInitialize;
        public static Action OnDispose;

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        public static void Initialize()
        {
            s_instance ??= new OolongEnvironment();
            s_instance.InitializeJsEnv();
#if UNITY_EDITOR
            Application.quitting -= DisposeInstance;
#endif
            Application.quitting += DisposeInstance;

            OnInitialize?.Invoke();
            OnInitialize = null;
        }

        public static void DisposeInstance()
        {
            if (s_instance != null)
            {
                s_instance.Dispose();
                s_instance = null;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Attach(ScriptBehaviour behaviour, JSObject scriptClass, string jsonData)
        {
            _scriptAttach(behaviour, scriptClass, jsonData);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Detach(ScriptBehaviour behaviour)
        {
            _scriptDetach(behaviour.GetInstanceID());
        }

        private OolongEnvironment()
        {
            _defaultLoader = new DefaultLoader();
        }

        internal void InitializeJsEnv()
        {
#if UNITY_EDITOR
            _hotReload = new HotReload();
            var debuggerPort = DebuggerSettings.instance.Port;
            _environment = new JsEnv(this, debuggerPort);
            _waitDebuggerTask = _environment.WaitDebuggerAsync();
            if (DebuggerSettings.instance.WaitForDebugger)
            {
                var showingProgressBar = false;
                while (_waitDebuggerTask != null && !_waitDebuggerTask.IsCompleted)
                {
                    showingProgressBar = true;
                    if (EditorUtility.DisplayCancelableProgressBar("[Oolong] Waiting for debugger", $"Waiting for debugger to attach to port {DebuggerSettings.instance.Port} ...", -1))
                        break;
                    _environment.Tick();
                }
                if (showingProgressBar)
                    EditorUtility.ClearProgressBar();
            }
            _hotReload.Connect(debuggerPort);
#else
            _environment = new JsEnv(this);
#endif
            InjectWrapper();

            _environment.ExecuteModule("oolong");
#if UNITY_EDITOR
            _environment.ExecuteModule("oolong/source-map");
#endif
            _environment.UsingAction<ScriptBehaviour, string, string>();
            _environment.UsingAction<int, JSObject>();
            _environment.UsingAction<int>();

            _scriptAttach = _environment.Eval<JsAttach>("Oolong.attach.bind(Oolong)");
            _scriptDetach = _environment.Eval<JsDetach>("Oolong.detach.bind(Oolong)");
            OnUpdate += _environment.Eval<JsUpdate>("Oolong.update.bind(Oolong)");
            OnFixedUpdate += _environment.Eval<JsUpdate>("Oolong.fixedUpdate.bind(Oolong)");
            OnLateUpdate += _environment.Eval<JsUpdate>("Oolong.lateUpdate.bind(Oolong)");
        }

        private void InjectWrapper()
        {
            var registerClass = Type.GetType("PuertsStaticWrap.RegisterOolong, TSF.Oolong.Generated");
            if (registerClass == null) return;
            var registerMethod = registerClass.GetMethod("AddRegisterInfoGetterIntoJsEnv", System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.Public);
            if (registerMethod == null) return;
            registerMethod.Invoke(null, new object[] { _environment });
        }

        public bool FileExists(string filePath)
        {
            if (!filePath.StartsWith("_oolong_"))
            {
                return _defaultLoader.FileExists(filePath);
            }
            var op = Addressables.LoadResourceLocationsAsync(filePath);
            op.WaitForCompletion();
            var success = op.Status == AsyncOperationStatus.Succeeded && op.Result != null && op.Result.Count > 0;
            Addressables.Release(op);
            return success;
        }

        public string ReadFile(string filePath, out string debugPath)
        {
            if (filePath.StartsWith("__o"))
            {
                debugPath = null;
                return $"import '_oolong_{filePath.Substring(3)}';";
            }

            if (!filePath.StartsWith("_oolong_"))
            {
                return _defaultLoader.ReadFile(filePath, out debugPath);
            }

            debugPath = filePath;
            var op = Addressables.LoadAssetAsync<TextAsset>(filePath);
            op.WaitForCompletion();
            if (op.Status == AsyncOperationStatus.Succeeded)
            {
#if UNITY_EDITOR
                var assetPath = filePath.Replace("_oolong_/", "");
#if UNITY_EDITOR_WIN
                assetPath = assetPath.Replace('/', '\\');
#endif
                debugPath = Path.Combine(GetCachePath(), "Assets", assetPath) + ".js";
#endif
                var result = op.Result.text;
                Addressables.Release(op);
                return result;
            }
            Addressables.Release(op);
            return null;
        }

        public string Resolve(string specifier, string referrer)
        {
            if (!PathHelper.IsRelative(specifier)) return FileExists(specifier) ? specifier : null;
            if (string.IsNullOrEmpty(referrer) || !referrer.StartsWith("_oolong_")) return FileExists(specifier) ? specifier : null;

            specifier = PathHelper.normalize(PathHelper.Dirname(referrer) + "/" + specifier);
            return FileExists(specifier) ? specifier : null;
        }

#if UNITY_EDITOR
        public static string GetCachePath()
        {
            return Path.Combine(Directory.GetCurrentDirectory(), "Library", "OolongCache");
        }
#endif

        private void Dispose()
        {
#if UNITY_EDITOR
            _waitDebuggerTask = null;
            _hotReload?.Dispose();
            _hotReload = null;
#endif
            OnDispose?.Invoke();
            _environment.Eval("Oolong.dispose();");
            _environment.Dispose();
            _environment = null;
            OnUpdate = null;
            OnFixedUpdate = null;
            OnLateUpdate = null;
            _scriptAttach = null;
            _scriptDetach = null;
            Resources.UnloadUnusedAssets();
            GC.Collect();
        }
    }

}
