using ApiTodo.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiTodo.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Todo> Todos { get; set; }
    }
}
