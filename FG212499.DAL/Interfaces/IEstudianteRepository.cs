using FG212499.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FG212499.DAL.Interfaces
{
    public interface IEstudianteRepository
    {
        Task<List<Estudiante>> GetAllAsync();
        Task<Estudiante?> GetByIdAsync(int id);
        Task<int> InsertAsync(Estudiante entity);
        Task<Estudiante?> UpdateAsync(Estudiante entity);
        Task<bool> DeleteAsync(int id);
    }
}
