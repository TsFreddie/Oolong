namespace TSF.Oolong.UGUI
{
    public interface ITransitionProperty
    {
        public CubicBezier TimingFunction { get; set; }
        public float Delay { get; set; }
        public float Duration { get; set; }
        public void Reset();
    }
}
