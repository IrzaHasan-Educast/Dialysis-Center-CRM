namespace DialysisCRM.API.Models
{
    public class CMS107Eligibility
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public bool IsEligible { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime? LastCheckedOn { get; set; }
        public string Notes { get; set; }

        public Patient Patient { get; set; }
    }
}
