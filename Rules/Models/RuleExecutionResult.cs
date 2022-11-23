namespace Rules.Models
{
    using global::Rules.Enums;
    using global::Rules.Interfaces;
    using System;

    public class RuleExecutionResult : IResult
    {
        public ParseCheckResultType Result { get; }
        public int RuleId { get; set; }
        public string Title { get; set; }
        public string Rationale { get; set; }
        //public bool InScope { get; set; }
        //public string InScopeReason { get; set; }
        //public string Risk { get; }
        //public string ElementType { get; set; }
        //public string ElementData { get; set; }
        //public string ElementKey { get; set; }
        //public int Count { get; }
        //public Type RuleOrCheckType { get; set; }
    }
}
