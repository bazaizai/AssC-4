using Ass.IServices;
using Ass.Models;
using Ass.Services;
using Ass.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Ass.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductServices productServices;
        private readonly IImageServices imageServices;
        private readonly IUserServices userServices;
        private readonly IBillServices billServices;
        private readonly IBillDetailServices billDetailServices;
        private readonly ILogger<HomeController> _logger;
        private readonly CartsDetailservices cartDetailServices;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            userServices = new UserServices();
            productServices = new ProductServices();
            billServices = new BillServices();
            billDetailServices = new BillsDetailervices();
            cartDetailServices = new CartsDetailservices();
            imageServices = new ImageServices();
        }

        public IActionResult Index()
        {
            var list = productServices.GetAllProductsView().ToList();
            return View(list);
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult DanhSachSP()
        {
            return View();
        }
        public IActionResult ChiTietSP(Guid id)
        {
            var a = productServices.GetProductsView(id);
            return View(a);
        }
        public IActionResult QuanLy()
        {
            return View();
        }
        public IActionResult AddToCart(CartView a)
        {
            var Carts = SessionServices.GetObjFromCart(HttpContext.Session, "ListCartSession");
            if (Carts.FirstOrDefault(x => x.Id == a.Id) != null)
            {
                var cart = Carts.FirstOrDefault(c => c.Id == a.Id);
                cart.Quantity += a.Quantity;
                Carts.Remove(cart);
                Carts.Add(cart);
                SessionServices.SetObjToSession(HttpContext.Session, "ListCartSession", Carts);
                return RedirectToAction("ChiTietSP", new { Id = a.Id });
            }
            else
            {
                var product = productServices.GetProductById(a.Id);
                var cart = new CartView()
                {
                    Id = a.Id,
                    Quantity = a.Quantity,
                    Anh = imageServices.GetAllImages().FirstOrDefault(c => c.IdChiTietSp == a.Id).DuongDan,
                    Name = product.Name,
                    Price = product.GiaBan

                };
                Carts.Add(cart);
                SessionServices.SetObjToSession(HttpContext.Session, "ListCartSession", Carts);
                return RedirectToAction("ChiTietSP", new { Id = a.Id });
            }
        }
        public IActionResult AddToCartUser(CartDetail a)
        {
            var Carts = cartDetailServices.GetCartDetailById(a.UserID);
            if (Carts.FirstOrDefault(x => x.IDSP == a.IDSP) != null)
            {
                var cart = Carts.FirstOrDefault(c => c.IDSP == a.IDSP);
                cart.Quantity += a.Quantity;
                cartDetailServices.UpdateCartDetail(cart);
                return RedirectToAction("ChiTietSP", new { Id = a.IDSP });
            }
            else
            {

                var cart = new CartDetail()
                {
                    Id = Guid.NewGuid(),
                    Quantity = a.Quantity,
                    UserID = a.UserID,
                    IDSP = a.IDSP,
                };
                cartDetailServices.CreateCartDetail(cart);
                return RedirectToAction("ChiTietSP", new { Id = a.IDSP });
            }
        }
        public IActionResult Up(CartView a)
        {
            var Carts = SessionServices.GetObjFromCart(HttpContext.Session, "ListCartSession");
            var cart = Carts.FirstOrDefault(c => c.Id == a.Id);
            foreach (var item in Carts)
            {
                if (cart != null)
                {
                    item.Quantity += 1;
                }
            }
            SessionServices.SetObjToSession(HttpContext.Session, "ListCartSession", Carts);
            return RedirectToAction("Index");
        }
        public IActionResult UpUser(CartDetail a)
        {
            var Carts = cartDetailServices.GetCartDetailById(a.UserID);
            var cart = Carts.FirstOrDefault(c => c.Id == a.Id);
            foreach (var item in Carts)
            {
                if (cart != null)
                {
                    item.Quantity += 1;
                }
            }
            cartDetailServices.UpdateCartDetail(cart);
            return RedirectToAction("Index");
        }
        public IActionResult Dow(CartView a)
        {
            var Carts = SessionServices.GetObjFromCart(HttpContext.Session, "ListCartSession");
            var cart = Carts.FirstOrDefault(c => c.Id == a.Id);
            foreach (var item in Carts)
            {
                if (cart != null)
                {
                    item.Quantity -= 1;
                }
            }
            SessionServices.SetObjToSession(HttpContext.Session, "ListCartSession", Carts);
            return RedirectToAction("Index");
        }
        public IActionResult DowUser(CartDetail a)
        {
            var Carts = cartDetailServices.GetCartDetailById(a.UserID);
            var cart = Carts.FirstOrDefault(c => c.Id == a.Id);
            foreach (var item in Carts)
            {
                if (cart != null)
                {
                    item.Quantity -= 1;
                }
            }
            cartDetailServices.UpdateCartDetail(cart);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Create(User a)
        {
            if (userServices.CreateUser(a))
            {
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }

        }
        public IActionResult Login(User a)
        {
            var b = userServices.GetUserByTKMK(a.Username, a.Password);
            if (b != null)
            {
                SessionServices.SetObjToSession(HttpContext.Session, "user", b);
                var lstCartView = SessionServices.GetObjFromCart(HttpContext.Session, "ListCartSession");
                if (lstCartView.Count() > 0)
                {
                    var lstCartUser = cartDetailServices.GetCartDetailById(b.Id);
                    foreach (var item in lstCartView)
                    {
                        if (lstCartUser.FirstOrDefault(c => c.IDSP == item.Id) == null)
                        {
                            CartDetail cartDetail = new CartDetail()
                            {
                                Id = Guid.NewGuid(),
                                IDSP = item.Id,
                                Quantity = item.Quantity,
                                UserID = b.Id
                            };
                            cartDetailServices.CreateCartDetail(cartDetail);
                        }
                        else
                        {
                            var cartDetail = lstCartUser.FirstOrDefault(c => c.IDSP == item.Id);
                            cartDetail.Quantity += item.Quantity;
                            cartDetailServices.UpdateCartDetail(cartDetail);
                        }
                        HttpContext.Session.Remove("ListCartSession");
                    }
                }
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        public IActionResult Dss()
        {
            HttpContext.Session.Remove("user");
            return RedirectToAction("Index");
        }
        public IActionResult ThanhToan()
        {
            var acc = SessionServices.GetObjFromUser(HttpContext.Session, "user");
            if (acc != null)
            {
                var lstCart = cartDetailServices.GetCartDetailViewById(acc.Id);
                return View(lstCart);
            }
            else { return RedirectToAction("Index"); }
        }
        public IActionResult AddBill(CartDetailView a)
        {
            var lst = cartDetailServices.GetCartDetailById(a.UserId);
            if (lst.Count > 0)
            {
                var lstBillDetail = new List<BillDetail>();
                var lstProduct = new List<Product>();
                int d = 0;
                Bill bill = new Bill()
                {
                    Id = Guid.NewGuid(),
                    UserId = a.UserId,
                    CreateDate = DateTime.Now,
                    status = 0
                };
                billServices.CreateBill(bill);
                foreach (var item in lst)
                {
                    var c = productServices.GetProductById(item.IDSP);
                    if (c.SoLuongTon >= item.Quantity)
                    {
                        BillDetail billDetail = new BillDetail()
                        {
                            Id = Guid.NewGuid(),
                            IdHD = bill.Id,
                            IdSP = item.IDSP,
                            Price = c.GiaBan,
                            Quantity = item.Quantity
                        };
                        c.SoLuongTon -= item.Quantity;
                        lstBillDetail.Add(billDetail);
                        lstProduct.Add(c);
                    }
                    else
                    {
                        d++;
                    }

                }
                if (d == 0)
                {
                    foreach (var item in lstBillDetail)
                    {
                        billDetailServices.CreateBillDetail(item);
                    }
                    foreach (var item in lst)
                    {

                        cartDetailServices.DeleteCartDetail(item.Id);
                    }
                    foreach (var item in lstProduct)
                    {
                        productServices.UpdateProduct(item);
                    }
                    return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("ThanhToan");
                }
            }
            else return RedirectToAction("ThanhToan");
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}