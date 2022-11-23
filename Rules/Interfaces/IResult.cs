using Rules.Enums;

namespace Rules.Interfaces
{
    public interface IResult
    {
        public string Result { get; }
        public int RuleId { get; set; }
        public string Title { get; set; }
    }
}
