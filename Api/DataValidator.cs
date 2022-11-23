namespace Data
{
    using Api.Schema;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Azure.WebJobs;
    using Microsoft.Azure.WebJobs.Extensions.Http;
    using Newtonsoft.Json;
    using Rules;
    using Rules.Enums;
    using Rules.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    public class DataValidator
    {
        private readonly CoreValidator _coreValidator = new();
        private readonly List<IResult> _blacklistedList = new();

        [FunctionName("DataValidator")]
        public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "validate")] HttpRequest req)
        {
            try
            {
                var body = await new StreamReader(req.Body).ReadToEndAsync();
                var schemaValidation = ValidateSchema.ValidateJson(body);

                if (schemaValidation.Item1)
                {
                    var output = _coreValidator.ExecuteValidation(body);

                    foreach(var item in output.ParseDataOutput)
                    {
                        _blacklistedList.AddRange(item.Value.Where(a => a.Result == ParseCheckResultType.Fail.ToString()).ToList());
                    }

                    var blackListedString = JsonConvert.SerializeObject(_blacklistedList);

                    return new OkObjectResult(blackListedString);
                }

                return new ObjectResult($"Schema validation failed: {string.Join(", ", schemaValidation.Item2)}");
            }
            catch (Exception ex)
            {
                return new ObjectResult($"Error processing request: {ex.Message}");
            }
        }
    }
}