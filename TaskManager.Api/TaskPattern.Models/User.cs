using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskPattern.Models
{
    [Table("User")]
     public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Firstname { get; set; }

        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Lastname { get; set; }

    }
}


