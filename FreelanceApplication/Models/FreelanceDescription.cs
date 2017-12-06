using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FreelanceApplication.Models
{
    public class FreelanceDescription
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Поле обязательно")]
        public string CompanyName { get; set; }

        [Required(ErrorMessage = "Поле обязательно")]
        [EmailAddress]
        public string ContactEmail { get; set; }

        [Required(ErrorMessage = "Поле обязательно")]
        public string City { get; set; }

        [Required(ErrorMessage = "Поле обязательно")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Поле обязательно")]
        [MinLength(10, ErrorMessage = "Минимальное количество символов = 10")]
        public string Description { get; set; }

        [Required]
        [RegularExpression(@"[0-9,.]+",ErrorMessage = "Поле должно содержать только цифры и/или точку")]
        public string Price { get; set; }

        [Required]
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set; }

    }
}