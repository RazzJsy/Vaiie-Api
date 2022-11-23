namespace Rules.Validation
{
    using Data.Models;
    using global::Rules.Enums;
    using global::Rules.Models;

    public class ValidateDirector
    {
        public static ParseCheckExecutionResult CheckDirectorIsBlacklisted(Director director)
        {
            if (director.IsBlacklisted)
            {
                return new ParseCheckExecutionResult(ParseCheckResultType.fail, "Director", "true", "Director is blacklisted", director.ParentId, director.Person.Name);
            }

            return new ParseCheckExecutionResult(ParseCheckResultType.pass, "Director", director.Person.Name);
        }
    }
}