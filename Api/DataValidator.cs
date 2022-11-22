namespace Data
{
    using Api.Schema;
    using Data.Models;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Azure.WebJobs;
    using Microsoft.Azure.WebJobs.Extensions.Http;
    using Newtonsoft.Json;
    using System.IO;
    using System.Threading.Tasks;

    public class DataValidator
    {
        private ValidateSchema _validateSchema = new ValidateSchema();

        [FunctionName("DataValidator")]
        public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "validate")] HttpRequest req)
        {
            var body = await new StreamReader(req.Body).ReadToEndAsync();

            if (_validateSchema.ValidateJson(body))
            {
                var data = JsonConvert.DeserializeObject<Organisation>(body);

                string name = data.Name;

                string responseMessage = string.IsNullOrEmpty(name)
                    ? "This HTTP triggered function executed successfully. Pass a name in the query string or in the request body for a personalized response."
                    : $"Hello, {name}. This HTTP triggered function executed successfully.";

                return new OkObjectResult(responseMessage);
            }

            return new ObjectResult("Failed validation");
        }
    }
}