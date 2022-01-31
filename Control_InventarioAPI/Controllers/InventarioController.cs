using Control_InventarioAPI.App_Data;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Control_InventarioAPI.Controllers
{
    [RoutePrefix("api/inventario")]
    public class InventarioController : ApiController
    {
        [HttpPost]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [Route("catalogoTipoProducto")]
        public object catalogoTipoProducto([FromBody] JObject data)
        {
            using (var conexion = new Control_InventarioEntities())
            {
                var catalogo = conexion.CAT_TipoProducto.Select(r => new { r.intTipoProductoID, r.vchNombreTipoProducto }).ToList();
                return catalogo;
            }
        }

        [HttpPost]
        [EnableCors(origins: "*", headers:"*", methods:"*")]
        [Route("listaProductos")]
        public object listaProductos([FromBody] JObject data)
        {
            string nombre = data["nombre"].ToObject<string>();
            int tipo = data["tipo"].ToObject<int>();
            using (var conexion = new Control_InventarioEntities())
            {
                var catalogo = conexion.CAT_Productos.Where(r => (tipo == 0 || r.intTipoProductoID == tipo)
                && (nombre == string.Empty || r.vchNombreProducto.Contains(nombre))
                ).Select(r => new
                {
                    r.vchNombreProducto,
                    r.intTipoProductoID,
                    r.CAT_TipoProducto.vchNombreTipoProducto,
                    r.intProductoID,
                    r.decPrecioProducto,
                    r.datFechaAltaProducto,
                    r.CAT_Usuarios.vchNombreUsuario,
                    r.boolEstatusProducto
                }).ToList();
                return catalogo;
            }
        }

        [HttpPost]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [Route("AgregarProducto")]
        public object AgregarProducto([FromBody] JObject data)
        {
            //{
            //    "producto": {
            //        "vchNombreProducto": "nombre desde front",
            //        "boolEstatusProducto": "1",
            //        "decPrecioProducto":  "123.12",
            //        "intTipoProductoID": "1" 
            //    },
            //    "usuarioAlta": "1"
            //}
            CAT_Productos producto = data["producto"].ToObject<CAT_Productos>();
            int usuarioAlta = data["usuarioAlta"].ToObject<int>();
            using (var conexion = new Control_InventarioEntities())
            {
                if (conexion.CAT_Productos.Any(p => p.vchNombreProducto == producto.vchNombreProducto))
                {
                    return new
                    {
                        valido = false,
                        Detalle = "Un producto ya existe con el mismo nombre"
                    };
                }
                else
                {
                    producto.intTipoProductoID = producto.intTipoProductoID;
                    producto.boolEstatusProducto = true;
                    producto.datFechaAltaProducto = DateTime.Now;
                    producto.intUsuarioAltaProducto = usuarioAlta;
                    conexion.CAT_Productos.Add(producto);
                    conexion.SaveChanges();
                    return new
                    {
                        valido = true,
                        Detalle = "Producto agregado correctamente"
                    };
                }
            }
        }

        [HttpPost]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [Route("ActualizarProducto")]
        public object ActualizarProducto([FromBody] JObject data)
        {
            //{
            //    "producto": {
            //        "intProductoID":  "1",
            //        "vchNombreProducto": "nombre desde front",
            //        "boolEstatusProducto": "1",
            //        "decPrecioProducto":  "123.12",
            //        "intTipoProductoID": "1" 
            //    },
            //    "usuarioAlta": "1"
            //}

            CAT_Productos producto = data["producto"].ToObject<CAT_Productos>();
            int usuarioAlta = data["usuarioAlta"].ToObject<int>();
            using (var conexion = new Control_InventarioEntities())
            {
                if (conexion.CAT_Productos.Any(p => p.intProductoID == producto.intProductoID))
                {
                    if (conexion.CAT_Productos.Any(p => p.intProductoID != producto.intProductoID && p.vchNombreProducto == producto.vchNombreProducto))
                    {
                        return new
                        {
                            valido = false,
                            Detalle = "Un producto ya existe con el mismo nombre"
                        };
                    }
                    else
                    {
                        var productoBase = conexion.CAT_Productos.FirstOrDefault(p => p.intProductoID == producto.intProductoID);
                        //productoBase.boolEstatusProducto = producto.boolEstatusProducto;
                        productoBase.datFechaAltaProducto = DateTime.Now;
                        productoBase.decPrecioProducto = producto.decPrecioProducto;
                        productoBase.intTipoProductoID = producto.intTipoProductoID;
                        productoBase.intUsuarioAltaProducto = usuarioAlta;
                        productoBase.vchNombreProducto = producto.vchNombreProducto;
                        conexion.SaveChanges();
                        return new
                        {
                            valido = true,
                            Detalle = "Producto actualizado correctamente"
                        };
                    }
                }
                else
                {
                    return new { valido = false, Detalle = "El producto no existe." };
                }
            }
        }

        [HttpPost]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [Route("ActualizarEstatusProducto")]
        public object ActualizarEstatusProducto([FromBody] JObject data)
        {
            ////{
            ////    "productoID":"",
            ////    "usuarioAlta":""
            ////}
            int intProductoID = data["productoID"].ToObject<int>();
            int usuarioAlta = data["usuarioAlta"].ToObject<int>();
            using (var conexion = new Control_InventarioEntities())
            {
                if (conexion.CAT_Productos.Any(p => p.intProductoID == intProductoID))
                {
                    var productoBase = conexion.CAT_Productos.FirstOrDefault(p => p.intProductoID == intProductoID);
                    productoBase.datFechaAltaProducto = DateTime.Now;
                    productoBase.intUsuarioAltaProducto = usuarioAlta;
                    productoBase.boolEstatusProducto = !productoBase.boolEstatusProducto;
                    conexion.SaveChanges();
                    return new
                    {
                        valido = true,
                        Detalle = "Producto actualizado correctamente"
                    };
                }
                else
                {
                    return new { valido = false, Detalle = "El producto no existe." };
                }
            }
        }
    }
}