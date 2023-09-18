using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using Object = UnityEngine.Object;

namespace TSF.Oolong.UI
{
    public struct AddressableHolder<T> where T : Object
    {
        public T Asset;

        private bool _isLoaded;
        private AsyncOperationHandle<T> _op;

        public async Task<T> Load(string address)
        {
            Release();
            _isLoaded = true;
            try
            {
                _op = Addressables.LoadAssetAsync<T>(address);
                await _op.Task;
                if (!_isLoaded || _op.Status != AsyncOperationStatus.Succeeded)
                    return null;

                Asset = _op.Result;
                if (Asset == null) Release();
                return Asset;
            }
            catch (Exception e)
            {
                Debug.LogWarning("资源加载失败：" + address);
                Debug.LogError(e.Message);
                return null;
            }
        }

        public T LoadSync(string address)
        {
            Release();
            _isLoaded = true;
            try
            {
                _op = Addressables.LoadAssetAsync<T>(address);
                if (!_op.IsDone)
                    _op.WaitForCompletion();
                if (!_isLoaded || _op.Status != AsyncOperationStatus.Succeeded)
                    return null;

                Asset = _op.Result;
                if (Asset == null) Release();
                return Asset;
            }
            catch (Exception e)
            {
                Debug.LogWarning("资源加载失败：" + address);
                Debug.LogError(e.Message);
                return null;
            }
        }

        public void Release()
        {
            if (!_isLoaded)
                return;

            Addressables.Release(_op);
            Asset = null;
            _op = default;
            _isLoaded = false;
        }
    }
}
