public class IdentityTransformer : ITextTransformer, IAddressTransformer
{
    public string Transform(string text) => text;
    public string Transform(string tag, string address) => address;
}
