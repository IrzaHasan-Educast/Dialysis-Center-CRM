namespace DialysisCRM.API.DTOs
{
    public class PatientDTO
    {
        public string FullName { get; set; } = string.Empty;

        [System.ComponentModel.DataAnnotations.Required]
        public DateTime DateOfBirth { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Gender { get; set; } = string.Empty;

        [System.ComponentModel.DataAnnotations.Phone]
        public string Phone { get; set; } = string.Empty;

        [System.ComponentModel.DataAnnotations.EmailAddress]
        public string Email { get; set; } = string.Empty;

        [System.ComponentModel.DataAnnotations.StringLength(200)]
        public string Address { get; set; } = string.Empty;
    }
}
