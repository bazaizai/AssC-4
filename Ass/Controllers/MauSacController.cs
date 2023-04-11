using Ass.IServices;
using Ass.Models;
using Ass.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
namespace Ass.Controllers
{
    public class MauSacController : Controller
    {
        private readonly ILogger<MauSacController> _logger;
        private readonly IMauSacServices mauSacServices;


        public MauSacController(ILogger<MauSacController> logger)
        {
            _logger = logger;
            mauSacServices = new MauSacServices();
        }
       
      
        public IActionResult Index()
        {
            var lst = mauSacServices.GetAllMauSacs();
            return View(lst);
        }
        public IActionResult Details(Guid id)
        {
            MauSac a = mauSacServices.GetMauSacById(id);
            return View(a);
        }
        [HttpGet]
        public ActionResult Edit(Guid id) {
            var x = mauSacServices.GetMauSacById(id);
            return View(x);
        }
        public ActionResult Edit(MauSac a)
        {
            if(mauSacServices.UpdateMauSac(a))
            return RedirectToAction("Index");
            else return BadRequest();
        }
        [HttpGet]
        public ActionResult Delete(Guid id)
        {
            var a = mauSacServices.GetMauSacById(id);
            return View(a);
        } 
        public ActionResult Delete(MauSac a)
        {
           if(mauSacServices.DeleteMauSac(a.Id))
            return RedirectToAction("Index");
           else { return BadRequest(); }
        }
       
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(MauSac a)
        {
            if (mauSacServices.CreateMauSac(a))
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
