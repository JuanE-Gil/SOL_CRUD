//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CRUD.Modelo
{
    using System;
    using System.Collections.Generic;
    
    public partial class TB_MEDIDAS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TB_MEDIDAS()
        {
            this.TB_PRODUCTOS = new HashSet<TB_PRODUCTOS>();
        }
    
        public int codigo_me { get; set; }
        public string descripcion_me { get; set; }
        public bool activo { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TB_PRODUCTOS> TB_PRODUCTOS { get; set; }
    }
}
