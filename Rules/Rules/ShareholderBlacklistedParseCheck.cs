namespace Rules.Rules
{
    using Data.Models;
    using global::Rules.Enums;
    using global::Rules.Extensions;
    using global::Rules.Interfaces;
    using global::Rules.Models;
    using global::Rules.Validation;

    public class ShareholderBlacklistedParseCheck : AbstractRule
    {
        public override int RuleId => 2;

        public override string Title => "Shareholder blacklisted";

        public override string Rationale => "Shareholder is blacklisted";

        public override RuleRefs RuleRef => RuleRefs.ShareholderBlacklisted;

        public override void Execute(ReportingModel model)
        {
            List<Shareholder> shareholders = model.FindMatchingFields("Shareholder").AsEnumerable().Cast<Shareholder>().ToList();
            List<ParseCheckExecutionResult> shareholdersBlacklistedList = shareholders.Select(shareholder => ParseAndCheckShareholderBlacklisted(shareholder)).ToList();

            if (shareholdersBlacklistedList.Count == 0)
            {
                shareholdersBlacklistedList.Add(new ParseCheckExecutionResult(ParseCheckResultType.NA, "Shareholder"));
            }

            var isBlackListedList = shareholdersBlacklistedList.Where(a => a.Result == ParseCheckResultType.Fail.ToString()).ToList();

            _results = new KeyValuePair<string, List<IResult>>("ShareholderBlacklisted", shareholdersBlacklistedList.AddAdditionalData(RuleId, Title, Rationale).Cast<IResult>().ToList());
        }

        public static ParseCheckExecutionResult ParseAndCheckShareholderBlacklisted(Shareholder shareholder)
        {
            return ValidateShareholder.CheckShareholderIsBlacklisted(shareholder);
        }

        public override bool IsThisRuleInScope(ReportingModel model)
        {
            return true;
        }
    }
}
