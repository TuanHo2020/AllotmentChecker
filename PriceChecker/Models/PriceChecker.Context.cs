﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PriceChecker.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class PriceCheckerEntities : DbContext
    {
        public PriceCheckerEntities()
            : base("name=PriceCheckerEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<ElementLabel> ElementLabels { get; set; }
        public virtual DbSet<WebAction> WebActions { get; set; }
        public virtual DbSet<AllotmentRecord> AllotmentRecords { get; set; }
        public virtual DbSet<RoomType> RoomTypes { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<AllotmentRoomType> AllotmentRoomTypes { get; set; }
        public virtual DbSet<ContractRoom> ContractRooms { get; set; }
        public virtual DbSet<Hotel> Hotels { get; set; }
    }
}
