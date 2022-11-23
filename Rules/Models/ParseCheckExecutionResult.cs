namespace Rules.Models
{
    using global::Rules.Enums;
    using global::Rules.Interfaces;

    public class ParseCheckExecutionResult : IResult
    {
        public ParseCheckResultType Result { get; }
        public int RuleId { get; set; }
        public string Title { get; set; }
        public string Rationale { get; set; }
        public string Name { get; set; }
        public Guid ParentId { get; set; }
        public string Risk { get; }
        public string ElementType { get; set; }
        public string ElementData { get; set; }

        public ParseCheckExecutionResult(ParseCheckResultType result, string elementType, string name = "")
        {
            Result = result;
            ElementType = elementType;
            Name = name;
            Risk = string.Empty;
        }

        public ParseCheckExecutionResult(ParseCheckResultType result, string elementType, string elementData, string risk, string name = "")
        {
            Result = result;
            ElementType = elementType;
            ElementData = elementData;
            Name = name;
            Risk = DetermineRiskFromResult(result, risk);
        }

        public ParseCheckExecutionResult(ParseCheckResultType result, string elementType, string elementData, string risk, Guid parentId, string name = "")
        {
            Result = result;
            ElementType = elementType;
            ElementData = elementData;
            Name = name;
            ParentId = parentId;
            Risk = DetermineRiskFromResult(result, risk);
        }

        private static string DetermineRiskFromResult(ParseCheckResultType parseCheckType, string risk)
        {
            return parseCheckType switch
            {
                ParseCheckResultType.count => string.Empty,
                ParseCheckResultType.pass => string.Empty,
                _ => risk,
            };
        }
    }
}
