using UnityEngine;
using UnityEngine.UI;
namespace TSF.Oolong.UGUI
{
    public class OolongButtonLoader : OolongLoader<OolongButtonLoader>
    {
        public readonly Button Instance;

        public OolongButtonLoader(GameObject gameObject)
        {
            Instance = gameObject.AddComponent<Button>();
        }

        public override bool AddListener(string key, IOolongLoader.JsCallback callback)
        {
            if (base.AddListener(key, callback)) return true;

            switch (key)
            {
                case "click":
                    Instance.onClick.AddListener(() => callback(null));
                    return true;
            }
            return false;
        }

        public override bool RemoveListener(string key)
        {
            if (base.RemoveListener(key)) return true;

            switch (key)
            {
                case "click":
                    Instance.onClick.RemoveAllListeners();
                    return true;
            }
            return false;
        }
    }
}
