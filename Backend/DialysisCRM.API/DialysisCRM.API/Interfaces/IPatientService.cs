using System.Collections.Generic;
using System.Threading.Tasks;
using DialysisCRM.API.Models;

namespace DialysisCRM.API.Interfaces
{
    public interface IPatientService
    {
        Task<IEnumerable<Patient>> GetAllAsync();
        Task<Patient> GetByIdAsync(int id);
        Task<Patient> CreateAsync(Patient patient);
        Task<bool> UpdateAsync(int id, Patient patient);
        Task<bool> DeleteAsync(int id);
    }
}
