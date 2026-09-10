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
    public class InstructorService(IInstructorRepository repo, IMapper mapper) : IInstructorService
    {
        public async Task<List<InstructorDto>> GetAllAsync() =>
            mapper.Map<List<InstructorDto>>(await repo.GetAllAsync());

        public async Task<InstructorDto?> GetByIdAsync(int id)
        {
            var res = await repo.GetByIdAsync(id);
            return res == null ? null : mapper.Map<InstructorDto>(res);
        }

        public async Task<int> InsertAsync(InstructorDto dto) =>
            await repo.InsertAsync(mapper.Map<Instructor>(dto));

        public async Task<InstructorDto?> UpdateAsync(InstructorDto dto)
        {
            var res = await repo.UpdateAsync(mapper.Map<Instructor>(dto));
            return res == null ? null : mapper.Map<InstructorDto>(res);
        }

        public async Task<bool> DeleteAsync(int id) => await repo.DeleteAsync(id);
    }
}
