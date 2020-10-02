using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sbsclearn.Models.Entities.ViewModels
{
    public class ScoresVM
    {
        public string UserName { get; set; }
        public string CourseName { get; set; }
        public Decimal Score { get; set; }
        public string CategoryName { get; set; }
    }

}
