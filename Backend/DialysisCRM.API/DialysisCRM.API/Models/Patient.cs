namespace DialysisCRM.API.Models
{
    public class Patient
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }

        // Navigation properties
        public PatientMedicalInfo MedicalInfo { get; set; }
        public PatientReferral Referral { get; set; }
        

    }
}

