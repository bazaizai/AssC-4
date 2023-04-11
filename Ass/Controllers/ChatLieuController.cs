
using Ass.IServices;
using Ass.Models;
using Ass.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
namespace CodeWebCuaTui.Controllers
{
    public class ChatLieuController : Controller
    {
        private readonly ILogger<ChatLieuController> _logger;
        private readonly IChatLieuServices chatLieuServices;
        public ChatLieuController(ILogger<ChatLieuController> logger)
        {
            _logger = logger;
            chatLieuServices = new ChatLieuServices();
        }
        public IActionResult Index()
        {
           var list = chatLieuServices.GetAllChatLieus();
            return View(list);
        }
        public IActionResult Details(Guid id)
        {
            var Size = chatLieuServices.GetChatLieuById(id);
            return View(Size);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(ChatLieu a)
        {
            if (chatLieuServices.CreateChatLieu(a))
            {
                return RedirectToAction("Index");
            }
            else return BadRequest();
        }
        [HttpGet]
        public IActionResult Edit(Guid id)
        {
           var a = chatLieuServices.GetChatLieuById(id);
            return View(a);
        }
        public IActionResult Edit(ChatLieu a)
        {
            if (chatLieuServices.UpdateChatLieu(a))
            {
                return RedirectToAction("Index");
            }
            else return BadRequest();
        }
        [HttpGet]
        public IActionResult Delete(Guid id)
        {
            var a = chatLieuServices.GetChatLieuById(id);
            return View(a);
        }
        public IActionResult Delete(ChatLieu a)
        {
            if (chatLieuServices.DeleteChatLieu(a.Id))
            {
                return RedirectToAction("Index");
            }
            else return BadRequest();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
