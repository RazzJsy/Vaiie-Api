using Rules.Enums;

namespace Rules.Interfaces
{
    public interface IResult
    {
        public ParseCheckResultType Result { get; }
        public int RuleId { get; set; }
        public string Title { get; set; }
        //public string Rationale { get; set; }
        //public bool InScope { get; set; }
        //public string InScopeReason { get; set; }
        //public string Risk { get; }
        //public string ElementType { get; set; }
        //public string ElementData { get; set; }
        //public string ElementKey { get; set; }
    }
}
