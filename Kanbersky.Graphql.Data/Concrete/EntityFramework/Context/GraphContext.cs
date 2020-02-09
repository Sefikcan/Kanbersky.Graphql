using Kanbersky.Graphql.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace Kanbersky.Graphql.Data.Concrete.EntityFramework.Context
{
    public class GraphContext : DbContext
    {
        public GraphContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; }
    }
}
