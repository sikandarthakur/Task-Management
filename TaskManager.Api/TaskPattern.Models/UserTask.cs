using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskPattern.Models
{
    [Table("UserTask")]
    public class UserTask
    {
        [Key]
        public int TaskId { get; set; }

      
        [Column(TypeName = "varchar(200)")]
        public string TaskName { get; set; }

      
        [Column(TypeName = "varchar(500)")]
        public string TaskDescription { get; set; }

       
        [Column(TypeName = "datetime")]
        public DateTime StartDate{ get; set; }

   
        [Column(TypeName = "datetime")]
        public DateTime EndDate { get; set; }

        [Column(TypeName = "bit")]
        public bool IsOpen { get; set; }

        [Column(TypeName = "varchar(20)")]
        public string Status { get; set; }

        public virtual User user { get; set; }
    }

}
