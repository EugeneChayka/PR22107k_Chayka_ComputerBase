﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Registration.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class CompBaseEntities : DbContext
    {
        public CompBaseEntities()
            : base("name=CompBaseEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Clientele> Clientele { get; set; }
        public virtual DbSet<Deliveries> Deliveries { get; set; }
        public virtual DbSet<Employeey> Employeey { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<Post> Post { get; set; }
        public virtual DbSet<Product_Categories> Product_Categories { get; set; }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<Sborka> Sborka { get; set; }
        public virtual DbSet<Suppliers> Suppliers { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<TypeTovara> TypeTovara { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<Warehouses> Warehouses { get; set; }
    }
}
