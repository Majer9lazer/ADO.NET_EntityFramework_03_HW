namespace ADO.NET_EntityFramework_03_HW.GetDataFromEquipmentAndMore
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class MCS : DbContext
    {
        public MCS()
            : base("name=MCS")
        {
        }

        public virtual DbSet<newEquipment> newEquipments { get; set; }
        public virtual DbSet<TablesManufacturer> TablesManufacturers { get; set; }
        public virtual DbSet<TablesModel> TablesModels { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TablesManufacturer>()
                .HasMany(e => e.newEquipments)
                .WithRequired(e => e.TablesManufacturer)
                .WillCascadeOnDelete(false);
        }
    }
}
