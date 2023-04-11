using Ass.IServices;
using Ass.Models;
using Ass.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ass.Controllers
{
    public class BillController : Controller
    {   
        private readonly IBillServices billServices;
        private readonly IBillDetailServices billDetailServices;
        public BillController()
        {
            billServices = new BillServices();
            billDetailServices = new BillsDetailervices();
        }
        // GET: BillController1
        public ActionResult Index()
        {
            var lst = billServices.GetAllBillViews();
            return View(lst);
        }

        // GET: BillController1/Details/5
        public ActionResult Details(Guid id)
        {
            var list = billDetailServices.GetBillDetailViewById(id);
            return View(list);
        }

        // GET: BillController1/Create
       

        // GET: BillController1/Edit/5
        public ActionResult Edit(Guid id)
        {
            var a = billServices.GetBillById(id);
            return View(a);
        }

        // POST: BillController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Bill a)
        {
            if(billServices.UpdateBill(a))
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        // GET: BillController1/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BillController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
