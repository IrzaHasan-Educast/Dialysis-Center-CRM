using DialysisCRM.API.Data;
using DialysisCRM.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DialysisCRM.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public DocumentController(ApplicationDbContext context)
        {
            _context = context;
        }

        // 🟢 POST: api/document/{patientId}
        [HttpPost("{patientId}")]
        public async Task<IActionResult> AddDocument(int patientId, PatientDocument document)
        {
            var patient = await _context.Patients.FindAsync(patientId);
            if (patient == null)
                return NotFound("Patient not found.");

            document.PatientId = patientId;
            _context.PatientDocuments.Add(document);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(AddDocument), new { id = document.Id }, document);
        }

        // 🟠 PUT: api/document/{patientId}
        [HttpPut("{patientId}")]
        public async Task<IActionResult> UpdateDocument(int patientId, PatientDocument document)
        {
            var existingDocument = await _context.PatientDocuments.FirstOrDefaultAsync(d => d.PatientId == patientId);
            if (existingDocument == null)
                return NotFound("Document not found for this patient.");

            existingDocument.DocumentType = document.DocumentType;
            existingDocument.FilePath = document.FilePath;
            existingDocument.UploadedAt = document.UploadedAt;

            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
