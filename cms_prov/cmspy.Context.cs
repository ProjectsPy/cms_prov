﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace cms_prov
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class cms_pyEntities : DbContext
    {
        public cms_pyEntities()
            : base("name=cms_pyEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<ImgProduct> ImgProducts { get; set; }
        public virtual DbSet<product> products { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Marca> Marcas { get; set; }
        public virtual DbSet<Moneda> Monedas { get; set; }
    }
}
