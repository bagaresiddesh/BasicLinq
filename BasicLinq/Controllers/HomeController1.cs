using Microsoft.AspNetCore.Mvc;
using BasicLinq.Models;

namespace BasicLinq.Controllers
{
    public class HomeController1 : Controller
    {
        public List<Student> students=new List<Student>();
        public List<Teacher> teachers = new List<Teacher>();

        public HomeController1()
        {
            students.Add(new Student() { Id = 1, Name = "abc", Div = 'A' });
            students.Add(new Student() { Id = 3, Name = "abpqrc", Div = 'A' });
            students.Add(new Student() { Id = 5, Name = "abc", Div = 'B' });
            students.Add(new Student() { Id = 1, Name = "lmn", Div = 'B' });
            students.Add(new Student() { Id = 13, Name = "pqr", Div = 'B' });
            students.Add(new Student() { Id = 8, Name = "xyz", Div = 'B' });
            students.Add(new Student() { Id = 9, Name = "pqr", Div = 'A' });

            teachers.Add(new Teacher() { Id = 100, Name = "teacher1", Div = 'A' });
            teachers.Add(new Teacher() { Id = 200, Name = "teacher2", Div = 'B' });
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("GetStudents")]
        public JsonResult GetStudents()
        {
            //where 
            //var records = from s in students where s.Id <=3 select s; 
            //var records = from s in students where s.Name.Contains('a') select s;

            //select
            //var records = from t in teachers select t;
            //var records = from t in teachers select t.Name;

            //orderby
            //var records =from s in students orderby s.Id select s;

            //ThenBy
            //var records = students.OrderBy(s=>s.Name).ThenBy(s=>s.Id);

            //OrderByDescending
            var records = students.OrderByDescending(s => s.Id);

            //All
            //bool Result = students.All(s => s.Id >= 1 && s.Id <= 10);            
            //bool Result = teachers.All(s => s.Id == 100 || s.Id == 200);

            //Any
            bool Result = students.Any(s=>s.Id>5);

            Console.WriteLine(Result);
            return Json(records);
        }

    }
}
