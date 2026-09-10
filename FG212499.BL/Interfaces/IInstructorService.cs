using FG212499.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FG212499.BL.Interfaces
{
    public interface IInstructorService
    {
        Task<List<InstructorDto>> GetAllAsync();
        Task<InstructorDto?> GetByIdAsync(int id);
        Task<int> InsertAsync(InstructorDto dto);
        Task<InstructorDto?> UpdateAsync(InstructorDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
