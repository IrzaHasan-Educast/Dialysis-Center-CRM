using DialysisCRM.API.Data;
using DialysisCRM.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DialysisCRM.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InsuranceController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public InsuranceController(ApplicationDbContext context)
        {
            _context = context;
        }

        // 🟢 POST: api/insurance/{patientId}
        [HttpPost("{patientId}")]
        public async Task<IActionResult> AddInsurance(int patientId, Insurance insurance)
        {
            var patient = await _context.Patients.FindAsync(patientId);
            if (patient == null)
                return NotFound("Patient not found.");

            insurance.PatientId = patientId;
            _context.Insurances.Add(insurance);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(AddInsurance), new { id = insurance.Id }, insurance);
        }

        // 🟠 PUT: api/insurance/{patientId}
        [HttpPut("{patientId}")]
        public async Task<IActionResult> UpdateInsurance(int patientId, Insurance insurance)
        {
            var existingInsurance = await _context.Insurances.FirstOrDefaultAsync(i => i.PatientId == patientId);
            if (existingInsurance == null)
                return NotFound("Insurance record not found for this patient.");

            existingInsurance.ProviderName = insurance.ProviderName;
            existingInsurance.PolicyNumber = insurance.PolicyNumber;
            existingInsurance.CoverageStatus = insurance.CoverageStatus;

            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
