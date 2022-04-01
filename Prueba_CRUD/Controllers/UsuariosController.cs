using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Prueba_API.Models;
using Prueba_API.Utilitarios;

namespace Prueba_API.Controllers
{
    [ApiController]
    public class UsuariosController : Controller
    {
        [HttpGet("usuarios/listar")]
        public List<UsuariosModel> ListarUsuarios()
        {
            List<UsuariosModel> lstUsuarios = new List<UsuariosModel>();

            DataSet dsUsuarios = ConexionBD.ListarUsuarios("SELECT * FROM Usuarios");

            if (dsUsuarios.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow item in dsUsuarios.Tables[0].Rows)
                {
                    UsuariosModel objUsuarios = new UsuariosModel();
                    objUsuarios.id_usuario = Convert.ToInt32(item[0]);
                    objUsuarios.nombre = Convert.ToString(item[1]);
                    objUsuarios.email = Convert.ToString(item[2]);
                    objUsuarios.fecha_registro = Convert.ToDateTime(item[3]);
                    objUsuarios.activo = Convert.ToBoolean(item[4]);
                    objUsuarios.fecha_actualizacion = item[5] == DBNull.Value ? Convert.ToDateTime("01-01-0001") : Convert.ToDateTime(item[5]);

                    lstUsuarios.Add(objUsuarios);
                }
            }
            return lstUsuarios;
        }

        [HttpPost("usuarios/insertar")]
        public bool InsertarUsuario(UsuariosModel objUsuario)
        {
            bool dsUsuarios = ConexionBD.Consultas("INSERT INTO Usuarios(nombre,email,fecha_registro,activo) VALUES('" + objUsuario.nombre + "', '" + objUsuario.email + "', GETDATE(),1)");

            return dsUsuarios;
        }

        [HttpGet("usuarios/ObtenerUsuario")]
        public UsuariosModel ObtenerUsuario(int id)
        {
            UsuariosModel objUsuarios = new UsuariosModel();
            DataSet dsUsuarios = ConexionBD.ListarUsuarios("SELECT * FROM Usuarios WHERE id_usuario = '" + id + "' ");

            if (dsUsuarios.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow item in dsUsuarios.Tables[0].Rows)
                {
                    objUsuarios.id_usuario = Convert.ToInt32(item[0]);
                    objUsuarios.nombre = Convert.ToString(item[1]);
                    objUsuarios.email = Convert.ToString(item[2]);
                    objUsuarios.fecha_registro = Convert.ToDateTime(item[3]);
                    objUsuarios.activo = Convert.ToBoolean(item[4]);
                    objUsuarios.activo = Convert.ToBoolean(item[4]);
                }
            }
            return objUsuarios;
        }

        [HttpPut("usuarios/editar")]
        public bool EditarUsuario(UsuariosModel objUsuario)
        {
            bool dsUsuarios = ConexionBD.Consultas("UPDATE Usuarios SET nombre = '" + objUsuario.nombre + "', email = '" + objUsuario.email + "', fecha_registro = '" + objUsuario.fecha_registro.ToString("yyyy-MM-dd HH:mm:ss") + "', fecha_actualizacion = GETDATE(), activo = '" + objUsuario.activo + "' WHERE id_usuario = " + objUsuario.id_usuario + " ");

            return dsUsuarios;
        }

        [HttpDelete("usuarios/eliminar")]
        public bool EliminarUsuario(int id)
        {
            bool result = false;
            if (id != 0)
            {
                result = ConexionBD.Consultas("DELETE FROM  Usuarios WHERE id_usuario = " + id + "");
            }
            return result;
        }
    }
}