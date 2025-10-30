namespace DialysisCRM.API.Models
{
    public class PatientMedicalInfo
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public string Diagnosis { get; set; }
        public string ChronicConditions { get; set; }
        public string TreatmentPlan { get; set; }
        public string ReferringPhysicianName { get; set; }
        public string PhysicianContact { get; set; }

        public Patient Patient { get; set; }
    }
}
