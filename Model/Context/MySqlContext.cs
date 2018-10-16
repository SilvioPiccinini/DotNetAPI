using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;

namespace DotNetAPI.Model.Context
{
    public class MySqlContext : DbContext
    {
        public MySqlContext()
        {
        }

        public MySqlContext(DbContextOptions<MySqlContext> options) : base(options) { }

        public DbSet<Person> People { get; set; }

    }
}
