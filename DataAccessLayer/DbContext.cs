using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Entity;

namespace DataAccessLayer
{
    public class DALDbContext : DbContext
    {
        public string connectionString { get; set; } = "Server=localhost;Port=5432;User Id=postgres;Password=postgres;Database=postgres;";
        public DbSet<Post> Posts { get; set; }

        public DALDbContext() : base("name=PostgreSQLConnection")
        {
        }
    }
}
