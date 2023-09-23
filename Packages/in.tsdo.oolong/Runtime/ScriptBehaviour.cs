using System;
using System.IO;
using Puerts;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

// ReSharper disable UnassignedField.Global
// ReSharper disable MemberCanBePrivate.Global

namespace TSF.Oolong
{
    [AddComponentMenu("ScriptBehaviour", -1000000)]
    public class ScriptBehaviour : MonoBehaviour
    {
        public AssetReferenceT<TextAsset> AddressableScript;
        public bool HasScript => AddressableScript != null;

        public Action JsAwake;
        public Action JsStart;
        public Action JsOnEnable;
        public Action JsOnDisable;
        public Action JsOnDestroy;
        public Action<string> JsCall;

        private bool _initialized = false;
        private Guid _guid;

        internal void Init()
        {
            if (!HasScript) return;
            Init(AddressableScript);
        }

        public void SetHooks(Action awake, Action start, Action onEnable, Action onDisable, Action onDestroy)
        {
            JsAwake = awake;
            JsStart = start;
            JsOnEnable = onEnable;
            JsOnDisable = onDisable;
            JsOnDestroy = onDestroy;
        }

        internal void Init(AssetReferenceT<TextAsset> addressableScript)
        {
            if (_initialized) return;

            var op = Addressables.LoadResourceLocationsAsync(AddressableScript);
            op.WaitForCompletion();

            if (op.Status != AsyncOperationStatus.Succeeded ||
                op.Result == null ||
                op.Result.Count <= 0)
            {
                Debug.Log("找不到脚本");
                return;
            }

            var address = op.Result[0].PrimaryKey;
            Init(address);
        }

        internal void Init(string scriptAddress)
        {
            if (_initialized) return;
            var scriptClass = OolongEnvironment.JsEnv.ExecuteModule<JSObject>(scriptAddress, "default");
            OolongEnvironment.Instance.Attach(this, scriptClass, null);
            _initialized = true;
        }

        protected void Awake()
        {
            Init();
            JsAwake?.Invoke();
        }

        public void Call(string func)
        {
            JsCall?.Invoke(func);
        }

        protected void OnEnable()
        {
            JsOnEnable?.Invoke();
        }

        protected void OnDisable()
        {
            JsOnDisable?.Invoke();
        }

        protected void Start()
        {
            JsStart?.Invoke();
        }

        protected void OnDestroy()
        {
            JsOnDestroy?.Invoke();
            ClearHooks();
            OolongEnvironment.Instance?.Detach(this);
        }

        public void ClearHooks()
        {
            JsAwake = null;
            JsStart = null;
            JsOnEnable = null;
            JsOnDisable = null;
            JsOnDestroy = null;
        }

#if UNITY_EDITOR
        public TextAsset EditorAsset
        {
            get => (AddressableScript != null && AddressableScript.editorAsset != null) ? AddressableScript.editorAsset : null;
        }

        // Extract editor field and default value by creating a script instance
        public class SingleScriptLoader : ILoader
        {
            private readonly ScriptBehaviour _parent;
            private readonly ILoader _defaultLoader;

            public SingleScriptLoader(ScriptBehaviour parent)
            {
                _defaultLoader = new DefaultLoader();
                _parent = parent;
            }

            public bool FileExists(string filePath)
            {
                if (_parent.EditorAsset == null) return _defaultLoader.FileExists(filePath);

                var scriptName = _parent.EditorAsset.name;
                var result = filePath.Equals(scriptName) || _defaultLoader.FileExists(filePath);
                if (result) return true;
                if (filePath.EndsWith(".js")) return true;
                return false;
            }

            public string ReadFile(string filePath, out string debugPath)
            {
                if (_parent.EditorAsset == null) return _defaultLoader.ReadFile(filePath, out debugPath);

                var scriptName = _parent.EditorAsset.name;
                if (Path.GetFileNameWithoutExtension(filePath).Equals(scriptName))
                {
                    debugPath = filePath;
                    return _parent.EditorAsset.text;
                }

                var result = _defaultLoader.ReadFile(filePath, out debugPath);
                if (result != null) return result;
                var className = Path.GetFileNameWithoutExtension(filePath);
                var fakeSource = $@"export default class {className} extends ScriptBehaviour{{}}";
                return fakeSource;
            }
        }

        [NonSerialized]
        private string _keptAddressable;

        public void KeepAsset()
        {
            _keptAddressable = AddressableScript.AssetGUID;
        }

        protected void OnValidate()
        {
            KeepAsset();
        }

        protected void Reset()
        {
            AddressableScript = new AssetReferenceT<TextAsset>(_keptAddressable);
        }

        public int GetScriptInstanceID() => GetInstanceID();
        public int GetGameObjectInstanceID() => gameObject.GetInstanceID();
#endif
    }
}
