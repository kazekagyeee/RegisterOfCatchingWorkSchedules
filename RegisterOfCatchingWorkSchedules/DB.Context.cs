﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RegisterOfCatchingWorkSchedules
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class RegisterOfCathingWorkSchedulesEntities : DbContext
    {
        public RegisterOfCathingWorkSchedulesEntities()
            : base("name=RegisterOfCathingWorkSchedulesEntities")
        {
            /*this.Configuration.LazyLoadingEnabled = false;*/
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Municipality> Municipality { get; set; }
        public virtual DbSet<Organisation> Organisation { get; set; }
        public virtual DbSet<Places> Places { get; set; }
        public virtual DbSet<Plans> Plans { get; set; }
        public virtual DbSet<Records> Records { get; set; }
        public virtual DbSet<RolePowers> RolePowers { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<Statuses> Statuses { get; set; }
        public virtual DbSet<StatusHistory> StatusHistory { get; set; }
        public virtual DbSet<Users> Users { get; set; }
    }
}
