namespace Rules
{
    using global::Rules.Models;

    public class CoreValidator
    {
        readonly RulesEngine _rulesEngine = new();

        public ParseDataResult ExecuteValidation(string body)
        {
            try
            {
                _rulesEngine.DeserialiseData(body);
                var output = _rulesEngine.ParseRules();

                return output;
            }
            catch
            {
                return null;
            }
        }
    }
}
