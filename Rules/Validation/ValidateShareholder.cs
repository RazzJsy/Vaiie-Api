namespace Rules.Validation
{
    using Data.Models;
    using global::Rules.Enums;
    using global::Rules.Models;

    public class ValidateShareholder
    {
        public static ParseCheckExecutionResult CheckShareholderIsBlacklisted(Shareholder shareholder)
        {
            if (shareholder.IsBlacklisted)
            {
                return new ParseCheckExecutionResult(ParseCheckResultType.Fail, "IsBlacklisted", "true", "Shareholder is blacklisted", shareholder.ParentId, shareholder.Name);
            }

            return new ParseCheckExecutionResult(ParseCheckResultType.Pass, "Shareholder", shareholder.Name);
        }
    }
}