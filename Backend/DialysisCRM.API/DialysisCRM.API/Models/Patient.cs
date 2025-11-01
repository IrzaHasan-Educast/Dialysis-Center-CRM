using System.Text.Json.Serialization;

namespace DialysisCRM.API.Models
{
    public class Patient
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;

        // Navigation properties (nullable to avoid null reference issues)
        public PatientMedicalInfo? MedicalInfo { get; set; }
        public PatientReferral? Referral { get; set; }
        public CMS107Eligibility? CMS107 { get; set; }
        public Insurance? Insurance { get; set; }
        public ICollection<PatientDocument>? Documents { get; set; }
        //public ICollection<ScheduleSlot>? ScheduleSlots { get; set; }
    }
}
