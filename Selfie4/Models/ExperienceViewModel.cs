using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Selfie4.Data;
using WebApplication2.Data;

namespace WebApplication2.Models
{
    public class ExperienceViewModel
    {
        public List<Job> ProfessionalJob { get; set; } = new List<Job>();
        public List<Job> Activities { get; set; }  = new List<Job>();

    }
}