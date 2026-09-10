using FG212499.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FG212499.DAL.Interfaces
{
    public interface IInstructorRepository
    {
        Task<List<Instructor>> GetAllAsync();
        Task<Instructor?> GetByIdAsync(int id);
        Task<int> InsertAsync(Instructor entity);
        Task<Instructor?> UpdateAsync(Instructor entity);
        Task<bool> DeleteAsync(int id);
    }
}
