using DialysisCRM.API.Data;
using DialysisCRM.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DialysisCRM.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReferralController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ReferralController(ApplicationDbContext context)
        {
            _context = context;
        }

        // 🟢 POST: api/referral/{patientId}
        [HttpPost("{patientId}")]
        public async Task<IActionResult> AddReferral(int patientId, PatientReferral referral)
        {
            var patient = await _context.Patients.FindAsync(patientId);
            if (patient == null)
                return NotFound("Patient not found.");

            referral.PatientId = patientId;
            _context.Referrals.Add(referral);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(AddReferral), new { id = referral.Id }, referral);
        }

        // 🟠 PUT: api/referral/{patientId}
        [HttpPut("{patientId}")]
        public async Task<IActionResult> UpdateReferral(int patientId, PatientReferral referral)
        {
            var existingReferral = await _context.Referrals.FirstOrDefaultAsync(r => r.PatientId == patientId);
            if (existingReferral == null)
                return NotFound("Referral not found for this patient.");

            existingReferral.Source = referral.Source;
            existingReferral.Reason = referral.Reason;
            existingReferral.Urgency = referral.Urgency;
            existingReferral.ReferredOn = referral.ReferredOn;

            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
