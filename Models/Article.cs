using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RazorEntity.Models
{
    [Table("Article")]
    public class Article
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(250)]
        [Column(TypeName = "nvarchar")]
        public string Title { get; set; }

        [DataType(DataType.Date)]
        [Required]
        public DateTime CreatedDate { get; set; }

        [Column(TypeName = "ntext")]
        public string Content { get; set; }
    }
}
