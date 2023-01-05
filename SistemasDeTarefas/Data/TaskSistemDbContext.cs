using Microsoft.EntityFrameworkCore;
using SistemasDeTarefas.Data.Map;
using SistemasDeTarefas.Models;

namespace SistemasDeTarefas.Data
{
    public class TaskSistemDBContext : DbContext
    {
        public TaskSistemDBContext(DbContextOptions<TaskSistemDBContext> options) : base(options)
        {

        }
        public DbSet<UserModel> Users { get; set; }   
        public DbSet<TaskModel> TaskModels { get; set; } 

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new TaskMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
