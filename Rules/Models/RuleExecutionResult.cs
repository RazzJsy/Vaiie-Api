namespace Rules.Models
{
    using global::Rules.Interfaces;

    public class RuleExecutionResult : IResult
    {
        public string Result { get; }
        public int RuleId { get; set; }
        public string Title { get; set; }
        public string Rationale { get; set; }
    }
}
