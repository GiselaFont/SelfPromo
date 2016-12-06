using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication2.Data
{
    public class Jobhighlight
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(255)]
        public string Description { get; set; }
        [Required]
        
        public int JobId { get; set; }

        [ForeignKey("JobId")]
        public virtual Job Job { get; set; }

        public Jobhighlight()
        {

        }
    }
}