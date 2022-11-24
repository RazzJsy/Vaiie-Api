namespace Rules
{
    using global::Rules.Enums;
    using global::Rules.Interfaces;
    using global::Rules.Models;
    using Newtonsoft.Json.Linq;

    public class RulesEngine
    {
        private readonly ReportingModel _model = new();
        private Dictionary<string, List<IResult>> _parseDataOutput = new();
        private readonly List<IResult> _blacklistedList = new();

        public void DeserialiseData(string body)
        {
            _model.LoadModelFromJson(body);
        }

        public List<IResult> ParseRules()
        {
            if (_model.organisationsData != null)
            {
                Dictionary<string, List<IResult>> parseOutput = _model.ExecuteRulesInScope();
                _parseDataOutput = parseOutput;

                foreach (var item in parseOutput)
                {
                    _blacklistedList.AddRange(item.Value.Where(a => a.Result == ParseCheckResultType.Fail.ToString()).ToList());
                }
            }

            return _blacklistedList;
        }

        public List<JObject> GetRelatedBlacklistedEntities(string body)
        {
            List<JObject> relatedBlacklistedEntities = new();

            foreach (var value in _blacklistedList)
            {
                relatedBlacklistedEntities.AddRange(RelatedEntities(body, ((ParseCheckExecutionResult)value).ParentId));
            }

            foreach (var realated in relatedBlacklistedEntities)
            {

            }

            return relatedBlacklistedEntities;
        }

        private List<JObject> RelatedEntities(string body, Guid parentId)
        {
            List<JObject> outputList = new();

            var parentIdString = parentId.ToString().ToUpper();
            var list = JObject.Parse(body).DescendantsAndSelf().OfType<JObject>().ToList();

            var output = list.Where(a => (string?)a["Id"] == parentIdString).ToList();
            outputList.AddRange(output);

            foreach(var item in output)
            {
                if (item.ContainsKey("ParentId"))
                {
                    outputList.AddRange(list.Where(b => (string?)b["Id"] == ((JValue)item["ParentId"]).Value.ToString()).ToList());
                }
            }

            return outputList;
        }
    }
}
