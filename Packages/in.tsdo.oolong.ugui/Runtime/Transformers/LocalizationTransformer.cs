#if UNITY_LOCALIZATION

using TSF.Oolong.UGUI;
using UnityEngine.Localization.Settings;
using UnityEngine.Localization.Tables;

public class LocalizationTransformer : ITextTransformer
{
    public TableReference DefaultTable = default;
    private static readonly object[] s_cachedArgs = new object[1];

    public string Transform(string text, OolongTextLoader loader)
    {
        if (string.IsNullOrEmpty(text)) return text;
        if (text[0] != '#') return text;
        if (!LocalizationSettings.HasSettings) return text;

        var entryIndex = 1;
        TableReference table;
        if (text[1] == '(')
        {
            var end = text.IndexOf(')', 2);
            if (end == -1) return text;
            table = text.Substring(2, end - 2);
            entryIndex = end + 1;
        }
        else if (DefaultTable.ReferenceType != TableReference.Type.Empty)
        {
            table = DefaultTable;
        }
        else
        {
            table = LocalizationSettings.StringDatabase.DefaultTable;
        }

        var entry = LocalizationSettings.StringDatabase.GetTableEntry(table, text[entryIndex..]);
        if (entry.Entry == null) return text;

        if (loader.TextAttr != null && loader.TextAttr.Count > 0)
        {
            s_cachedArgs[0] = loader.TextAttr;
            var result = entry.Entry.GetLocalizedString(s_cachedArgs);
            s_cachedArgs[0] = null;
            return result;
        }
        return entry.Entry.GetLocalizedString();

    }
}

#endif
