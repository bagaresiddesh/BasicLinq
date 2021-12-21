using Microsoft.AspNetCore.Mvc;
using BasicLinq.Models;
using System.Linq;

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
            //var records = students.OrderByDescending(s => s.Id);

            //All
            //bool Result = students.All(s => s.Id >= 1 && s.Id <= 10);            
            //bool Result = teachers.All(s => s.Id == 100 || s.Id == 200);

            //Any
            //bool Result = students.Any(s=>s.Id>5);
            
            //Contains
            Student s1 = students[4];
            bool result = students.Contains(s1);
            Console.WriteLine(result);

            List<string> Elements1 = new List<string> { "Siddesh", "Jay", "Jayesh", "Omkar","Shubham", "Gopal", "Raviraj", "Sumit" , "Jayesh" };

            //ElementAt
            Console.WriteLine("student at position 4 : {0}", Elements1.ElementAt(4));
            //ElementatDefault
            Console.WriteLine("student at position 8 : {0}", Elements1.ElementAtOrDefault(8));

            //First
            Console.WriteLine("first student in list whose name contains 'J' :{0}", Elements1.First(i=>i.Contains("J")));

            //Last
            Console.WriteLine("Last student in list whose name has 'j' :{0}", Elements1.Last(s=>s.Contains("j")));

            //LastOrDefault
            Console.WriteLine("Last student in list whose name has 'z' :{0}", Elements1.LastOrDefault(s => s.Contains("z")));

            //Single
            //Console.WriteLine("single student in list whose name has 'd' :{0}", Elements.Single(s => s.Contains("z")));

            //SingleOrDefault
            Console.WriteLine("single student in list whose name has 'd' :{0}", Elements1.SingleOrDefault(s => s.Contains("z")));

            List<string> Elements2 = new List<string> { "Sanket", "Vinayak", "Atharav", "Shubham" };
            //Concat
            //var Result= Elements1.Concat(Elements2);

            //Distinct
            //var Result = Elements1.Distinct();

            //Except
            //var Result=Elements1.Except(Elements2).ToList();

            //Intersect
            //var Result=Elements1.Intersect(Elements2).ToList(); 

            //Union
            var Result = Elements1.Union(Elements2).ToList();
            return Json(Result);

            //Join
           /* var joinrecord = students.Join(teachers,
                                        students => students.Div,
                                        teachers => teachers.Div,
                                        (students, teachers) => new
                                        {
                                            Student = students.Name,
                                            Teacher = teachers.Name,
                                            Sid = students.Id,
                                            Tid = teachers.Id,
                                            Div = students.Div
                                        });
            return Json(joinrecord); */
            
        }

    }
}
