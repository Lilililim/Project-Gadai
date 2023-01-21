using Microsoft.EntityFrameworkCore;
using ProjectGadai.API.Models;

namespace ProjectGadai.API.Data
{
    public class ProjectGadaiDbContext : DbContext
    {
        public ProjectGadaiDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
    }
}
