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
        public DbSet<Patient>Patients { get; set; }
    }
}
