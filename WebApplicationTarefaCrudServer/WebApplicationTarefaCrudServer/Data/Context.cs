using Microsoft.EntityFrameworkCore;
using WebApplicationTarefaCrudServer.Entities;

namespace WebApplicationTarefaCrudServer.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }
        public DbSet<Tarefa> Tarefa { get; set; }
    }
}
