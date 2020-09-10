using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace sbsclearn.Models.Entities
{
    public class CourseAttempt
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CourseAttemptId { get; set; }
        public int UserId { get; set; }
        //public virtual User User { get; set; }
        public int CourseId { get; set; }
        // public virtual Course Course { get; set; }
    }
}
