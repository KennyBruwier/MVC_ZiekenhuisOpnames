using Microsoft.EntityFrameworkCore;
using MVC_ZiekenhuisOpnames.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_ZiekenhuisOpnames.Database
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Patient>()
                .HasOne(s => s.ImgVoorkant)
                .WithMany()
                .HasForeignKey(s => s.ImgVoorkantId)
                .OnDelete(DeleteBehavior.ClientCascade);

            modelBuilder.Entity<Patient>()
                .HasOne(s => s.ImgAchterkant)
                .WithMany()
                .HasForeignKey(s => s.ImgAchterkantId)
                .OnDelete(DeleteBehavior.ClientCascade);
            //base.OnModelCreating(modelBuilder);
        }
        public DbSet<Patient>Patients { get; set; }
        public DbSet<IDImage>IDImages { get; set; }
    }
}
