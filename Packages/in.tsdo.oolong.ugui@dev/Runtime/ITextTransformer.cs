#if UNITY_TMP || UNITY_UGUI_2

using TSF.Oolong.UGUI;

public interface ITextTransformer
{
    public string Transform(string text, OolongTextLoader loader);
}

#endif
