using FG212499.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FG212499.BL.Interfaces
{
    public interface ICursoService
    {
        Task<List<CursoDto>> GetAllAsync();
        Task<CursoDto?> GetByIdAsync(int id);
        Task<int> InsertAsync(CursoDto dto);
        Task<CursoDto?> UpdateAsync(CursoDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
