using Ass.IServices;
using Ass.Models;
using Ass.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Ass.Controllers
{
    public class TeamController : Controller
    {
      
        private readonly ILogger<TeamController> _logger;
        public readonly ITeamServices teamServices;


        public TeamController(ILogger<TeamController> logger)
        {
            _logger = logger;
            teamServices = new TeamServices();
        }


        public IActionResult Index()
        {
            var lst = teamServices.GetAllTeams();
            return View(lst);
        }
        public IActionResult Details(Guid id)
        {
            var a = teamServices.GetTeamById(id);
            return View(a);
        }
        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            var x = teamServices.GetTeamById(id);
            return View(x);
        }

        public IActionResult Edit(Team a)
        {
            if (teamServices.UpdateTeam(a))
                return RedirectToAction("Index");
            else return BadRequest();
        }
        [HttpGet]
        public IActionResult Delete(Guid id)
        {
            var a = teamServices.GetTeamById(id);
            return View(a);
        }
        public IActionResult Delete(Team a)
        {
            if (teamServices.DeleteTeam(a.Id))
                return RedirectToAction("Index");
            else { return BadRequest(); }
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Team a)
        {
            if (teamServices.CreateTeam(a))
            {
                return RedirectToAction("Index");
            }
            else { return BadRequest(); }
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
