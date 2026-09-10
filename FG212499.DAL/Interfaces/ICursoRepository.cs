using FG212499.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FG212499.DAL.Interfaces
{
    public interface ICursoRepository
    {
        Task<List<Curso>> GetAllWithInstructorAsync();
        Task<Curso?> GetByIdAsync(int id);
        Task<int> InsertAsync(Curso entity);
        Task<Curso?> UpdateAsync(Curso entity);
        Task<bool> DeleteAsync(int id);
    }
}
