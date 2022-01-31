using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Control_InventarioAPI.App_Data;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Control_InventarioAPI.Controllers
{
    [RoutePrefix("api/acceso")]
    
    public class AccesoController : ApiController
    {
        [HttpPost]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [Route("loginAcceso")]
        public object loginAcceso([FromBody] JObject data)
        {
            object respuesta = new
            {
                acceso = false,
                respuesta = "",
                usuario = new
                {
                    id = 0,
                    nombre = "",
                    usuario = ""
                }
            };

            //logica de acceso
            string usuario = data["usuario"].ToObject<string>();
            string password = data["password"].ToObject<string>();
            using (var conexion = new Control_InventarioEntities())
            {
                if(conexion.CAT_Usuarios.Any(x => x.vchUserUsuario == usuario && x.vchPassUsuario == password))
                {
                    var usuarioDB = conexion.CAT_Usuarios.FirstOrDefault(x => x.vchUserUsuario == usuario && x.vchPassUsuario == password);
                    respuesta = new
                    {
                        acceso = true,
                        respuesta = "Login correcto",
                        usuario = new
                        {
                            id = usuarioDB.intUsuarioID,
                            nombre = usuarioDB.vchNombreUsuario + " " + usuarioDB.vchApellidoUsuario,
                            usuario = usuarioDB.vchUserUsuario
                        }
                    };
                }
                else
                {
                    respuesta = new
                    {
                        acceso = false,
                        respuesta = "No existe el usuario"
                    };
                }
            }

            return respuesta;
        }
    }
}