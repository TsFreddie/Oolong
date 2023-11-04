using System.Collections;
using System.Collections.Generic;
using Puerts;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace TSF.Oolong.UGUI
{
    [RequireComponent(typeof(RectTransform))]
    [AddComponentMenu("MithrilComponent", order: -999999)]
    public sealed class MithrilComponent : OolongElement<MithrilComponent>
    {
        public AssetReferenceT<TextAsset> AddressableScript;
        public bool HasScript => AddressableScript != null;

        private bool _initialized = false;
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
                Debug.Log("找不到脚本");
                return;
            }

            var address = op.Result[0].PrimaryKey;
            Init(address);
        }

        internal void Init(string scriptAddress)
        {
            if (_initialized) return;
            var componentClass = OolongEnvironment.JsEnv.ExecuteModule<JSObject>(scriptAddress, "default");
            _element = OolongUGUI.Mount(this, componentClass);
            _initialized = true;
        }

        private void Awake()
        {
            Init(AddressableScript);
        }

        protected override void OnDestroy()
        {
            OolongUGUI.Unmount(_element);
            _element = null;
        }
    }
}
