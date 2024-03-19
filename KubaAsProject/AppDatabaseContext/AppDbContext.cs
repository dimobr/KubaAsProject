using Microsoft.EntityFrameworkCore;
using KubaAsProject.Models;

namespace KubaAsProject.AppDatabaseContext
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet<WarehouseOwner> WarehouseOwners { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Inventory> Inventory { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Warehouse>()
                .HasOne(warehouse => warehouse.Owner)
                .WithMany(owner => owner.Warehouses)
                .HasForeignKey(warehouse => warehouse.OwnerId);

            modelBuilder.Entity<WarehouseOwner>()
                .HasMany(owner => owner.Warehouses);

            modelBuilder.Entity<Inventory>()
                .HasOne(inventory => inventory.Item)
                .WithMany()
                .HasForeignKey(Inventory => Inventory.ItemId);

            modelBuilder.Entity<Item>();

            modelBuilder.Entity<Inventory>()
                .HasOne(inventory => inventory.Warehouse)
                .WithMany()
                .HasForeignKey(Inventory => Inventory.WarehouseId);

            modelBuilder.Entity<Warehouse>().HasData(SeedInitialWarehouseData());
            modelBuilder.Entity<WarehouseOwner>().HasData(SeedInitialWarehouseOwneryData());
            modelBuilder.Entity<Item>().HasData(SeedInitialWarehouseItemData());
            modelBuilder.Entity<Inventory>().HasData(SeedInitialInventoryData());
        }

        private static Warehouse SeedInitialWarehouseData()
        {
            return new Warehouse()
            {
                Id = 1,
                Name = "Main Warehouse",
                Location = "Kirkeveien 85, 1344 Haslum, Bærum, Norge",
                Capacity = 99,
                OwnerId = 1
            };
        }

        private static WarehouseOwner SeedInitialWarehouseOwneryData()
        {
            return new WarehouseOwner()
            {
                Id = 1,
                Name = "Warehouse Company Inc",
                IsBusiness = true,
                ContactPerson = "Dimitrije Obradovic",
                EmailAddress = "dimitrije.obradovic@warehouse.com",
                PhoneNumber = "91153390",
                Street = "Kirkeveien 85A",
                PostalCode = "1344",
                City = "Haslum",
                Region = "Bærum",
                Country = "Norway"
            };
        }
        private static Item SeedInitialWarehouseItemData()
        {
            return new Item()
            {
                Id = 1,
                ItemName = "Washing machine 5kg",
                ItemDescription = "Efficient washing machine with a capacity of 5kg and an ultra rapid program - only 15 minutes!",
                ItemPriceWithCurrency = "EUR 499.90"
            };
        }

        private static Inventory SeedInitialInventoryData()
        {
            return new Inventory()
            {
                Id=1,
                WarehouseId = 1,  
                ItemId = 1,
                ItemQuantity = 3
            };
        }
    }
}