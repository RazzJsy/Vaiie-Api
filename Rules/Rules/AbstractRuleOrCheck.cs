namespace Rules.Rules
{
    using global::Rules.Enums;
    using global::Rules.Interfaces;
    using System.Collections.Generic;

    public abstract class AbstractRuleOrCheck
    {
        protected KeyValuePair<string, List<IResult>> _results = new();

        public abstract int RuleId { get; }
        public abstract string Title { get; }
        public abstract string Rationale { get; }
        public abstract RuleRefs RuleRef { get; }

        public KeyValuePair<string, List<IResult>> Results()
        {
            return _results;
        }

        public bool ContainsResults()
        {
            return _results.Value.Count > 0;
        }
    }
}
