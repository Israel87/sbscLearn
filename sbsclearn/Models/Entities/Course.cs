using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace sbsclearn.Models.Entities
{
    public class Course
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public string Facilitator { get; set; }
        public decimal Duration { get; set; }
        public int UserId { get; set; }
        //public virtual User User { get; set; }
        public string FileUploadPath { get; set; }
        public DateTime DateCreated { get; set; }
        public ICollection<UsersCourses> UsersCourses { get; set; }
    }
}
