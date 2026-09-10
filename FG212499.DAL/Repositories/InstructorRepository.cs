using Dapper;
using FG212499.DAL.Interfaces;
using FG212499.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FG212499.DAL.Repositories
{
    public class InstructorRepository(IDatabaseRepository db) : IInstructorRepository
    {
        public async Task<List<Instructor>> GetAllAsync() =>
            await db.GetDataByQueryAsync<Instructor>("SELECT * FROM Instructor");

        public async Task<Instructor?> GetByIdAsync(int id)
        {
            var p = new DynamicParameters();
            p.Add("@Id", id);
            var res = await db.GetDataByQueryAsync<Instructor>("SELECT * FROM Instructor WHERE IdInstructor = @Id", p);
            return res.FirstOrDefault();
        }

        public async Task<int> InsertAsync(Instructor entity)
        {
            var query = "INSERT INTO Instructor (Nombre, Especialidad, Email) VALUES (@Nombre, @Especialidad, @Email); SELECT CAST(SCOPE_IDENTITY() as int)";
            var p = new DynamicParameters();
            p.Add("@Nombre", entity.Nombre);
            p.Add("@Especialidad", entity.Especialidad);
            p.Add("@Email", entity.Email);
            return await db.InsertAsync(query, p);
        }

        public async Task<Instructor?> UpdateAsync(Instructor entity)
        {
            var query = "UPDATE Instructor SET Nombre = @Nombre, Especialidad = @Especialidad, Email = @Email WHERE IdInstructor = @Id";
            var p = new DynamicParameters();
            p.Add("@Id", entity.IdInstructor);
            p.Add("@Nombre", entity.Nombre);
            p.Add("@Especialidad", entity.Especialidad);
            p.Add("@Email", entity.Email);
            await db.UpdateAsync<Instructor>(query, p);
            return entity;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var p = new DynamicParameters();
            p.Add("@Id", id);
            return await db.DeleteAsync("DELETE FROM Instructor WHERE IdInstructor = @Id", p);
        }
    }
}
