﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Baixes_Desktop
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Anonims_Entities : DbContext
    {
        public Anonims_Entities()
            : base("name=Anonims_Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Acces> Acces { get; set; }
        public virtual DbSet<Adreces> Adreces { get; set; }
        public virtual DbSet<Festius> Festius { get; set; }
        public virtual DbSet<Groups> Groups { get; set; }
        public virtual DbSet<Locals> Locals { get; set; }
        public virtual DbSet<Mails> Mails { get; set; }
        public virtual DbSet<Obertes> Obertes { get; set; }
        public virtual DbSet<Sections> Sections { get; set; }
        public virtual DbSet<LatLon> LatLon { get; set; }
        public virtual DbSet<Contactes> Contactes { get; set; }
        public virtual DbSet<Servidors> Servidors { get; set; }
        public virtual DbSet<Transports> Transports { get; set; }
        public virtual DbSet<Horari> Horari { get; set; }
    }
}
