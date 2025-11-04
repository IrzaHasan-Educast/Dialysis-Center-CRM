using DialysisCRM.API.Interfaces;
using DialysisCRM.API.Models;
using DialysisCRM.API.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace DialysisCRM.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PatientController : ControllerBase
    {
        private readonly IPatientService _patientService;

        public PatientController(IPatientService patientService)
        {
            _patientService = patientService;
        }

        // GET all patients
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Patient>>> GetPatients()
        {
            var patients = await _patientService.GetAllAsync();
            return Ok(patients);
        }

        // GET by ID
        [HttpGet("{id}")]
        public async Task<ActionResult<Patient>> GetPatient(int id)
        {
            var patient = await _patientService.GetByIdAsync(id);
            if (patient == null)
                return NotFound();

            return Ok(patient);
        }

        // POST: Create new patient using DTO
        [HttpPost]
        public async Task<ActionResult<Patient>> CreatePatient([FromBody] PatientDTO patientDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var patient = new Patient
            {
                FullName = patientDto.FullName,
                DateOfBirth = patientDto.DateOfBirth,
                Gender = patientDto.Gender,
                Phone = patientDto.Phone,
                Email = patientDto.Email,
                Address = patientDto.Address
            };

            var created = await _patientService.CreateAsync(patient);
            return CreatedAtAction(nameof(GetPatient), new { id = created.Id }, created);
        }

        // PUT: Update
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePatient(int id, [FromBody] PatientDTO patientDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var patient = new Patient
            {
                Id = id,
                FullName = patientDto.FullName,
                DateOfBirth = patientDto.DateOfBirth,
                Gender = patientDto.Gender,
                Phone = patientDto.Phone,
                Email = patientDto.Email,
                Address = patientDto.Address
            };

            var updated = await _patientService.UpdateAsync(id, patient);
            if (!updated)
                return NotFound();

            return NoContent();
        }

        // DELETE
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePatient(int id)
        {
            var deleted = await _patientService.DeleteAsync(id);
            if (!deleted)
                return NotFound();

            return NoContent();
        }
    }
}
