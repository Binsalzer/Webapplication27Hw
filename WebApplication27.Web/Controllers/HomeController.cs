using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication27.Data;
using WebApplication27.Web.Models;

namespace WebApplication27.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly string _connection = @"Data Source=.\sqlexpress; Initial Catalog=PeopleCars; Integrated Security=true";

        public IActionResult Index()
        {
            PeopleManager mgr = new(_connection);
            var vm = new IndexViewModel { People = mgr.GetAllPeople() };
            if (TempData["msg"]!=null)
            {
                vm.Message = (string)TempData["msg"];
            }


            return View(vm);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Added(List<Person> people)
        {
            PeopleManager mgr = new(_connection);
            mgr.AddMultiplePeople(people);
            string p = "People";
            if(people.Count<2)
            {
                p = "Person";
            }
            TempData["msg"] = $"{people.Count} {p} added successfully!";
            return Redirect("/home");
        }
    }
}