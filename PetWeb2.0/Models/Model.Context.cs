﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PetWeb2._0.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class PetWebEntities : DbContext
    {
        public PetWebEntities()
            : base("name=PetWebEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<AtencionVeterinaria> AtencionVeterinaria { get; set; }
        public virtual DbSet<Contacto> Contacto { get; set; }
        public virtual DbSet<ControlDesparacitaciones> ControlDesparacitaciones { get; set; }
        public virtual DbSet<ControlVacuna> ControlVacuna { get; set; }
        public virtual DbSet<DueñoMascota> DueñoMascota { get; set; }
        public virtual DbSet<Especie> Especie { get; set; }
        public virtual DbSet<Mascota> Mascota { get; set; }
        public virtual DbSet<Raza> Raza { get; set; }
        public virtual DbSet<Sucursal> Sucursal { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Ubicacion> Ubicacion { get; set; }
        public virtual DbSet<Veterinaria> Veterinaria { get; set; }
        public virtual DbSet<NUEVAFICHA> NUEVAFICHA { get; set; }
        public virtual DbSet<VW_NuevaFicha> VW_NuevaFicha { get; set; }
        public virtual DbSet<ExamenClinico> ExamenClinico { get; set; }
        public virtual DbSet<VW_Atencion> VW_Atencion { get; set; }
    }
}
