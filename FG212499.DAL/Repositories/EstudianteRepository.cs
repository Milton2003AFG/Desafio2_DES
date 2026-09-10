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
    public class EstudianteRepository(IDatabaseRepository db) : IEstudianteRepository
    {
        public async Task<List<Estudiante>> GetAllAsync() =>
            await db.GetDataByQueryAsync<Estudiante>("SELECT * FROM Estudiante");

        public async Task<Estudiante?> GetByIdAsync(int id)
        {
            var p = new DynamicParameters();
            p.Add("@Id", id);
            var res = await db.GetDataByQueryAsync<Estudiante>("SELECT * FROM Estudiante WHERE IdEstudiante = @Id", p);
            return res.FirstOrDefault();
        }

        public async Task<int> InsertAsync(Estudiante entity)
        {
            var query = "INSERT INTO Estudiante (Nombre, Email, FechaNacimiento) VALUES (@Nombre, @Email, @FechaNacimiento); SELECT CAST(SCOPE_IDENTITY() as int)";
            var p = new DynamicParameters();
            p.Add("@Nombre", entity.Nombre);
            p.Add("@Email", entity.Email);
            p.Add("@FechaNacimiento", entity.FechaNacimiento);
            return await db.InsertAsync(query, p);
        }

        public async Task<Estudiante?> UpdateAsync(Estudiante entity)
        {
            var query = "UPDATE Estudiante SET Nombre = @Nombre, Email = @Email, FechaNacimiento = @FechaNacimiento WHERE IdEstudiante = @Id";
            var p = new DynamicParameters();
            p.Add("@Id", entity.IdEstudiante);
            p.Add("@Nombre", entity.Nombre);
            p.Add("@Email", entity.Email);
            p.Add("@FechaNacimiento", entity.FechaNacimiento);
            await db.UpdateAsync<Estudiante>(query, p);
            return entity;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var p = new DynamicParameters();
            p.Add("@Id", id);
            return await db.DeleteAsync("DELETE FROM Estudiante WHERE IdEstudiante = @Id", p);
        }
    }
}
