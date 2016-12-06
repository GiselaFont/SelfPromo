using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Data
{
    public class Job
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }
        [Required]
        [MaxLength(100)]
        public string JobTitle { get; set; }
        [Required]
        [MaxLength(500)]
        public string JobDescription { get; set; }

        public bool IsProfessional { get; set; }

        public virtual ICollection<Jobhighlight> Jobhighlight { get; set; }

        public Job()
        {

        }
    }
}