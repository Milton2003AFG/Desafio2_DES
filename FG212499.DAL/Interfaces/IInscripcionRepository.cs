using FG212499.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FG212499.DAL.Interfaces
{
    public interface IInscripcionRepository
    {
        Task<List<Inscripcion>> GetAllAsync();
        Task<Inscripcion?> GetByIdAsync(int id);
        Task<bool> ExisteInscripcionAsync(int idEstudiante, int idCurso);
        Task<int> InsertAsync(Inscripcion entity);
        Task<Inscripcion?> UpdateAsync(Inscripcion entity);
        Task<bool> DeleteAsync(int id);
    }
}
