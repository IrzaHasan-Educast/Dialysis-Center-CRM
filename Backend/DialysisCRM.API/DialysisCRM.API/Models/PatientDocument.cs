using System.Text.Json.Serialization;

namespace DialysisCRM.API.Models
{
    public class PatientDocument
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public string DocumentType { get; set; }
        public string FilePath { get; set; }
        public DateTime UploadedAt { get; set; }

        [JsonIgnore]
        public Patient? Patient { get; set; }
    }
}
