using System;
using System.Collections.Generic;
using UnityEngine;

namespace TSF.Oolong.UGUI
{
    public class OolongChainLoader : IOolongLoader
    {
        public struct Node
        {
            public string Prefix;
            public IOolongLoader Loader;
        }

        private readonly List<Node> _chain = new List<Node>();

        public bool AddListener(string key, IOolongLoader.JsCallback callback)
        {
            foreach (var node in _chain)
            {
                if (node.Loader.AddListener(key, callback))
                    return true;
            }
            return false;
        }

        public bool RemoveListener(string key)
        {
            foreach (var node in _chain)
            {
                if (node.Loader.RemoveListener(key))
                    return true;
            }
            return false;
        }

        public void Release()
        {
            foreach (var node in _chain)
            {
                node.Loader.Release();
            }
        }

        public void Reuse()
        {
            foreach (var node in _chain)
            {
                node.Loader.Reuse();
            }
        }

        public void Reset()
        {
            foreach (var node in _chain)
            {
                node.Loader.Reset();
            }
        }

        public bool SetAttribute(string key, string value)
        {
            foreach (var node in _chain)
            {
                if (node.Prefix == null)
                {
                    if (node.Loader.SetAttribute(key, value))
                        return true;
                }
                else if (key.StartsWith(node.Prefix))
                {
                    if (node.Loader.SetAttribute(key.Substring(node.Prefix.Length), value))
                        return true;
                }
            }
            return false;
        }

        public bool TryGetAttribute(string key, out string value)
        {
            foreach (var node in _chain)
            {
                if (node.Prefix == null)
                {
                    if (node.Loader.TryGetAttribute(key, out value))
                        return true;
                }
                else if (key.StartsWith(node.Prefix))
                {
                    if (node.Loader.TryGetAttribute(key.Substring(node.Prefix.Length), out value))
                        return true;
                }
            }
            value = null;
            return false;
        }

        public void ResetTransitions()
        {
            foreach (var node in _chain)
            {
                node.Loader.ResetTransitions();
            }
        }

        public void SetTransition(string key, float duration, CubicBezier timingFunction, float delay)
        {
            foreach (var node in _chain)
            {
                if (node.Prefix == null)
                {
                    node.Loader.SetTransition(key, duration, timingFunction, delay);
                }
                else if (key.StartsWith(node.Prefix))
                {
                    node.Loader.SetTransition(key.Substring(node.Prefix.Length), duration, timingFunction, delay);
                }
            }
        }

        public OolongChainLoader Add<T>(string prefix, T loader) where T : IOolongLoader
        {
            var node = new Node() { Prefix = prefix, Loader = loader };
            _chain.Add(node);
            return this;
        }

        public OolongChainLoader Add<T>(T loader) where T : IOolongLoader
        {
            return Add(null, loader);
        }

        public OolongChainLoader Add<T>(string prefix, T loader, out T instance) where T : IOolongLoader
        {
            instance = loader;
            return Add(prefix, loader);
        }

        public OolongChainLoader Add<T>(T loader, out T instance) where T : IOolongLoader
        {
            return Add(null, loader, out instance);
        }

        public OolongChainLoader Do(Action action)
        {
            action();
            return this;
        }

        public OolongChainLoader CreateChildRect(Transform transform, string name, out RectTransform childRect)
        {
            childRect = DocumentUtils.CreateChildRect(transform, name);
            return this;
        }

        public OolongChainLoader SetRoot(OolongElement e, Transform transform)
        {
            e.RootTransform = transform;
            return this;
        }
    }
}
