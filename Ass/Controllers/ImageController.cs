using Ass.IServices;
using Ass.Models;
using Ass.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Ass.Controllers
{
    public class ImageController : Controller
    {
        // GET: ImageController
        private readonly IImageServices imageServices;
        private readonly IProductServices productServices;

        public ImageController()
        {
            imageServices = new ImageServices();
            productServices = new ProductServices();
        }

        public ActionResult Index()
        {
            var list = imageServices.GetAllImages();
           
            return View(list);
        }
        // GET: ImageController/Details/5
        public ActionResult Details(Guid id)
        {
            var i = imageServices.GetImageById(id);
            return View(i);
        }

        // GET: ImageController/Create
        public ActionResult Create()
        {
            ViewBag.Product = new SelectList(productServices.GetAllProducts(), "Id", "Name");
            return View();
        }

        // POST: ImageController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Image i)
        {
            if (imageServices.CreateImage(i))
            {
                return RedirectToAction("Index");
            }
            else
            {
                return BadRequest();
            }

        }

        // GET: ImageController/Edit/5
        public ActionResult Edit(Guid id)
        {
            var image = imageServices.GetImageById(id);
            return View(image);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Image i)
        {
            if (imageServices.UpdateImage(i))
            {
                return RedirectToAction(nameof(Index));
            }
            return BadRequest();
        }

        // GET: ImageController/Delete/5
        public ActionResult Delete(Guid id)
        {
            var i = imageServices.GetImageById(id);
            return View(i);
        }

        // POST: ImageController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Image image)
        {
            if (imageServices.DeleteImage(image.Id))
                return RedirectToAction("Index");
            else { return BadRequest(); }

        }
    }
}
