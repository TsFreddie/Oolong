using TSF.Oolong.UGUI;
public class IdentityTransformer : ITextTransformer, IAddressTransformer
{
    public string Transform(string text, OolongTextLoader _) => text;
    public string Transform(string tag, string address) => address;
}
