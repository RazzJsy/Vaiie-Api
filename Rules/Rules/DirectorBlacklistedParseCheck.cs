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

        public override string Rationale => "Is Director blacklisted?";

        public override RuleRefs RuleRef => RuleRefs.DirectorBlacklisted;

        public override void Execute(ReportingModel model)
        {
            List<Director> directors = model.FindMatchingFields("Director").AsEnumerable().Cast<Director>().ToList();
            List<ParseCheckExecutionResult> directorBlacklistedList = directors.Select(director => ParseAndCheckAddress(director)).ToList();

            if (directorBlacklistedList.Count == 0)
            {
                directorBlacklistedList.Add(new ParseCheckExecutionResult(ParseCheckResultType.na, "Director"));
            }

            var isBlackListedList = directorBlacklistedList.Where(a => a.Result == ParseCheckResultType.fail).ToList();

            if (isBlackListedList.Any())
            {
                foreach(var item in isBlackListedList)
                {
                    if (model.organisationData.Id == item.ParentId)
                    {
                        //Do something
                        break;
                    }
                    else
                    {
                        foreach (var director in model.organisationData.Directors)
                        {
                            if (director.Id == item.ParentId)
                            {
                                //Do Somerthing
                                break;
                            }
                        }

                        foreach (var shareholder in model.organisationData.Shareholders)
                        {
                            if (shareholder.Id == item.ParentId)
                            {
                                //Do something
                                break;
                            }
                        }
                    }
                }
            }

            _results = new KeyValuePair<string, List<IResult>>("DirectorBlacklisted", directorBlacklistedList.AddAdditionalData(RuleId, Title, Rationale).Cast<IResult>().ToList());
        }

        public static ParseCheckExecutionResult ParseAndCheckAddress(Director director)
        {
            ValidateDirector validateDirector = new();
            return ValidateDirector.CheckDirectorIsBlacklisted(director);
        }

        public override bool IsThisRuleInScope(ReportingModel model)
        {
            return true;
        }
    }
}
