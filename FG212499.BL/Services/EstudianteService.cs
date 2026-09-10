using AutoMapper;
using FG212499.BL.Interfaces;
using FG212499.DAL.Interfaces;
using FG212499.Entities.Dtos;
using FG212499.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FG212499.BL.Services
{
    public class EstudianteService(IEstudianteRepository repo, IMapper mapper) : IEstudianteService
    {
        public async Task<List<EstudianteDto>> GetAllAsync() =>
            mapper.Map<List<EstudianteDto>>(await repo.GetAllAsync());

        public async Task<EstudianteDto?> GetByIdAsync(int id)
        {
            var res = await repo.GetByIdAsync(id);
            return res == null ? null : mapper.Map<EstudianteDto>(res);
        }

        public async Task<int> InsertAsync(EstudianteDto dto) =>
            await repo.InsertAsync(mapper.Map<Estudiante>(dto));

        public async Task<EstudianteDto?> UpdateAsync(EstudianteDto dto)
        {
            var res = await repo.UpdateAsync(mapper.Map<Estudiante>(dto));
            return res == null ? null : mapper.Map<EstudianteDto>(res);
        }

        public async Task<bool> DeleteAsync(int id) => await repo.DeleteAsync(id);
    }
}
