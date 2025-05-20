using System.Reflection.Metadata;
using Microsoft.EntityFrameworkCore;

namespace MottuWebApplication.Connection
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
    }
}
