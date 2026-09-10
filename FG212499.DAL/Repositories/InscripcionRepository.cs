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
    public class InscripcionRepository(IDatabaseRepository db) : IInscripcionRepository
    {
        public async Task<List<Inscripcion>> GetAllAsync()
        {
            var query = @"SELECT i.IdInscripcion, i.FechaInscripcion, i.IdEstudiante, i.IdCurso, e.Nombre AS NombreEstudiante, c.Titulo AS TituloCurso
                      FROM Inscripcion i
                      INNER JOIN Estudiante e ON i.IdEstudiante = e.IdEstudiante
                      INNER JOIN Curso c ON i.IdCurso = c.IdCurso";
            return await db.GetDataByQueryAsync<Inscripcion>(query);
        }

        public async Task<Inscripcion?> GetByIdAsync(int id)
        {
            var p = new DynamicParameters();
            p.Add("@Id", id);
            var res = await db.GetDataByQueryAsync<Inscripcion>("SELECT * FROM Inscripcion WHERE IdInscripcion = @Id", p);
            return res.FirstOrDefault();
        }

        public async Task<bool> ExisteInscripcionAsync(int idEstudiante, int idCurso)
        {
            var p = new DynamicParameters();
            p.Add("@IdEstudiante", idEstudiante);
            p.Add("@IdCurso", idCurso);
            var res = await db.GetDataByQueryAsync<int>("SELECT COUNT(1) FROM Inscripcion WHERE IdEstudiante = @IdEstudiante AND IdCurso = @IdCurso", p);
            return res.FirstOrDefault() > 0;
        }

        public async Task<int> InsertAsync(Inscripcion entity)
        {
            var query = "INSERT INTO Inscripcion (FechaInscripcion, IdEstudiante, IdCurso) VALUES (@FechaInscripcion, @IdEstudiante, @IdCurso); SELECT CAST(SCOPE_IDENTITY() as int)";
            var p = new DynamicParameters();
            p.Add("@FechaInscripcion", entity.FechaInscripcion);
            p.Add("@IdEstudiante", entity.IdEstudiante);
            p.Add("@IdCurso", entity.IdCurso);
            return await db.InsertAsync(query, p);
        }

        public async Task<Inscripcion?> UpdateAsync(Inscripcion entity)
        {
            var query = "UPDATE Inscripcion SET FechaInscripcion = @FechaInscripcion, IdEstudiante = @IdEstudiante, IdCurso = @IdCurso WHERE IdInscripcion = @Id";
            var p = new DynamicParameters();
            p.Add("@Id", entity.IdInscripcion);
            p.Add("@FechaInscripcion", entity.FechaInscripcion);
            p.Add("@IdEstudiante", entity.IdEstudiante);
            p.Add("@IdCurso", entity.IdCurso);
            await db.UpdateAsync<Inscripcion>(query, p);
            return entity;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var p = new DynamicParameters();
            p.Add("@Id", id);
            return await db.DeleteAsync("DELETE FROM Inscripcion WHERE IdInscripcion = @Id", p);
        }
    }
}
