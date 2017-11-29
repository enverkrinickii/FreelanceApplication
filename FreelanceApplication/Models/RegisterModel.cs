using System;
using System.ComponentModel.DataAnnotations;

namespace FreelanceApplication.Models
{
    public class RegisterModel
    {
        [Required]
        [EmailAddress(ErrorMessage = "Не валидный email")]
        public string Email { get; set; }

        public DateTime RegisterDate { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string  Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        public bool IsFreelanser { get; set; }

    }
}