using DialysisCRM.API.Data;
using DialysisCRM.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DialysisCRM.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PatientController(ApplicationDbContext context)
        {
            _context = context;
        }

        // 🟢 GET: api/patient
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Patient>>> GetPatients()
        {
            var patients = await _context.Patients
                .Include(p => p.MedicalInfo)
                .Include(p => p.Referral)
                .Include(p => p.CMS107)
                .Include(p => p.Insurance)
                .Include(p => p.Documents)
                .ToListAsync();

            return Ok(patients);
        }

        // 🟢 GET: api/patient/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Patient>> GetPatient(int id)
        {
            var patient = await _context.Patients
                .Include(p => p.MedicalInfo)
                .Include(p => p.Referral)
                .Include(p => p.CMS107)
                .Include(p => p.Insurance)
                .Include(p => p.Documents)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (patient == null)
                return NotFound();

            return Ok(patient);
        }

        // 🟡 POST: api/patient
        [HttpPost]
        public async Task<ActionResult<Patient>> CreatePatient(Patient patient)
        {
            if (patient == null)
                return BadRequest("Patient data is missing.");

            try
            {
                // Add patient to context
                _context.Patients.Add(patient);

                // 🕐 Convert all DateTimes to UTC before saving
                foreach (var entry in _context.ChangeTracker.Entries())
                {
                    foreach (var prop in entry.Properties)
                    {
                        if (prop.CurrentValue is DateTime dt)
                            prop.CurrentValue = DateTime.SpecifyKind(dt, DateTimeKind.Utc);
                    }
                }

                // Save to DB
                await _context.SaveChangesAsync();

                // Return response with created resource
                return CreatedAtAction(nameof(GetPatient), new { id = patient.Id }, patient);
            }
            catch (Exception ex)
            {
                // Log or display detailed error (for debugging)
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }


        // 🟠 PUT: api/patient/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePatient(int id, Patient updatedPatient)
        {
            if (id != updatedPatient.Id)
                return BadRequest("ID mismatch.");

            var existingPatient = await _context.Patients
                .Include(p => p.MedicalInfo)
                .Include(p => p.Referral)
                .Include(p => p.CMS107)
                .Include(p => p.Insurance)
                .Include(p => p.Documents)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (existingPatient == null)
                return NotFound();

            // 🧠 Update main patient info
            existingPatient.FullName = updatedPatient.FullName;
            existingPatient.Email = updatedPatient.Email;
            existingPatient.Phone = updatedPatient.Phone;
            existingPatient.Address = updatedPatient.Address;
            existingPatient.Gender = updatedPatient.Gender;
            existingPatient.DateOfBirth = updatedPatient.DateOfBirth;

            // 🩺 Update related entities if they exist
            if (existingPatient.MedicalInfo != null && updatedPatient.MedicalInfo != null)
            {
                existingPatient.MedicalInfo.Diagnosis = updatedPatient.MedicalInfo.Diagnosis;
                existingPatient.MedicalInfo.ChronicConditions = updatedPatient.MedicalInfo.ChronicConditions;
                existingPatient.MedicalInfo.TreatmentPlan = updatedPatient.MedicalInfo.TreatmentPlan;
                existingPatient.MedicalInfo.ReferringPhysicianName = updatedPatient.MedicalInfo.ReferringPhysicianName;
                existingPatient.MedicalInfo.PhysicianContact = updatedPatient.MedicalInfo.PhysicianContact;
            }

            if (existingPatient.Referral != null && updatedPatient.Referral != null)
            {
                existingPatient.Referral.Source = updatedPatient.Referral.Source;
                existingPatient.Referral.Reason = updatedPatient.Referral.Reason;
                existingPatient.Referral.Urgency = updatedPatient.Referral.Urgency;
                existingPatient.Referral.ReferredOn = updatedPatient.Referral.ReferredOn;
            }

            if (existingPatient.CMS107 != null && updatedPatient.CMS107 != null)
            {
                existingPatient.CMS107.IsEligible = updatedPatient.CMS107.IsEligible;
                existingPatient.CMS107.StartDate = updatedPatient.CMS107.StartDate;
                existingPatient.CMS107.EndDate = updatedPatient.CMS107.EndDate;
                existingPatient.CMS107.LastCheckedOn = updatedPatient.CMS107.LastCheckedOn;
                existingPatient.CMS107.Notes = updatedPatient.CMS107.Notes;
            }

            if (existingPatient.Insurance != null && updatedPatient.Insurance != null)
            {
                existingPatient.Insurance.ProviderName = updatedPatient.Insurance.ProviderName;
                existingPatient.Insurance.PolicyNumber = updatedPatient.Insurance.PolicyNumber;
                existingPatient.Insurance.CoverageStatus = updatedPatient.Insurance.CoverageStatus;
            }

            // 📄 Update documents (simplest way: replace all)
            if (updatedPatient.Documents != null && updatedPatient.Documents.Any())
            {
                // remove existing docs
                _context.PatientDocuments.RemoveRange(existingPatient.Documents);
                // add new ones
                existingPatient.Documents = updatedPatient.Documents;
            }

            await _context.SaveChangesAsync();
            return Ok("Patient and related data updated successfully.");
        }


        // 🔴 DELETE: api/patient/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePatient(int id)
        {
            var patient = await _context.Patients.FindAsync(id);
            if (patient == null)
                return NotFound();

            _context.Patients.Remove(patient);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
