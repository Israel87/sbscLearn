using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sbsclearn.Models.Entities
{
    public class UsersCourses
    {
      
            public int UserID { get; set; }
            public User User { get; set; }
            public int CourseID { get; set; }
            public Course Course { get; set; }
       
    }
}
