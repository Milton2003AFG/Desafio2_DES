using FG212499.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FG212499.BL.Interfaces
{
    public interface IInscripcionService
    {
        Task<List<InscripcionDto>> GetAllAsync();
        Task<InscripcionDto?> GetByIdAsync(int id);
        Task<int> InsertAsync(InscripcionDto dto);
        Task<InscripcionDto?> UpdateAsync(InscripcionDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
