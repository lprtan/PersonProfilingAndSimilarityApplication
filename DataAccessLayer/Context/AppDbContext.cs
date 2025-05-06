using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<IndividualData> individualDatas { get; set; }
        public DbSet<ProfileData> profileDatas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProfileData>()
                .HasOne(p => p.Individual)
                .WithOne(i => i.Profile)
                .HasForeignKey<ProfileData>(p => p.IndividualId);
        }
    }
}
