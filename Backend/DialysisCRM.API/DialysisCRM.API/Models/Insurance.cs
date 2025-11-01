using System.Text.Json.Serialization;

namespace DialysisCRM.API.Models
{
    public class Insurance
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public string ProviderName { get; set; }
        public string PolicyNumber { get; set; }
        public string CoverageStatus { get; set; }


        [JsonIgnore] 
        public Patient? Patient { get; set; }
    }
}
