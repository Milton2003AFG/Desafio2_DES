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
    public class InscripcionService(
    IInscripcionRepository repo,
    IEstudianteRepository estRepo,
    ICursoRepository cursoRepo,
    IMapper mapper) : IInscripcionService
    {
        public async Task<List<InscripcionDto>> GetAllAsync() =>
            mapper.Map<List<InscripcionDto>>(await repo.GetAllAsync());

        public async Task<InscripcionDto?> GetByIdAsync(int id)
        {
            var res = await repo.GetByIdAsync(id);
            return res == null ? null : mapper.Map<InscripcionDto>(res);
        }

        public async Task<int> InsertAsync(InscripcionDto dto)
        {
            // Validar estudiante existente
            var est = await estRepo.GetByIdAsync(dto.CodigoEstudiante);
            if (est == null) throw new ArgumentException($"El estudiante con ID {dto.CodigoEstudiante} no existe.");

            // Validar curso existente
            var curso = await cursoRepo.GetByIdAsync(dto.CodigoCurso);
            if (curso == null) throw new ArgumentException($"El curso con ID {dto.CodigoCurso} no existe.");

            // No duplicar inscripción de un mismo estudiante a un curso
            var yaInscrito = await repo.ExisteInscripcionAsync(dto.CodigoEstudiante, dto.CodigoCurso);
            if (yaInscrito)
                throw new InvalidOperationException("El estudiante ya se encuentra inscrito en este curso.");

            return await repo.InsertAsync(mapper.Map<Inscripcion>(dto));
        }

        public async Task<InscripcionDto?> UpdateAsync(InscripcionDto dto)
        {
            var res = await repo.UpdateAsync(mapper.Map<Inscripcion>(dto));
            return res == null ? null : mapper.Map<InscripcionDto>(res);
        }

        public async Task<bool> DeleteAsync(int id) => await repo.DeleteAsync(id);
    }
}
