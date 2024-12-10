using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Cryptography.Xml;
using Zadacha5.Data;
using Zadacha5.Data.Models;
using Zadacha5.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Zadacha5.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext db;
        public StudentController(ApplicationDbContext db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(StudentViewModel student)
        {
            Student students = new Student()
            {
                Name = student.Name,
                Address = student.Address,
                Phone = student.Phone,
                

        };
            db.Students.Add(students);
            db.SaveChanges();
            return Redirect("/Home/Index");
    }
        public IActionResult All()
        {
            List<StudentViewModel> model = db.Students.Select(x => new StudentViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Phone = x.Phone,
                Address = x.Address



            }).ToList();
            return View(model);
        }
    }
}
