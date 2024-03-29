﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication3.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class PruebasEntities : DbContext
    {
        public PruebasEntities()
            : base("name=PruebasEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Pruebas_EMP> Pruebas_EMP { get; set; }
        public virtual DbSet<Pruebas_EmpleadosControlHoras> Pruebas_EmpleadosControlHoras { get; set; }
        public virtual DbSet<Pruebas_PRS> Pruebas_PRS { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
    
        [DbFunction("PruebasEntities", "Pruebas_CotrolHoras")]
        public virtual IQueryable<Pruebas_CotrolHoras_Result> Pruebas_CotrolHoras(Nullable<int> idEmpleado, Nullable<System.DateTime> desde, Nullable<System.DateTime> hasta)
        {
            var idEmpleadoParameter = idEmpleado.HasValue ?
                new ObjectParameter("IdEmpleado", idEmpleado) :
                new ObjectParameter("IdEmpleado", typeof(int));
    
            var desdeParameter = desde.HasValue ?
                new ObjectParameter("Desde", desde) :
                new ObjectParameter("Desde", typeof(System.DateTime));
    
            var hastaParameter = hasta.HasValue ?
                new ObjectParameter("Hasta", hasta) :
                new ObjectParameter("Hasta", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<Pruebas_CotrolHoras_Result>("[PruebasEntities].[Pruebas_CotrolHoras](@IdEmpleado, @Desde, @Hasta)", idEmpleadoParameter, desdeParameter, hastaParameter);
        }
    
        [DbFunction("PruebasEntities", "Pruebas_SoloUnEmpleado")]
        public virtual IQueryable<Pruebas_SoloUnEmpleado_Result> Pruebas_SoloUnEmpleado(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<Pruebas_SoloUnEmpleado_Result>("[PruebasEntities].[Pruebas_SoloUnEmpleado](@Id)", idParameter);
        }
    
        [DbFunction("PruebasEntities", "Pruebas_TodosEmpleados")]
        public virtual IQueryable<Pruebas_TodosEmpleados_Result> Pruebas_TodosEmpleados()
        {
            return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<Pruebas_TodosEmpleados_Result>("[PruebasEntities].[Pruebas_TodosEmpleados]()");
        }
    
        [DbFunction("PruebasEntities", "Pruebas_TraerPuestos")]
        public virtual IQueryable<Pruebas_TraerPuestos_Result> Pruebas_TraerPuestos()
        {
            return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<Pruebas_TraerPuestos_Result>("[PruebasEntities].[Pruebas_TraerPuestos]()");
        }
    
        public virtual int Pruebas_CrearEmpleado(string nombreEmpleado, Nullable<int> edadEmpleado, string sexoEmpleado, Nullable<int> idPuesto, byte[] fotografiaEmpleado)
        {
            var nombreEmpleadoParameter = nombreEmpleado != null ?
                new ObjectParameter("NombreEmpleado", nombreEmpleado) :
                new ObjectParameter("NombreEmpleado", typeof(string));
    
            var edadEmpleadoParameter = edadEmpleado.HasValue ?
                new ObjectParameter("EdadEmpleado", edadEmpleado) :
                new ObjectParameter("EdadEmpleado", typeof(int));
    
            var sexoEmpleadoParameter = sexoEmpleado != null ?
                new ObjectParameter("SexoEmpleado", sexoEmpleado) :
                new ObjectParameter("SexoEmpleado", typeof(string));
    
            var idPuestoParameter = idPuesto.HasValue ?
                new ObjectParameter("IdPuesto", idPuesto) :
                new ObjectParameter("IdPuesto", typeof(int));
    
            var fotografiaEmpleadoParameter = fotografiaEmpleado != null ?
                new ObjectParameter("FotografiaEmpleado", fotografiaEmpleado) :
                new ObjectParameter("FotografiaEmpleado", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("Pruebas_CrearEmpleado", nombreEmpleadoParameter, edadEmpleadoParameter, sexoEmpleadoParameter, idPuestoParameter, fotografiaEmpleadoParameter);
        }
    
        public virtual int Pruebas_EditarEmpleado(Nullable<int> id, string nombreEmpleado, Nullable<int> edadEmpleado, string sexoEmpleado, Nullable<int> idPuesto, byte[] fotografiaEmpleado, string extension)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(int));
    
            var nombreEmpleadoParameter = nombreEmpleado != null ?
                new ObjectParameter("NombreEmpleado", nombreEmpleado) :
                new ObjectParameter("NombreEmpleado", typeof(string));
    
            var edadEmpleadoParameter = edadEmpleado.HasValue ?
                new ObjectParameter("EdadEmpleado", edadEmpleado) :
                new ObjectParameter("EdadEmpleado", typeof(int));
    
            var sexoEmpleadoParameter = sexoEmpleado != null ?
                new ObjectParameter("SexoEmpleado", sexoEmpleado) :
                new ObjectParameter("SexoEmpleado", typeof(string));
    
            var idPuestoParameter = idPuesto.HasValue ?
                new ObjectParameter("IdPuesto", idPuesto) :
                new ObjectParameter("IdPuesto", typeof(int));
    
            var fotografiaEmpleadoParameter = fotografiaEmpleado != null ?
                new ObjectParameter("FotografiaEmpleado", fotografiaEmpleado) :
                new ObjectParameter("FotografiaEmpleado", typeof(byte[]));
    
            var extensionParameter = extension != null ?
                new ObjectParameter("Extension", extension) :
                new ObjectParameter("Extension", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("Pruebas_EditarEmpleado", idParameter, nombreEmpleadoParameter, edadEmpleadoParameter, sexoEmpleadoParameter, idPuestoParameter, fotografiaEmpleadoParameter, extensionParameter);
        }
    
        public virtual int Pruebas_EliminarEmpleado(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("Pruebas_EliminarEmpleado", idParameter);
        }
    
        public virtual int sp_alterdiagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_alterdiagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_creatediagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_creatediagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_dropdiagram(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_dropdiagram", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagramdefinition_Result> sp_helpdiagramdefinition(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagramdefinition_Result>("sp_helpdiagramdefinition", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagrams_Result> sp_helpdiagrams(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagrams_Result>("sp_helpdiagrams", diagramnameParameter, owner_idParameter);
        }
    
        public virtual int sp_renamediagram(string diagramname, Nullable<int> owner_id, string new_diagramname)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var new_diagramnameParameter = new_diagramname != null ?
                new ObjectParameter("new_diagramname", new_diagramname) :
                new ObjectParameter("new_diagramname", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_renamediagram", diagramnameParameter, owner_idParameter, new_diagramnameParameter);
        }
    
        public virtual int sp_upgraddiagrams()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_upgraddiagrams");
        }
    
        public virtual int Pruebas_SP_EditarEmpleado(Nullable<int> id, string nombreEmpleado, Nullable<int> edadEmpleado, string sexoEmpleado, Nullable<int> idPuesto)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(int));
    
            var nombreEmpleadoParameter = nombreEmpleado != null ?
                new ObjectParameter("NombreEmpleado", nombreEmpleado) :
                new ObjectParameter("NombreEmpleado", typeof(string));
    
            var edadEmpleadoParameter = edadEmpleado.HasValue ?
                new ObjectParameter("EdadEmpleado", edadEmpleado) :
                new ObjectParameter("EdadEmpleado", typeof(int));
    
            var sexoEmpleadoParameter = sexoEmpleado != null ?
                new ObjectParameter("SexoEmpleado", sexoEmpleado) :
                new ObjectParameter("SexoEmpleado", typeof(string));
    
            var idPuestoParameter = idPuesto.HasValue ?
                new ObjectParameter("IdPuesto", idPuesto) :
                new ObjectParameter("IdPuesto", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("Pruebas_SP_EditarEmpleado", idParameter, nombreEmpleadoParameter, edadEmpleadoParameter, sexoEmpleadoParameter, idPuestoParameter);
        }
    
        [DbFunction("PruebasEntities", "Pruebas_FN_TodosEmpleados")]
        public virtual IQueryable<Pruebas_FN_TodosEmpleados_Result> Pruebas_FN_TodosEmpleados()
        {
            return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<Pruebas_FN_TodosEmpleados_Result>("[PruebasEntities].[Pruebas_FN_TodosEmpleados]()");
        }
    
        [DbFunction("PruebasEntities", "Pruebas_FN_ControlHoras")]
        public virtual IQueryable<Pruebas_FN_ControlHoras_Result> Pruebas_FN_ControlHoras(Nullable<int> idEmpleado)
        {
            var idEmpleadoParameter = idEmpleado.HasValue ?
                new ObjectParameter("IdEmpleado", idEmpleado) :
                new ObjectParameter("IdEmpleado", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<Pruebas_FN_ControlHoras_Result>("[PruebasEntities].[Pruebas_FN_ControlHoras](@IdEmpleado)", idEmpleadoParameter);
        }
    
        [DbFunction("PruebasEntities", "Pruebas_FN_ImagenUnEmpleado")]
        public virtual IQueryable<Pruebas_FN_ImagenUnEmpleado_Result> Pruebas_FN_ImagenUnEmpleado(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<Pruebas_FN_ImagenUnEmpleado_Result>("[PruebasEntities].[Pruebas_FN_ImagenUnEmpleado](@Id)", idParameter);
        }
    }
}
