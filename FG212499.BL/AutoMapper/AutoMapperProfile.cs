using AutoMapper;
using FG212499.Entities.Dtos;
using FG212499.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FG212499.BL.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Instructor, InstructorDto>()
                .ForMember(d => d.CodigoInstructor, o => o.MapFrom(s => s.IdInstructor))
                .ForMember(d => d.NombreCompleto, o => o.MapFrom(s => s.Nombre))
                .ForMember(d => d.Correo, o => o.MapFrom(s => s.Email))
                .ReverseMap();

            CreateMap<Curso, CursoDto>()
                .ForMember(d => d.CodigoCurso, o => o.MapFrom(s => s.IdCurso))
                .ForMember(d => d.CodigoInstructor, o => o.MapFrom(s => s.IdInstructor))
                .ReverseMap();

            CreateMap<Estudiante, EstudianteDto>()
                .ForMember(d => d.CodigoEstudiante, o => o.MapFrom(s => s.IdEstudiante))
                .ForMember(d => d.NombreCompleto, o => o.MapFrom(s => s.Nombre))
                .ForMember(d => d.Correo, o => o.MapFrom(s => s.Email))
                .ReverseMap();

            CreateMap<Inscripcion, InscripcionDto>()
                .ForMember(d => d.CodigoInscripcion, o => o.MapFrom(s => s.IdInscripcion))
                .ForMember(d => d.CodigoEstudiante, o => o.MapFrom(s => s.IdEstudiante))
                .ForMember(d => d.CodigoCurso, o => o.MapFrom(s => s.IdCurso))
                .ReverseMap();
        }
    }
}
