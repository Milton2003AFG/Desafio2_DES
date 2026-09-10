using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FG212499.Entities.Models
{
    public class Instructor
    {
        public int IdInstructor { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Especialidad { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
}
