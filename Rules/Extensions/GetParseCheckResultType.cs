namespace Rules.Extensions
{
    using global::Rules.Enums;

    public static class GetParseCheckResultType
    {
        public static ParseCheckResultType DetermineParseCheckResultType<T>(this T input)
        {
            if (typeof(T) == typeof(bool))
            {
                return bool.Parse(input.ToString()) ? ParseCheckResultType.Pass : ParseCheckResultType.Fail;
            }
            else
            {
                return ParseCheckResultType.Count;
            }
        }
    }
}
