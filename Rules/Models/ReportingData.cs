namespace Rules.Models
{
    using System;
    using System.Text.RegularExpressions;
    using System.Xml.Linq;

    public class ReportingData
    {
        public string formType;
        public bool isFatca;
        public string schemaNameSpace;
        public string xsdLocation;
        public dynamic deserialisedModelData;
        public int failedRulesOutputCount;
        public string reportFilename;
        public DateTime? reportingPeriod { get; set; }
        public DateTime fileTimestamp { get; set; }
        public string transmittingCountry { get; set; }
        public string receivingCountry { get; set; }
        public string sendingCompanyIN { get; set; }



        public ReportingData() { }

        public ReportingData(XName name)
        {
            SetFormData(name.LocalName, name.NamespaceName);
        }

        public void SetFormData(string formTypeString, string schemaNameSpaceString)
        {
            formType = formTypeString;
            schemaNameSpace = schemaNameSpaceString;
            isFatca = formType == "FATCA_OECD";
            xsdLocation = string.Format("Schemas\\{0}", isFatca ? "fatca\\" : "crs\\");
        }

        public bool HasFailedRules
        {
            get { return failedRulesOutputCount > 0; }
        }

        public string GetXsdLocation
        {
            get
            {
                string version = Regex.Match(schemaNameSpace, @"(.{2})\s*$").Value;
                return xsdLocation + version;
            }
        }
    }
}
