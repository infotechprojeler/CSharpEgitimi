﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WindowsFormsApp2EFDBFirst
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class AdoNetDbEntities : DbContext
    {
        public AdoNetDbEntities() // AdoNetDbEntities ef ile veritabanı işlemleri yapabilmemiz için kullanacağımız nesne sınıfı
            : base("name=AdoNetDbEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
        // Aşağıdaki db set ler veri tabanı tablolarımızı temsile eder
        public virtual DbSet<Kategoriler> Kategoriler { get; set; }
        public virtual DbSet<Kullanicilar> Kullanicilar { get; set; }
        public virtual DbSet<Urunler> Urunler { get; set; }
    }
}