using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FG212499.Entities.Models
{
    public class Curso
    {
        public int IdCurso { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public string Nivel { get; set; } = string.Empty;
        public int IdInstructor { get; set; }

        public string? NombreInstructor { get; set; }
    }
}
