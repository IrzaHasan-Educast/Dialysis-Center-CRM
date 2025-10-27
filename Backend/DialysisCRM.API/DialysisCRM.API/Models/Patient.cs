namespace DialysisCRM.API.Models
{
    public class Patient
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public bool IsCMS107Eligible { get; set; }
        public DateTime? CMS107StartDate { get; set; }
        public DateTime? CMS107EndDate { get; set; }
    }
}

