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
    public class CursoRepository(IDatabaseRepository db) : ICursoRepository
    {
        public async Task<List<Curso>> GetAllWithInstructorAsync()
        {
            var query = @"SELECT c.IdCurso, c.Titulo, c.Descripcion, c.Nivel, c.IdInstructor, i.Nombre AS NombreInstructor 
                      FROM Curso c 
                      INNER JOIN Instructor i ON c.IdInstructor = i.IdInstructor";
            return await db.GetDataByQueryAsync<Curso>(query);
        }

        public async Task<Curso?> GetByIdAsync(int id)
        {
            var p = new DynamicParameters();
            p.Add("@Id", id);
            var res = await db.GetDataByQueryAsync<Curso>("SELECT * FROM Curso WHERE IdCurso = @Id", p);
            return res.FirstOrDefault();
        }

        public async Task<int> InsertAsync(Curso entity)
        {
            var query = "INSERT INTO Curso (Titulo, Descripcion, Nivel, IdInstructor) VALUES (@Titulo, @Descripcion, @Nivel, @IdInstructor); SELECT CAST(SCOPE_IDENTITY() as int)";
            var p = new DynamicParameters();
            p.Add("@Titulo", entity.Titulo);
            p.Add("@Descripcion", entity.Descripcion);
            p.Add("@Nivel", entity.Nivel);
            p.Add("@IdInstructor", entity.IdInstructor);
            return await db.InsertAsync(query, p);
        }

        public async Task<Curso?> UpdateAsync(Curso entity)
        {
            var query = "UPDATE Curso SET Titulo = @Titulo, Descripcion = @Descripcion, Nivel = @Nivel, IdInstructor = @IdInstructor WHERE IdCurso = @Id";
            var p = new DynamicParameters();
            p.Add("@Id", entity.IdCurso);
            p.Add("@Titulo", entity.Titulo);
            p.Add("@Descripcion", entity.Descripcion);
            p.Add("@Nivel", entity.Nivel);
            p.Add("@IdInstructor", entity.IdInstructor);
            await db.UpdateAsync<Curso>(query, p);
            return entity;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var p = new DynamicParameters();
            p.Add("@Id", id);
            return await db.DeleteAsync("DELETE FROM Curso WHERE IdCurso = @Id", p);
        }
    }
}
