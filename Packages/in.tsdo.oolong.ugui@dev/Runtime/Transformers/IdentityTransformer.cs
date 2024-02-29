using TSF.Oolong.UGUI;

public partial class IdentityTransformer : IAddressTransformer
{
    public string Transform(string tag, string address) => address;
}

#if UNITY_TMP || UNITY_UGUI_2
public partial class IdentityTransformer : ITextTransformer
{
    public string Transform(string text, OolongTextLoader _) => text;
}
#endif
