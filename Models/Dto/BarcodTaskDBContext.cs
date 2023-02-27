using Microsoft.EntityFrameworkCore;

namespace WebApplication2.Models
{
    public partial class BarcodTaskDBContext : DbContext
    {
        public BarcodTaskDBContext(string databaseConnection): base()
        {
            ConnectionString = databaseConnection;
        }

        public string ConnectionString { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);
        }

    }
}
