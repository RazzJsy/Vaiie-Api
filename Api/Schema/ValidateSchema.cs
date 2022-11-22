namespace Api.Schema
{
    using Newtonsoft.Json.Linq;
    using Newtonsoft.Json.Schema;
    using System.IO;
    using System.Reflection;

    public class ValidateSchema
    {
        public bool ValidateJson(string jsonData)
        {
            JSchema schema = JSchema.Parse(GetSchema());
            JObject user = JObject.Parse(jsonData);

            return user.IsValid(schema);
        }

        private static string GetSchema()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = "Api.Resources.dataSchema.json";

            using Stream stream = assembly.GetManifestResourceStream(resourceName);
            using StreamReader reader = new(stream);
            return reader.ReadToEnd();
        }
    }
}
