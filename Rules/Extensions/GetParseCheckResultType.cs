namespace Rules.Extensions
{
    using global::Rules.Enums;

    public static class GetParseCheckResultType
    {
        public static ParseCheckResultType DetermineParseCheckResultType<T>(this T input)
        {
            if (typeof(T) == typeof(bool))
            {
                return bool.Parse(input.ToString()) ? ParseCheckResultType.pass : ParseCheckResultType.fail;
            }
            else
            {
                return ParseCheckResultType.count;
            }
        }
    }
}
