namespace Rules
{
    using global::Rules.Interfaces;
    using Newtonsoft.Json.Linq;

    public class CoreValidator
    {
        readonly RulesEngine _rulesEngine = new();

        public Tuple<List<IResult>, List<JObject>>? ExecuteValidation(string body)
        {
            try
            {
                _rulesEngine.DeserialiseData(body);
                var output = _rulesEngine.ParseRules();
                var relatedEntities = _rulesEngine.GetRelatedBlacklistedEntities(body);

                return new Tuple<List<IResult>, List<JObject>>(output, relatedEntities);
            }
            catch
            {
                return null;
            }
        }        
    }
}
