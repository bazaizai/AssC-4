using Ass.IServices;
using Ass.Models;
using Ass.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace Ass.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductServices productServices;
        private readonly IChatLieuServices chatLieuServices;
        private readonly IMauSacServices mauSacServices;
        private readonly ITeamServices teamServices;
        
        public ProductController()
        {
            productServices = new ProductServices();
            chatLieuServices = new ChatLieuServices();
            mauSacServices = new MauSacServices();
            teamServices = new TeamServices();
        }
        public ActionResult Index()
        {
            var list = productServices.GetAllProducts();
          
            return View(list);
        }


        public ActionResult Details(Guid id)
        {
            var a = productServices.GetProductById(id);
            return View(a);
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            ViewBag.ChatLieu = new SelectList(chatLieuServices.GetAllChatLieus(), "Id", "Ten");
            ViewBag.MauSac = new SelectList(mauSacServices.GetAllMauSacs(), "Id", "Ten");
            ViewBag.Team = new SelectList(teamServices.GetAllTeams(), "Id", "Ten");
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product a)
        {
             if(productServices.CreateProduct(a))
                return RedirectToAction("Index");
                else return BadRequest();
        }

        // GET: ProductController/Edit/5
        [HttpGet]
        public ActionResult Edit(Guid id)
        {
            var a = productServices.GetProductById(id);
            return View(a);
        }

        // POST: ProductController/Edit/5
      
        public ActionResult Edit(Product a)
        {
            var product = productServices.GetProductById(a.Id);
            Product c = new Product();
            c.Id = product.Id;
            c.IdMauSac = product.IdMauSac;
            c.Name = product.Name;
            c.MoTa = product.MoTa;
            c.IdChatLieu = product.IdChatLieu;
            c.IdTeam = product.IdTeam;
            c.GiaBan = product.GiaBan;
            c.TrangThai = product.TrangThai;
            c.SoLuongTon = product.SoLuongTon;
            var products = SessionServices.GetObjFromSession(HttpContext.Session, "ListProductSession");
            var x = products.FirstOrDefault(x => x.Id == c.Id);
            if (productServices.UpdateProduct(a))
            {
                if (products.FirstOrDefault(x => x.Id == c.Id) != null)
                {
                    products.Remove(x);
                    products.Add(c);
                    SessionServices.SetObjToSession(HttpContext.Session, "ListProductSession", products);
                    return RedirectToAction("Index");
                }
                else
                {
                    products.Add(c);
                    SessionServices.SetObjToSession(HttpContext.Session, "ListProductSession", products);
                    return RedirectToAction("Index");
                }
            }
            else
            {
                return View();
            }
                    
        }
        public IActionResult RollBack(Guid id)
        {
            var products = SessionServices.GetObjFromSession(HttpContext.Session, "ListProductSession");
            var a = products.FirstOrDefault(x => x.Id == id);
            if (productServices.UpdateProduct(a))
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }

        }
        // GET: ProductController/Delete/5
        public ActionResult Delete(Guid id)
        {
           
            var a = productServices.GetProductById(id);
            return View(a);
        }
        public IActionResult ProductSession()
        {
            var products = SessionServices.GetObjFromSession(HttpContext.Session, "ListProductSession");
            return View(products);
        }
        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Product a)
        {
                if(productServices.DeleteProduct(a.Id)) return RedirectToAction("Index");
                else { return BadRequest(); }
        }
    }
}
