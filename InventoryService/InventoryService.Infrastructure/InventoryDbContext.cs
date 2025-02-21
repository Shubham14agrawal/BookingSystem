using Microsoft.EntityFrameworkCore;
using InventoryService.Domain.Models;
using System.Collections.Generic;

namespace InventoryService.Infrastructure
{
    public class InventoryDbContext : DbContext
    {
        public InventoryDbContext(DbContextOptions<InventoryDbContext> options) : base(options) { }
        public DbSet<Member> Members { get; set; } 
        public DbSet<Inventory> Inventories { get; set; }
    }
}
