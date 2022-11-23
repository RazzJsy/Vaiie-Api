namespace Rules
{
    using global::Rules.Interfaces;
    using global::Rules.Models;

    public class RulesEngine
    {
        private readonly ReportingModel _model = new();

        public void DeserialiseData(string body)
        {
            _model.LoadModelFromJson(body);
        }

        public ParseDataResult ParseRules()
        {
            Dictionary<string, List<IResult>> parseDataOutput = new();

            if (_model.organisationsData != null)
            {
                Dictionary<string, List<IResult>> parseOutput = _model.ExecuteRulesInScope();
                parseDataOutput = parseOutput;
            }

            return new ParseDataResult { ParseDataOutput = parseDataOutput };
        }
    }
}
