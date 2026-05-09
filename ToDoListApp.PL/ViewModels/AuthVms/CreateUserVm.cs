using System.ComponentModel.DataAnnotations;

namespace ToDoListApp.PL.ViewModels.AuthVms
{
    public class CreateUserVm
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 3)]
        [RegularExpression(
         @"^(?=.*[a-z])(?=.*[A-Z])[A-Za-z0-9]+$",
         ErrorMessage = "Username must contain uppercase and lowercase letters and no spaces.")
        ]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(100, MinimumLength = 8, ErrorMessage = "Password must be at least 8 characters.")]
        public string Password { get; set; }

        [Required]
        [Compare(nameof(Password), ErrorMessage = "Passwords do not match.")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}
