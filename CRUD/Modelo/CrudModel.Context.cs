﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class CrudEntities : DbContext
    {
        public CrudEntities()
            : base("name=CrudEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<TB_CATEGORIAS> TB_CATEGORIAS { get; set; }
        public virtual DbSet<TB_MEDIDAS> TB_MEDIDAS { get; set; }
        public virtual DbSet<TB_PRODUCTOS> TB_PRODUCTOS { get; set; }
    
        public virtual ObjectResult<USP_LISTADO_CA_Result> USP_LISTADO_CA()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<USP_LISTADO_CA_Result>("USP_LISTADO_CA");
        }
    
        public virtual ObjectResult<USP_LISTADO_ME_Result> USP_LISTADO_ME()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<USP_LISTADO_ME_Result>("USP_LISTADO_ME");
        }
    
        public virtual ObjectResult<USP_LISTADO_PR_Result> USP_LISTADO_PR(string cTexto)
        {
            var cTextoParameter = cTexto != null ?
                new ObjectParameter("cTexto", cTexto) :
                new ObjectParameter("cTexto", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<USP_LISTADO_PR_Result>("USP_LISTADO_PR", cTextoParameter);
        }
    }
}
