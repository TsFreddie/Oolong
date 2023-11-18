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
                Debug.Log("Failed to load script");
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
