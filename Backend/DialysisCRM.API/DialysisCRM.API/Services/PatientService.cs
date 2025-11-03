using DialysisCRM.API.Data;
using DialysisCRM.API.Interfaces;
using DialysisCRM.API.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace DialysisCRM.API.Services
{
    public class PatientService : IPatientService
    {
        private readonly ApplicationDbContext _context;

        public PatientService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Patient>> GetAllAsync()
        {
            return await _context.Patients
                .Include(p => p.MedicalInfo)
                .Include(p => p.Referral)
                .Include(p => p.CMS107)
                .Include(p => p.Insurance)
                .Include(p => p.Documents)
                .ToListAsync();
        }

        public async Task<Patient?> GetByIdAsync(int id)
        {
            return await _context.Patients
                .Include(p => p.MedicalInfo)
                .Include(p => p.Referral)
                .Include(p => p.CMS107)
                .Include(p => p.Insurance)
                .Include(p => p.Documents)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Patient> CreateAsync(Patient patient)
        {
            _context.Patients.Add(patient);
            await _context.SaveChangesAsync();
            return patient;
        }

        public async Task<bool> UpdateAsync(int id, Patient patient)
        {
            var existing = await _context.Patients.FindAsync(id);
            if (existing == null) return false;

            existing.FullName = patient.FullName;
            existing.Email = patient.Email;
            existing.Phone = patient.Phone;
            existing.Address = patient.Address;
            existing.Gender = patient.Gender;
            existing.DateOfBirth = patient.DateOfBirth;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var patient = await _context.Patients.FindAsync(id);
            if (patient == null) return false;

            _context.Patients.Remove(patient);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
