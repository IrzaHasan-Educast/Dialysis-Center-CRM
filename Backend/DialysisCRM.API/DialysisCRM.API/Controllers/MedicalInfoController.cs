using DialysisCRM.API.Data;
using DialysisCRM.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DialysisCRM.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicalInfoController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public MedicalInfoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // POST: api/Patient/{patientId}/medical-info
        [HttpPost("{patientId}/medical-info")]
        public async Task<IActionResult> AddMedicalInfo(int patientId, PatientMedicalInfo medicalInfo)
        {
            var patient = await _context.Patients.FindAsync(patientId);
            if (patient == null)
                return NotFound("Patient not found.");

            medicalInfo.PatientId = patientId;
            _context.PatientMedicalInfos.Add(medicalInfo);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(AddMedicalInfo), new { id = medicalInfo.Id }, medicalInfo);
        }


        // PUT: api/MedicalInfo/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMedicalInfo(int id, PatientMedicalInfo updatedInfo)
        {
            if (id != updatedInfo.Id)
                return BadRequest("ID mismatch.");

            var existingInfo = await _context.PatientMedicalInfos.FindAsync(id);
            if (existingInfo == null)
                return NotFound("Medical info not found.");

            // Update fields
            existingInfo.Diagnosis = updatedInfo.Diagnosis;
            existingInfo.ChronicConditions = updatedInfo.ChronicConditions;
            existingInfo.TreatmentPlan = updatedInfo.TreatmentPlan;
            existingInfo.ReferringPhysicianName = updatedInfo.ReferringPhysicianName;
            existingInfo.PhysicianContact = updatedInfo.PhysicianContact;

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
