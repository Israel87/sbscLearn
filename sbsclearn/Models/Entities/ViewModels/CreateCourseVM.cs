using Microsoft.AspNetCore.Http;
using sbsclearn.Models.Entities;
using sbsclearn.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace sbsclearn.Models.ViewModels
{
    public class CreateCourseVM
    {
        [Required]
        public string CourseName { get; set; }
        [Required]
        public string Facilitator { get; set; }
        [Required]
        public decimal Duration { get; set; }
        [Required]
        public float Cost { get; set; }
        [Required]
        public string CourseDetails { get; set; }
        [Required]
        public Category? Categories { get; set; }
        public IFormFile Path { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
