using System.Text.Json.Serialization;

namespace DialysisCRM.API.Models
{
    public class PatientReferral
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public string Source { get; set; }
        public string Reason { get; set; }
        public string Urgency { get; set; }
        public DateTime ReferredOn { get; set; }

        [JsonIgnore]
        public Patient? Patient { get; set; }
    }
}
