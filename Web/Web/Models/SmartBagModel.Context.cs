﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Web.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class SmartBagEntities : DbContext
    {
        public SmartBagEntities()
            : base("name=SmartBagEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<TBT_USUARIO> TBT_USUARIO { get; set; }
        public virtual DbSet<Drivers> Drivers { get; set; }
        public virtual DbSet<TD> TD { get; set; }
    }
}