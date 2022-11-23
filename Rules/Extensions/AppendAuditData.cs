namespace Rules.Extensions
{
    using global::Rules.Enums;
    using global::Rules.Models;
    using System.Collections.Generic;
    using System.Linq;

    public static class AppendAuditData
    {
        public static List<T> AddAdditionalData<T>(this List<T> list, int ruleId, string title, string rationale)
        {
            if (typeof(T) == typeof(RuleExecutionResult))
            {
                List<RuleExecutionResult> newList = list.Cast<RuleExecutionResult>().ToList();

                newList.ForEach(a => a.RuleId = ruleId);
                newList.ForEach(a => a.Title = title);
                newList.ForEach(a => a.Rationale = a.Result == ParseCheckResultType.Fail.ToString() ? rationale : string.Empty);

                return newList.Cast<T>().ToList();
            }
            else
            {
                List<ParseCheckExecutionResult> newList = list.Cast<ParseCheckExecutionResult>().ToList();

                newList.ForEach(a => a.RuleId = ruleId);
                newList.ForEach(a => a.Title = title);
                newList.ForEach(a => a.Rationale = a.Result == ParseCheckResultType.Fail.ToString() ? rationale : string.Empty);

                return newList.Cast<T>().ToList();
            }
        }
    }
}
