namespace SistemasDeTarefas.Models
{
    public class TaskModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public TaskStatus Status { get; set; } 
        public int? UserId { get; set; }
        
        public virtual UserModel? UserModel { get; set; }
    }
}
