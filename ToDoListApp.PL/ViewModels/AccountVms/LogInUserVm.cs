using System.ComponentModel.DataAnnotations;

namespace ToDoListApp.PL.ViewModels.AccountVms
{
    public class LogInUserVm
    {
        [Required(ErrorMessage = "Username is required.")]
        [StringLength(20,
            MinimumLength = 3,
            ErrorMessage = "Username must be between 3 and 20 characters.")]
        [RegularExpression(
            @"^(?=.*[a-z])(?=.*[A-Z])[A-Za-z0-9]+$",
            ErrorMessage = "Username must contain at least one uppercase letter, one lowercase letter, and only letters or numbers.")]
        public string UserName { get; set; } = null!;

        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        [StringLength(100,
            MinimumLength = 8,
            ErrorMessage = "Password must be at least 8 characters.")]
        [RegularExpression(
            @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).+$",
            ErrorMessage = "Password must contain at least one uppercase letter, one lowercase letter, and one number.")]
        public string Password { get; set; } = null!;
    }
}
