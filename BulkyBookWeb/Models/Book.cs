using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BulkyBookWeb.Models
{
    public class Book
    {
        [Key]
        public int bId { get; set; }

        [DisplayName ("Book Name")]
        [Required]
        public string bName { get; set; }
        [DisplayName ("Book Author")]
        public string bAuthor { get; set; }
        [DisplayName ("No of Pages")]
        public int bNoOfPages { get; set; }
    }
}
