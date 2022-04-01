using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prueba_API.Models
{
    public class UsuariosModel
    {
        public int id_usuario { get; set; }
        public string nombre { get; set; }
        public string email { get; set; }
        public DateTime fecha_registro { get; set; }
        public bool activo { get; set; }
        public DateTime fecha_actualizacion { get; set; }
    }
}
