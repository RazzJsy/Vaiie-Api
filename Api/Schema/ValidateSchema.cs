namespace Api.Schema
{
    using Newtonsoft.Json.Linq;
    using Newtonsoft.Json.Schema;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Reflection;

    public class ValidateSchema
    {
        public static Tuple<bool, IList<string>> ValidateJson(string jsonData)
        {
            JSchema schema = JSchema.Parse(GetSchema());
            JObject data = JObject.Parse(jsonData);

            var isValid = data.IsValid(schema, out IList<string> errorMessages);

            return new Tuple<bool, IList<string>>(isValid, errorMessages);
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