using TMPro;
using UnityEngine;

namespace TSF.Oolong.UGUI
{
    public static class OolongTextMeshPro
    {
        public static void GetFont(string fontName, string materialName, out TMP_FontAsset font, out Material material)
        {
            var fontHashCode = fontName == null ? 0 : TMP_TextUtilities.GetSimpleHashCode(fontName);
            var materialHashCode = materialName == null ? 0 : TMP_TextUtilities.GetSimpleHashCode(materialName);

            // Special handling for <font=default> or <font=Default>
            if (fontHashCode == 764638571 || fontHashCode == 523367755 || fontHashCode == 0)
            {
                font = TMP_Settings.defaultFontAsset;
            }
            else
            {
                MaterialReferenceManager.TryGetFontAsset(fontHashCode, out font);
                if (!font)
                {
                    font = Resources.Load<TMP_FontAsset>(TMP_Settings.defaultFontAssetPath + fontName);

                    if (font)
                        MaterialReferenceManager.AddFontAsset(font);
                }
            }

            if (!font)
            {
                font = TMP_Settings.defaultFontAsset;
            }

            if (materialHashCode == 0)
            {
                material = font ? font.material : null;
                return;
            }

            if (MaterialReferenceManager.TryGetMaterial(materialHashCode, out material))
                return;

            material = Resources.Load<Material>(TMP_Settings.defaultFontAssetPath + materialName);

            if (!material)
            {
                material = font ? font.material : null;
                return;
            }

            MaterialReferenceManager.AddFontMaterial(materialHashCode, material);
        }
    }
}