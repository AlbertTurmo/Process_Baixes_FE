﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Sql_Data
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class orior_production_entities : DbContext
    {
        public orior_production_entities()
            : base("name=orior_production_entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Empleado> Empleado { get; set; }
        public virtual DbSet<LogPBajasA> LogPBajasA { get; set; }
        public virtual DbSet<Exports> Exports { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }
    }
}