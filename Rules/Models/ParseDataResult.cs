namespace Rules.Models
{
    using global::Rules.Interfaces;
    using System.Collections.Generic;

    public class ParseDataResult
    {
        public Dictionary<string, List<IResult>> ParseDataOutput { get; set; }
    }
}
