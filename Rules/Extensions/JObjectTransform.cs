namespace Rules.Extensions
{
    using Newtonsoft.Json.Linq;

    public static class JObjectTransform
    {
        public static void RemoveProperties(this JObject jObject, string[] props)
        {
            foreach(var item in props)
            {
                if (jObject.ContainsKey(item))
                {
                    jObject.Property(item).Remove();
                }
            }
        }
    }
}
