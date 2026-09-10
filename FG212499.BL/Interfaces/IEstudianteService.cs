using FG212499.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FG212499.BL.Interfaces
{
    public interface IEstudianteService
    {
        Task<List<EstudianteDto>> GetAllAsync();
        Task<EstudianteDto?> GetByIdAsync(int id);
        Task<int> InsertAsync(EstudianteDto dto);
        Task<EstudianteDto?> UpdateAsync(EstudianteDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
