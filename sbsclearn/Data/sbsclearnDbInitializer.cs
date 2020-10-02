using Microsoft.EntityFrameworkCore;
using sbsclearn.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sbsclearn.Data.Migrations
{
    public static class sbsclearnDbInitializer
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>().HasData(
                new Course
                {
                    CourseId = 1,
                    CourseName = "Programming in C#",
                    Facilitator = "Samuel Babalola",
                   // UserId = 1,
                    Duration = 20,
                    FileUploadPath = "C:\\Users\\innaji\\source\\repos\\sbsclearn\\sbsclearn\\FileUploads",
                    DateCreated = DateTime.Now
                }
            );

            modelBuilder.Entity<User>().HasData(
               new User
               {
                   UserID = 1,
                   FirstName = "Israel",
                   LastName = "Nnaji",
                   Username = "nnajiisrael@gmail.com",
                   Password = "jesh112@PN"

               }
           );

            modelBuilder.Entity<CourseAttempt>().HasData(
             new CourseAttempt
             {
                 CourseAttemptId = 1,
                 CourseId = 1,
                 UserId = 1
             }
         );
        }
    }
}
