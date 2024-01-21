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
        private bool _unmountPending = false;
        private JSObject _componentClass = null;
        private JSObject _element = null;

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
                // Cancel unmount and keep the mounted element
                OolongEnvironment.OnLateUpdate -= Unmount;
                _unmountPending = false;
                return;
            }
            _element = OolongUGUI.Mount(this, _componentClass, _partialRedraw);
        }

        private void OnDisable()
        {
            // Delay unmount to avoid changing parents when GameObjects is deactivating
            if (!_unmountPending)
            {
                OolongEnvironment.OnLateUpdate += Unmount;
                _unmountPending = true;
            }
        }

        private void Unmount()
        {
            _unmountPending = false;
            OolongEnvironment.OnLateUpdate -= Unmount;

            if (!_initialized || _element == null) return;
            OolongUGUI.Unmount(_element);
            _element = null;
        }

        protected override void OnDestroy()
        {
            if (_unmountPending)
            {
                // Cancel pending unmount and unmount immediately
                OolongEnvironment.OnLateUpdate -= Unmount;
                _unmountPending = false;
                Unmount();
            }

            // Force reset children elements in case unmount
            // is delayed by mithril's onbeforeremove hook
            ResetChildren();
        }

        public void Redraw()
        {
            if (!_initialized || _element == null) return;
            OolongUGUI.Redraw(_element);
        }
    }
}
