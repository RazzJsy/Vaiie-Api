namespace Rules.Rules
{
    using Data.Models;
    using global::Rules.Enums;
    using global::Rules.Extensions;
    using global::Rules.Interfaces;
    using global::Rules.Models;
    using global::Rules.Validation;
    using System;

    public class CityAndCountryPopulatedRule : AbstractRule
    {
        public override int RuleId => 2;

        public override string Title => "City and Country Populated";

        public override string Rationale => "Country required";

        public override RuleRefs RuleRef => RuleRefs.AddressCountryPopulated;

        public override void Execute(ReportingModel model)
        {
            List<Address> addresses = model.FindMatchingFields("Address").AsEnumerable().Cast<Address>().ToList();
            List<ParseCheckExecutionResult> cityAndCountryList = addresses.Select(address => ParseAndCheckAddress(address)).ToList();

            if (cityAndCountryList.Count == 0)
            {
                cityAndCountryList.Add(new ParseCheckExecutionResult(ParseCheckResultType.na, "Address"));
            }

            _results = new KeyValuePair<string, List<IResult>>("AddressCountry", cityAndCountryList.AddAdditionalData(RuleId, Title, Rationale).Cast<IResult>().ToList());
        }

        public ParseCheckExecutionResult ParseAndCheckAddress(Address address)
        {
            ValidateAddress validateAddress = new();
            return validateAddress.CheckCountryIsPopulated(address);
        }

        public override bool IsThisRuleInScope(ReportingModel model)
        {
            return true;
        }
    }
}
