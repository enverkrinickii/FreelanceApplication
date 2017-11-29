using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FreelanceApplication.Models
{
    public class FreelanceDescription
    {
        public int Id { get; set; }

        [Required]
        public string CompanyName { get; set; }

        [Required]
        [EmailAddress]
        public string ContactEmail { get; set; }

        [Required]
        public string City { get; set; }

        [Required(ErrorMessage = "Field is required")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Field is required")]
        [MinLength(10, ErrorMessage = "10 is min amount of characters")]
        public string Description { get; set; }

        [Required]
        public string Price { get; set; }

        [Required]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

    }
}