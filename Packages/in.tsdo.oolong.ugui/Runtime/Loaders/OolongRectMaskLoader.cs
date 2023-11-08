using UnityEngine;
using UnityEngine.UI;
namespace TSF.Oolong.UGUI
{
    public class OolongRectMaskLoader : OolongLoader<OolongRectMaskLoader>
    {
        public RectMask2D Instance;

        public OolongRectMaskLoader(GameObject gameObject, bool withNullGraphic = false)
        {
            // TODO: add more attributes for RectMask2D
            Instance = gameObject.AddComponent<RectMask2D>();

            if (withNullGraphic)
            {
                gameObject.AddComponent<NonDrawingGraphic>();
            }
        }
    }
}
