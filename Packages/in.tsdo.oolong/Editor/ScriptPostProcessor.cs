using System.IO;
using System.Text.RegularExpressions;
using UnityEditor;
using UnityEditor.AddressableAssets;
using UnityEditor.AddressableAssets.Settings.GroupSchemas;
using UnityEngine;

namespace TSF.Oolong.Editor
{
    public class ScriptPostProcessor : AssetPostprocessor
    {
        protected static void OnPostprocessAllAssets(string[] importedAssets, string[] deletedAssets, string[] movedAssets, string[] movedFromAssetPaths)
        {
            foreach (var asset in importedAssets)
            {
                if (
                    (asset.EndsWith(".js") || asset.EndsWith(".ts") || asset.EndsWith(".tsx")) &&
                    !asset.Contains("Resources") &&
                    !asset.EndsWith(".d.ts")
                    )
                {
                    UpdateAddressable(asset);
                }
            }
        }

        private static void UpdateAddressable(string asset)
        {
            var importer = AssetImporter.GetAtPath(asset);

            if (importer is JavaScriptImporter tsImporter)
            {
                if (tsImporter.ExcludeInAddressable)
                    UnmarkAddressable(asset);
                else
                    MarkAddressable(asset);
            }
        }

        private static void MarkAddressable(string asset)
        {
            var settings = AddressableAssetSettingsDefaultObject.Settings;
            var group = settings.FindGroup("OolongScripts");
            if (group == null)
            {
                group = settings.CreateGroup("OolongScripts", false, true, false, null, typeof(ContentUpdateGroupSchema), typeof(BundledAssetGroupSchema));
                var schema = group.GetSchema<BundledAssetGroupSchema>();
                if (schema)
                {
                    schema.InternalIdNamingMode = BundledAssetGroupSchema.AssetNamingMode.GUID;
                    EditorUtility.SetDirty(schema);
                }
            }

            {
                // validate schema
                var schema = group.GetSchema<BundledAssetGroupSchema>();
                if (schema.InternalIdNamingMode != BundledAssetGroupSchema.AssetNamingMode.GUID)
                {
                    Debug.LogWarning("Oolong scripts group schema requires GUID internal naming mode. The changed schema setting has been automatically reverted.");
                    schema.InternalIdNamingMode = BundledAssetGroupSchema.AssetNamingMode.GUID;
                    EditorUtility.SetDirty(schema);
                }
            }

            var guid = AssetDatabase.AssetPathToGUID(asset);
            var entry = settings.CreateOrMoveEntry(guid, group, readOnly: true, postEvent: false);

            var regex = new Regex(@"^[Aa]ssets[/\\]");
            var assetPath = regex.Replace(asset, "");
            var address = "_oolong_/" + Path.Combine(Path.GetDirectoryName(assetPath) ?? string.Empty, Path.GetFileNameWithoutExtension(assetPath)).Replace('\\', '/');
            entry.SetAddress(address);
            entry.SetLabel("OolongScripts", true, true, false);
        }

        private static void UnmarkAddressable(string asset)
        {
            var settings = AddressableAssetSettingsDefaultObject.Settings;
            var group = settings.FindGroup("OolongScripts");
            if (group == null)
                return;

            var guid = AssetDatabase.AssetPathToGUID(asset);
            settings.RemoveAssetEntry(guid, postEvent: false);
        }
    }
}
