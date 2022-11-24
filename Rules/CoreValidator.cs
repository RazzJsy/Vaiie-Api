namespace Rules
{
    using global::Rules.Interfaces;

    public class CoreValidator
    {
        readonly RulesEngine _rulesEngine = new();

        public List<IResult> ExecuteValidation(string body)
        {
            try
            {
                _rulesEngine.DeserialiseData(body);
                var output = _rulesEngine.ParseRules();
                var relatedEntities = _rulesEngine.GetRelatedBlacklistedEntities(body);

                return output;
            }
            catch
            {
                return null;
            }
        }        
    }
}
