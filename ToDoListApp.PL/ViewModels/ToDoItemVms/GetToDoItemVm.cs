using ToDoListApp.DAL.Enums;

namespace ToDoListApp.PL.ViewModels.ToDoItemVms
{
    public class GetToDoItemVm
    {
        public int Id { get; set; }

        public string Title { get; set; } = null!;

        public string? Description { get; set; }

        public bool IsCompleted { get; set; } = false;
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        public Priority Priority { get; set; } = Priority.High;

        public int CategoryId { get; set; }

        public GetCategoryVm? Category { get; set; }
    }
}
