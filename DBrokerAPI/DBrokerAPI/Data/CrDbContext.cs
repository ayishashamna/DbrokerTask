using System;
using DBrokerAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace DBrokerAPI.Data
{
    public class CrDbContext:DbContext
    {
        public CrDbContext(DbContextOptions<CrDbContext> options) : base(options)
        {
        }
        public DbSet<CRData> CRDatas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }
    }
}
