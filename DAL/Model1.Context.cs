﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class GYM2Entities : DbContext
    {
        public GYM2Entities()
            : base("name=GYM2Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<ADMIN> ADMINs { get; set; }
        public virtual DbSet<GOITAP> GOITAPs { get; set; }
        public virtual DbSet<HOADON> HOADONs { get; set; }
        public virtual DbSet<HOCVIEN> HOCVIENs { get; set; }
        public virtual DbSet<LICH_HOC> LICH_HOC { get; set; }
        public virtual DbSet<PT> PTs { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<THIETBI> THIETBIs { get; set; }
        public virtual DbSet<THONGKE> THONGKEs { get; set; }
        public virtual DbSet<USER> USERS { get; set; }
    }
}
