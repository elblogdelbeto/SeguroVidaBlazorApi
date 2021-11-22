using SegurosBlazorApp.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace APImaxillc.Data
{
    public class APIcontext : DbContext
    {

        public APIcontext(DbContextOptions<APIcontext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            IConfigurationRoot Configuration = new ConfigurationBuilder().SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();

            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
        }

        public DbSet<Persona> Persona { get; set; } = null!;
        public DbSet<Empleado> Empleado { get; set; } = null!;
        public DbSet<Beneficiario> Beneficiario { get; set; } = null!;

    }
}
