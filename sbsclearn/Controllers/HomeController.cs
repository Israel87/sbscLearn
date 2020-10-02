using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using sbsclearn.Data;
using sbsclearn.Models;
using sbsclearn.Models.Entities.ViewModels;

namespace sbsclearn.Controllers
{
    public class HomeController : Controller
    {
        private readonly sbsclearnDbContext _context;
        public HomeController(sbsclearnDbContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            var _courses = _context.Course.ToList().OrderByDescending(t => t.DateCreated).Take(4);
            ViewData["courses"] = _courses;

            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        //public IActionResult Contact()
        //{
        //    ViewData["Message"] = "Your contact page.";

        //    return View();
        //}
        public IActionResult Score()
        {
            var _userScores = _context.UsersCourses.ToList();
            var _appUsers = _context.Users.ToList();
            var _courses = _context.Course.ToList();

            var queryList = from courses in _courses
                            join userScores in _userScores on courses.CourseId equals userScores.CourseID
                            join appUsers in _appUsers on userScores.UserInfo.Id equals appUsers.Id
                            select new
                            {
                                appUsers.UserName,
                                userScores.CourseScore,
                                userScores.Course.CourseName,
                                courses.Categories
                            };

            var query = queryList.OrderByDescending(t => t.CourseScore).ToList();

            IList<ScoresVM> scoresVM = new List<ScoresVM>();
            foreach (var item in query)
            {
                scoresVM.Add(new ScoresVM {
                    CategoryName = item.Categories.ToString(),
                    Score = item.CourseScore,
                    CourseName = item.CourseName,
                    UserName = item.UserName
                });
            }

            ViewData["scores"] = scoresVM;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
