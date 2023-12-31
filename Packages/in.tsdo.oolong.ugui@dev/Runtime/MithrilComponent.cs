using Puerts;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace TSF.Oolong.UGUI
{
    [RequireComponent(typeof(RectTransform))]
    [AddComponentMenu("MithrilComponent", order: -999999)]
    public sealed class MithrilComponent : OolongElement
    {
        public AssetReferenceT<TextAsset> AddressableScript;
        [SerializeField]
        private bool _partialRedraw;

        public bool HasScript => AddressableScript != null;
        public bool PartialRedraw => _partialRedraw;

        private bool _initialized = false;
        private JSObject _componentClass = null;
        private JSObject _element = null;
        private bool _unmountPending = false;

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
            _componentClass = OolongEnvironment.JsEnv.ExecuteModule<JSObject>(scriptAddress, "default");
            _initialized = true;
        }

        private void Awake()
        {
            Init(AddressableScript);
        }

        private void OnEnable()
        {
            if (!_initialized) return;
            if (_unmountPending)
            {
                OolongEnvironment.OnLateUpdate -= Unmount;
                _unmountPending = false;
            }
            _element = OolongUGUI.Mount(this, _componentClass, _partialRedraw);
        }

        private void OnDisable()
        {
            if (!_initialized || _element == null) return;
            if (_unmountPending) return;
            OolongEnvironment.OnLateUpdate += Unmount;
            _unmountPending = true;
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            if (!_initialized || _element == null) return;

            _unmountPending = false;
            OolongEnvironment.OnLateUpdate -= Unmount;
            OolongUGUI.Unmount(_element);
            _element = null;
        }

        private void Unmount()
        {
            _unmountPending = false;
            OolongEnvironment.OnLateUpdate -= Unmount;
            OolongUGUI.Unmount(_element);
            _element = null;
        }
    }
}
