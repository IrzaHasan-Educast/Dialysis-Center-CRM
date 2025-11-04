using DialysisCRM.API.Data;
using DialysisCRM.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DialysisCRM.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CMS107Controller : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CMS107Controller(ApplicationDbContext context)
        {
            _context = context;
        }

        // 🟢 POST: api/cms107/{patientId}
        [HttpPost("{patientId}")]
        public async Task<IActionResult> AddCMS107(int patientId, CMS107Eligibility cms107)
        {
            var patient = await _context.Patients.FindAsync(patientId);
            if (patient == null)
                return NotFound("Patient not found.");

            cms107.PatientId = patientId;
            _context.CMS107Eligibilities.Add(cms107);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(AddCMS107), new { id = cms107.Id }, cms107);
        }

        // 🟠 PUT: api/cms107/{patientId}
        [HttpPut("{patientId}")]
        public async Task<IActionResult> UpdateCMS107(int patientId, CMS107Eligibility cms107)
        {
            var existingCMS107 = await _context.CMS107Eligibilities.FirstOrDefaultAsync(c => c.PatientId == patientId);
            if (existingCMS107 == null)
                return NotFound("CMS107 record not found for this patient.");

            existingCMS107.IsEligible = cms107.IsEligible;
            existingCMS107.StartDate = cms107.StartDate;
            existingCMS107.EndDate = cms107.EndDate;
            existingCMS107.LastCheckedOn = cms107.LastCheckedOn;
            existingCMS107.Notes = cms107.Notes;

            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
