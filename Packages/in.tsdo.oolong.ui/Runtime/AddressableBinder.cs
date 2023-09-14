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
    public static class AddressableBinder
    {
        private static readonly Dictionary<Object, object> s_operationHandles = new Dictionary<Object, object>();

        public static void Release<T>(Object key)
        {
            if (!s_operationHandles.ContainsKey(key))
                return;

            var op = (AsyncOperationHandle<T>)s_operationHandles[key];
            Addressables.Release(op);
            s_operationHandles.Remove(key);
        }

        public static async Task<T> Load<T>(Object key, string address) where T : Object
        {
            if (s_operationHandles.ContainsKey(key))
            {
                Release<T>(key);
            }

            var op = Addressables.LoadAssetAsync<T>(address);
            s_operationHandles[key] = op;
            await op.Task;
            if (!s_operationHandles.ContainsKey(key)) return null;

            if (op.Status != AsyncOperationStatus.Succeeded)
            {
                Debug.LogWarning("资源加载失败：" + address);
                return null;
            }

            var result = op.Result;
            if (result == null) Release<T>(key);
            return result;
        }

        public static T LoadSync<T>(Object key, string address) where T : Object
        {
            if (s_operationHandles.ContainsKey(key))
            {
                Release<T>(key);
            }

            var op = Addressables.LoadAssetAsync<T>(address);
            s_operationHandles[key] = op;
            if (!op.IsDone)
                op.WaitForCompletion();
            if (!s_operationHandles.ContainsKey(key)) return null;

            if (op.Status != AsyncOperationStatus.Succeeded)
            {
                Debug.LogWarning("资源加载失败：" + address);
                return null;
            }

            var result = op.Result;
            if (result == null) Release<T>(key);
            return result;
        }
    }

    public class AddressableHolder<T> where T : Object
    {
        public string Address;
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
            Address = null;
            _op = default;
            _isLoaded = false;
        }
    }
}
