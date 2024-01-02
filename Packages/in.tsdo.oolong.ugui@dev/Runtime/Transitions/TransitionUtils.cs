using System.Text.RegularExpressions;

namespace TSF.Oolong.UGUI
{
    public static class TransitionUtils
    {
        public static float ParseHumanTime(string humanTime)
        {
            humanTime = humanTime.Trim();
            var isS = humanTime.Length >= 1 && (humanTime[^1] == 's' || humanTime[^1] == 'S');
            if (!isS)
                return 0.0f;

            var isMS = humanTime.Length >= 2 && (humanTime[^2] == 'm' || humanTime[^2] == 'M');
            if (isMS)
            {
                if (float.TryParse(humanTime[..^2], out var value))
                {
                    return value / 1000.0f;
                }
            }
            else
            {
                if (float.TryParse(humanTime[..^1], out var value))
                {
                    return value;
                }
            }
            return 0.0f;
        }

        private static readonly Regex s_cubicBezier = new Regex(@"cubic-bezier\(([^,]*),([^,]*),([^,]*),([^,]*)\)");

        private static bool ParseCubicBezier(string value, out CubicBezier result)
        {
            value = value.Trim();
            result = CubicBezier.Ease;

            var func = s_cubicBezier.Match(value);
            if (!func.Success)
                return false;

            if (!float.TryParse(func.Groups[1].Value, out var p1X)) return false;
            if (!float.TryParse(func.Groups[2].Value, out var p1Y)) return false;
            if (!float.TryParse(func.Groups[3].Value, out var p2X)) return false;
            if (!float.TryParse(func.Groups[4].Value, out var p2Y)) return false;
            result = new CubicBezier(p1X, p1Y, p2X, p2Y);
            return true;
        }

        public static CubicBezier ParseTimingFunction(string value)
        {
            if (ParseCubicBezier(value, out var result)) return result;

            switch (value)
            {
                case "ease":
                    return CubicBezier.Ease;
                case "ease-in":
                    return CubicBezier.EaseIn;
                case "ease-out":
                    return CubicBezier.EaseOut;
                case "ease-in-out":
                    return CubicBezier.EaseInOut;
                case "linear":
                    return CubicBezier.Linear;
            }
            return CubicBezier.Ease;
        }
    }
}
