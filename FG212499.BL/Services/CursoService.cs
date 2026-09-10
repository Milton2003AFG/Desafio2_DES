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
    public class CursoService(ICursoRepository repo, IInstructorRepository instructorRepo, IMapper mapper) : ICursoService
    {
        private readonly string[] _nivelesValidos = ["Básico", "Intermedio", "Avanzado"];

        public async Task<List<CursoDto>> GetAllAsync() =>
            mapper.Map<List<CursoDto>>(await repo.GetAllWithInstructorAsync());

        public async Task<CursoDto?> GetByIdAsync(int id)
        {
            var res = await repo.GetByIdAsync(id);
            return res == null ? null : mapper.Map<CursoDto>(res);
        }

        public async Task<int> InsertAsync(CursoDto dto)
        {
            // Validar niveles válidos
            if (!_nivelesValidos.Contains(dto.Nivel, StringComparer.OrdinalIgnoreCase))
                throw new ArgumentException("El nivel solo puede ser: Básico, Intermedio o Avanzado.");

            // El instructor debe existir
            var instructor = await instructorRepo.GetByIdAsync(dto.CodigoInstructor);
            if (instructor == null)
                throw new ArgumentException($"El instructor con ID {dto.CodigoInstructor} no existe.");

            return await repo.InsertAsync(mapper.Map<Curso>(dto));
        }

        public async Task<CursoDto?> UpdateAsync(CursoDto dto)
        {
            if (!_nivelesValidos.Contains(dto.Nivel, StringComparer.OrdinalIgnoreCase))
                throw new ArgumentException("El nivel solo puede ser: Básico, Intermedio o Avanzado.");

            var instructor = await instructorRepo.GetByIdAsync(dto.CodigoInstructor);
            if (instructor == null)
                throw new ArgumentException($"El instructor con ID {dto.CodigoInstructor} no existe.");

            var res = await repo.UpdateAsync(mapper.Map<Curso>(dto));
            return res == null ? null : mapper.Map<CursoDto>(res);
        }

        public async Task<bool> DeleteAsync(int id) => await repo.DeleteAsync(id);
    }
}
