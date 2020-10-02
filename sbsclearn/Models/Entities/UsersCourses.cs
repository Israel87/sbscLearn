using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace sbsclearn.Models.Entities
{
    public class UsersCourses
    {
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int UserCourseId { get; set; }
            public virtual ApplicationUser UserInfo { get; set; }
            public int CourseID { get; set; }
            public Course Course { get; set; }
            public decimal CourseScore { get; set; }


    }
}
