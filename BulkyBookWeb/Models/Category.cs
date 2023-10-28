using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BulkyBookWeb.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DisplayName("Name")]
        public string name { get; set; }
        [DisplayName("Display Order")]
        [Range(1,100, ErrorMessage = "Order Must be between 1 and 100 Only")]
        public int DisplayOrder { get; set; }
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
    }
}
