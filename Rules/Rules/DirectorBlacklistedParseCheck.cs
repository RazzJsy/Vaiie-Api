namespace Rules.Rules
{
    using Data.Models;
    using global::Rules.Enums;
    using global::Rules.Extensions;
    using global::Rules.Interfaces;
    using global::Rules.Models;
    using global::Rules.Validation;

    public class DirectorBlacklistedParseCheck : AbstractRule
    {
        public override int RuleId => 1;

        public override string Title => "Director blacklisted";

        public override string Rationale => "Director is blacklisted";

        public override RuleRefs RuleRef => RuleRefs.DirectorBlacklisted;

        public override void Execute(ReportingModel model)
        {
            List<Director> directors = model.FindMatchingFields("Director").AsEnumerable().Cast<Director>().ToList();
            List<ParseCheckExecutionResult> directorBlacklistedList = directors.Select(director => ParseAndCheckDirector(director)).ToList();

            if (directorBlacklistedList.Count == 0)
            {
                directorBlacklistedList.Add(new ParseCheckExecutionResult(ParseCheckResultType.NA, "Director"));
            }

            var isBlackListedList = directorBlacklistedList.Where(a => a.Result == ParseCheckResultType.Fail.ToString()).ToList();

            _results = new KeyValuePair<string, List<IResult>>("DirectorBlacklisted", directorBlacklistedList.AddAdditionalData(RuleId, Title, Rationale).Cast<IResult>().ToList());
        }

        public static ParseCheckExecutionResult ParseAndCheckDirector(Director director)
        {
            return ValidateDirector.CheckDirectorIsBlacklisted(director);
        }

        public override bool IsThisRuleInScope(ReportingModel model)
        {
            return true;
        }
    }
}
