namespace Rules.Models
{
    using Casablanca_Common.Helpers;
    using Data.Models;
    using global::Rules.Interfaces;
    using global::Rules.Rules;
    using Newtonsoft.Json;
    using System.Collections.Generic;

    public class ReportingModel
    {
        private readonly FindAll _findAll = new();

        public Organisation organisationsData = new();

        private readonly List<AbstractRule> rules = new()
        {
            new DirectorBlacklistedParseCheck(),
            new ShareholderBlacklistedParseCheck()
            //new CityAndCountryPopulatedRule()
        };

        public void LoadModelFromJson(string body)
        {
            organisationsData = JsonConvert.DeserializeObject<Organisation>(body);
        }

        public Dictionary<string, List<IResult>> ExecuteRulesInScope()
        {
            Dictionary<string, List<IResult>> results = new();

            foreach (AbstractRule rule in rules)
            {
                if (rule.IsThisRuleInScope(this))
                {
                    rule.Execute(this);
                    results.Add(rule.Results().Key, rule.Results().Value);
                }
            }

            return results;
        }

        public List<object> FindMatchingFields(string type)
        {
            List<object> objList = new();

            switch (type)
            {
                case "Director":
                    {
                        objList.AddRange(_findAll.Instances<Director>(organisationsData));
                        break;
                    }
                case "Shareholder":
                    {
                        objList.AddRange(_findAll.Instances<Shareholder>(organisationsData));
                        break;
                    }
                case "Address":
                    {
                        objList.AddRange(_findAll.Instances<Address>(organisationsData));
                        break;
                    }
                default:
                    {
                        // Do nothing
                        break;
                    }
            }

            return objList;
        }
    }
}