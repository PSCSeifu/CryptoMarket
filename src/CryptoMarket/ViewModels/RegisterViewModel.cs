using System.ComponentModel.DataAnnotations;

namespace CryptoMarket.ViewModels
{
    public class RegisterViewModel
    {
        [Required,MaxLength(256)]
        public string Username  { get; set; }

        [Required,MaxLength(256)]
        public string Email { get; set; }

        [Required, DataType(DataType.Password)]
        public string Password { get; set; }

        [Required, DataType(DataType.Password), Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }

        [Required]
        public Enums.Enums.WebUserType WebUserType { get; set; }
    }
}
