//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Control_InventarioAPI.App_Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class CAT_Productos
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CAT_Productos()
        {
            this.Bitacora_Productos = new HashSet<Bitacora_Productos>();
        }
    
        public int intProductoID { get; set; }
        public Nullable<int> intTipoProductoID { get; set; }
        public string vchNombreProducto { get; set; }
        public Nullable<decimal> decPrecioProducto { get; set; }
        public Nullable<System.DateTime> datFechaAltaProducto { get; set; }
        public Nullable<int> intUsuarioAltaProducto { get; set; }
        public bool boolEstatusProducto { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Bitacora_Productos> Bitacora_Productos { get; set; }
        public virtual CAT_TipoProducto CAT_TipoProducto { get; set; }
        public virtual CAT_Usuarios CAT_Usuarios { get; set; }
    }
}