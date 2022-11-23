namespace Rules.Validation
{
    using Data.Models;
    using global::Rules.Enums;
    using global::Rules.Extensions;
    using global::Rules.Models;

    public class ValidateAddress
    {
        public ParseCheckExecutionResult CheckCountryIsPopulated(Address address)
        {
            bool isCountryPresent = true;

            if (string.IsNullOrEmpty(address.Country))
            {
                return new ParseCheckExecutionResult(ParseCheckResultType.fail, "Address", address.Country, "Country Missing");
            }

            return new ParseCheckExecutionResult(isCountryPresent.DetermineParseCheckResultType(), "Address", address.Country, $"Invalid country '{address.Country}' provided");
        }
    }
}
