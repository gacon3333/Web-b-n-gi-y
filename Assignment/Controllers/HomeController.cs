//using AspNetCore;
using System.Globalization;
using Microsoft.AspNetCore.Http.Features;
using Newtonsoft.Json;
using Assignment.IServices;
using Assignment.Models;
using Assignment.Services;
using ClassLibrary1.Models;
using Gremlin.Net.Process.Traversal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using MySqlX.XDevAPI;
using Microsoft.Build.Experimental.ProjectCache;
//using static Google.Protobuf.Collections.MapField<TKey, TValue>;
using System;
using Polly;
using Microsoft.CodeAnalysis;
using Microsoft.AspNetCore.Authentication;
using System.Text;

namespace Assignment.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IChiTietSpServices ChiTietSpServices;
        private readonly IGioHangChiTietServices gioHangChiTietServices;
        private readonly IkichCoServices kichCoServices;
        private readonly IMauSacServices mauSacServices;
        private readonly IRoleServices roleServices;
        private readonly IKieuSpServices kieuSpServices;
        private readonly IUserServices userServices;
        private readonly IGioHangServices gioHangServices;
        private readonly IHoaDonChiTietServices hoaDonChiTietServices;
        private readonly IHoaDonServices hoaDonServices;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            ChiTietSpServices = new ChiTietSpServices();
            gioHangChiTietServices = new GioHangChiTietServices();
            mauSacServices = new MauSacServices();
            kieuSpServices = new KieuSpServices();
            kichCoServices = new KichCoServices();
            userServices = new UserServices();
            gioHangServices = new GioHangServices();
            roleServices = new RoleServices();
            hoaDonChiTietServices = new HoaDonChiTietServices();
            hoaDonServices = new HoaDonServices();

        }
        [HttpGet]

        public IActionResult ExternalLogin(string provider)
        {
            string currentUrl = HttpContext.Session.GetString("CurrentUrl");
            // Lưu returnUrl để chuyển hướng người dùng trở lại sau khi đăng nhập thành công
            ViewData["ReturnUrl"] = currentUrl;

            // Redirect đến Google để xác thực người dùng
            var authenticationProperties = new AuthenticationProperties { RedirectUri = Url.Action(nameof(ExternalLoginCallback)) };
            return Challenge(authenticationProperties, provider);
        }

        [HttpGet]
        public async Task<IActionResult> ExternalLoginCallback(string returnUrl = null, string remoteError = null)
        {
            // Kiểm tra xem có lỗi xảy ra trong quá trình đăng nhập không
            if (remoteError != null)
            {
                ModelState.AddModelError(string.Empty, $"Error from external provider: {remoteError}");
                return View("Login");
            }

            // Lấy thông tin đăng nhập của người dùng từ Google
            var info = await HttpContext.AuthenticateAsync("ExternalCookie");
            var claims = info.Principal.Claims;

            // Lưu thông tin đăng nhập vào session hoặc cookie để sử dụng cho các yêu cầu sau này
            // ...

            // Chuyển hướng người dùng trở lại trang trước đó hoặc trang chủ nếu returnUrl không được cung cấp
            return LocalRedirect(returnUrl ?? "/");
        }
        //Nav//-----------------------------------------------------------------------------------------------
        //public IActionResult TimKiem(string searchString)
        //{
        //    using (CuaHangGiayDBContext shopDbContext = new CuaHangGiayDBContext())
        //    {
        //        var list = shopDbContext.ChiTietSps.Where(a => a.SoLuongTon >= 1)
        //                                            .Include("IdKichCoNavigation")
        //                                            .Include("IdMauSacNavigation")
        //                                            .Include("IdKieuSpNavigation");

        //        // Kiểm tra chuỗi tìm kiếm có rỗng hay không
        //        if (!String.IsNullOrEmpty(searchString))
        //        {
        //            // Chuyển chuỗi tìm kiếm sang chữ thường
        //            searchString = searchString.ToLower();

        //            // Lọc danh sách sản phẩm theo tên
        //            list = list.Where(a => a.Ten.ToLower().Contains(searchString));
        //        }

        //        // Trả về danh sách sản phẩm cho View
        //        return View(list.ToList());
        //    }
        //}

        //public IActionResult TimKiem1(string searchString, decimal? minPrice, decimal? maxPrice)
        //{
        //    using (CuaHangGiayDBContext shopDbContext = new CuaHangGiayDBContext())
        //    {
        //        var list = shopDbContext.ChiTietSps.Where(a => a.SoLuongTon >= 1)
        //                                            .Include("IdKichCoNavigation")
        //                                            .Include("IdMauSacNavigation")
        //                                            .Include("IdKieuSpNavigation");

               
        //    }
        //}

        public IActionResult TimKiem(string searchString, decimal? minPrice, decimal? maxPrice)
        {
            using (CuaHangGiayDBContext shopDbContext = new CuaHangGiayDBContext())
            {
                var list = shopDbContext.ChiTietSps.Where(a => a.SoLuongTon >= 1)
                                                    .Include("IdKichCoNavigation")
                                                    .Include("IdMauSacNavigation")
                                                    .Include("IdKieuSpNavigation").ToList();
               
          

                // Kiểm tra chuỗi tìm kiếm có rỗng hay không
                if (!String.IsNullOrEmpty(searchString))
                {
                    // Chuyển chuỗi tìm kiếm sang chữ thường và loại bỏ dấu tiếng Việt
                    searchString = RemoveUnicode(searchString.ToLower());

                    // Lọc danh sách sản phẩm theo tên
                    list = list.Where(a => RemoveUnicode(a.Ten.ToLower()).Contains(searchString)).ToList();
                }
               
                if (minPrice != null)
                {
                    list = list.Where(a => a.GiaBan >= minPrice).ToList();
                }

                if (maxPrice != null)
                {
                    list = list.Where(a => a.GiaBan <= maxPrice).ToList();
                }

                // Trả về danh sách sản phẩm cho View
                return View(list);
            }
        }

        public static string RemoveDiacritics(string text)
        {
            return new string(
                text.Normalize(NormalizationForm.FormD)
                .Where(c => CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                .ToArray());
        }
        public static string RemoveUnicode(string text)
        {
            string[] arr1 = new string[] { "á", "à", "ả", "ã", "ạ", "â", "ấ", "ầ", "ẩ", "ẫ", "ậ", "ă", "ắ", "ằ", "ẳ", "ẵ", "ặ",
    "đ",
    "é","è","ẻ","ẽ","ẹ","ê","ế","ề","ể","ễ","ệ",
    "í","ì","ỉ","ĩ","ị",
    "ó","ò","ỏ","õ","ọ","ô","ố","ồ","ổ","ỗ","ộ","ơ","ớ","ờ","ở","ỡ","ợ",
    "ú","ù","ủ","ũ","ụ","ư","ứ","ừ","ử","ữ","ự",
    "ý","ỳ","ỷ","ỹ","ỵ",};
            string[] arr2 = new string[] { "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a",
    "d",
    "e","e","e","e","e","e","e","e","e","e","e",
    "i","i","i","i","i",
    "o","o","o","o","o","o","o","o","o","o","o","o","o","o","o","o","o",
    "u","u","u","u","u","u","u","u","u","u","u",
    "y","y","y","y","y",};
            for (int i = 0; i < arr1.Length; i++)
            {
                text = text.Replace(arr1[i], arr2[i]);
                text = text.Replace(arr1[i].ToUpper(), arr2[i].ToUpper());
            }
            return text;
        }
        public IActionResult Index()
        {
            using (CuaHangGiayDBContext shopDbContext = new CuaHangGiayDBContext())
            {
                var list = shopDbContext.ChiTietSps.Where(a => a.SoLuongTon >= 1).Include("IdKichCoNavigation").Include("IdMauSacNavigation").Include("IdKieuSpNavigation").ToList();
                return View(list);
            }

        }

        public IActionResult Privacy()
        {
            using (CuaHangGiayDBContext shopDbContext = new CuaHangGiayDBContext())
            {
                var list = shopDbContext.ChiTietSps.Where(a => a.SoLuongTon >= 1).Include("IdKichCoNavigation").Include("IdMauSacNavigation").Include("IdKieuSpNavigation").ToList();
                return View(list);
            }
        }
        public IActionResult Sptheokieusp(Guid id)
        {
            using (CuaHangGiayDBContext shopDbContext = new CuaHangGiayDBContext())
            {
                var list = shopDbContext.ChiTietSps.Where(a => a.SoLuongTon >= 1).Include("IdKichCoNavigation").Include("IdMauSacNavigation").Include("IdKieuSpNavigation").Where(x => x.IdKieuSp == id).ToList();
                return View(list);
            }
        }
        public IActionResult About()
        {
            return View();

        }
        public IActionResult DatHang()
        {
            return View();
        }

        public IActionResult ThanhToan()
        {
            return View();
        }
        //ViewBag.HideFooter = true;

        //Nav//-----------------------------------------------------------------------------------------------



        //chi tiet sp//---------------------------------------------------------------------------------------
        public IActionResult ShowListCtsp()
        {
            using (CuaHangGiayDBContext shopDbContext = new CuaHangGiayDBContext())
            {
                var list = shopDbContext.ChiTietSps.Include("IdKichCoNavigation").Include("IdMauSacNavigation").Include("IdKieuSpNavigation").ToList();
                return View(list);
            }
            //List<ChiTietSp> products = ChiTietSpServices.GetAllChiTietSps();
            //return View(products);
        }
        public IActionResult DetailsCtsp(Guid id)
        {
            CuaHangGiayDBContext shopDbContext = new CuaHangGiayDBContext();
            var product = shopDbContext.ChiTietSps.Find(id);
            return View(product);
        }

        public IActionResult AddCtsp()
        {
            CuaHangGiayDBContext shopDbContext = new CuaHangGiayDBContext();
            ViewData["IdKieuSp"] = new SelectList(shopDbContext.KieuSps, "Id", "Ten");
            ViewData["IdMauSac"] = new SelectList(shopDbContext.MauSacs, "Id", "Ten");
            ViewData["IdKichCo"] = new SelectList(shopDbContext.KichCos, "Id", "Size");
            // Tạo SelectList cho LoaiSanPham
            SelectList loaiSpList = new SelectList(shopDbContext.KieuSps, "Id", "Ten");
            ViewBag.LoaiSpList = loaiSpList;
            // Tạo SelectList cho MauSac
            SelectList mauSacList = new SelectList(shopDbContext.MauSacs, "Id", "Ten");
            ViewBag.MauSacList = mauSacList;
            // Tạo SelectList cho KichCo
            SelectList kichCoList = new SelectList(shopDbContext.KichCos, "Id", "Size");
            ViewBag.KichCoList = kichCoList;
            return View();
        }
        [HttpPost]
        public IActionResult AddCtsp(ChiTietSp p)
        {
            if (ChiTietSpServices.CreateChiTietSp(p))
            {
                return RedirectToAction("ShowListCtsp");
            }
            else return BadRequest();
        }



        [HttpGet]
        public IActionResult UpdateCtsp(Guid id)
        {
            ChiTietSp p = ChiTietSpServices.GetChiTietSpById(id);
            CuaHangGiayDBContext shopDbContext = new CuaHangGiayDBContext();
            ViewData["IdKieuSp"] = new SelectList(shopDbContext.KieuSps, "Id", "Ten");
            ViewData["IdMauSac"] = new SelectList(shopDbContext.MauSacs, "Id", "Ten");
            ViewData["IdKichCo"] = new SelectList(shopDbContext.KichCos, "Id", "Size");
            // Tạo SelectList cho LoaiSanPham
            SelectList loaiSpList = new SelectList(shopDbContext.KieuSps, "Id", "Ten");
            ViewBag.LoaiSpList = loaiSpList;
            // Tạo SelectList cho MauSac
            SelectList mauSacList = new SelectList(shopDbContext.MauSacs, "Id", "Ten");
            ViewBag.MauSacList = mauSacList;
            // Tạo SelectList cho KichCo
            SelectList kichCoList = new SelectList(shopDbContext.KichCos, "Id", "Size");
            ViewBag.KichCoList = kichCoList;

            return View(p);
        }
        [HttpPost]
        public IActionResult UpdateCtsp(ChiTietSp p)
        {
            CuaHangGiayDBContext shopDbContext = new CuaHangGiayDBContext();
            ViewData["IdKieuSp"] = new SelectList(shopDbContext.KieuSps, "Id", "Ten");
            ViewData["IdMauSac"] = new SelectList(shopDbContext.MauSacs, "Id", "Ten");
            ViewData["IdKichCo"] = new SelectList(shopDbContext.KichCos, "Id", "Size");
            // Tạo SelectList cho LoaiSanPham
            SelectList loaiSpList = new SelectList(shopDbContext.KieuSps, "Id", "Ten");
            ViewBag.LoaiSpList = loaiSpList;
            // Tạo SelectList cho MauSac
            SelectList mauSacList = new SelectList(shopDbContext.MauSacs, "Id", "Ten");
            ViewBag.MauSacList = mauSacList;
            // Tạo SelectList cho KichCo
            SelectList kichCoList = new SelectList(shopDbContext.KichCos, "Id", "Size");
            ViewBag.KichCoList = kichCoList;
            //var list = ChiTietSpServices.GetAllChiTietSps();
            //if (list.Any(x => x.Ten == p.Ten && x.IdKieuSp == p.IdKieuSp && x.Id != p.Id)){

            //if (ChiTietSpServices.UpdateChiTietSp(p))
            //{
            //    return RedirectToAction("ShowListCtsp");
            //}
            //else
            //{
            //    TempData["AlertMessage"] = "Update failed";
            //    return View(p);
            //}


            if (ModelState.IsValid)
            {
                if (ChiTietSpServices.UpdateChiTietSp(p))
                {
                    return RedirectToAction("ShowListCtsp");
                }
                else
                {
                    TempData["AlertMessage"] = "Update failed";
                }
            }

            return View(p);
        }



        public IActionResult DeleteCtsp(Guid id)
        {
            ChiTietSp oldProduct = ChiTietSpServices.GetChiTietSpById(id);         
            if (ChiTietSpServices.DeleteChiTietSp(id))
            {
                HttpContext.Session.SetString("OldProduct_" + id.ToString(), JsonConvert.SerializeObject(oldProduct));
                return RedirectToAction("ShowListCtsp");
            }
            else return View("Index");
        }
        public IActionResult ShowOldValues()
        {
            List<ChiTietSp> oldProducts = new List<ChiTietSp>();
            foreach (string key in HttpContext.Session.Keys)
            {
                if (key.StartsWith("OldProduct_"))
                {
                    string oldProductJson = HttpContext.Session.GetString(key);
                    if (!string.IsNullOrEmpty(oldProductJson))
                    {
                        ChiTietSp oldProduct = JsonConvert.DeserializeObject<ChiTietSp>(oldProductJson);
                        oldProducts.Add(oldProduct);
                    }
                }
            }
            return View(oldProducts);
        }


        public IActionResult Rollback(Guid id)
        {
            // Lấy dữ liệu cũ của sản phẩm từ session
            string oldProductJson = HttpContext.Session.GetString("OldProduct_" + id.ToString());
            if (!string.IsNullOrEmpty(oldProductJson))
            {
                ChiTietSp oldProduct = JsonConvert.DeserializeObject<ChiTietSp>(oldProductJson);
                if (ChiTietSpServices.CreateChiTietSp(oldProduct))
                {
                    // Xóa dữ liệu cũ của sản phẩm khỏi session
                    HttpContext.Session.Remove("OldProduct_" + id.ToString());
                    return RedirectToAction
                        ("ShowListCtsp");
                }
                else
                {
                    return BadRequest();
                }
            }
            else
            {
                return BadRequest();
            }
        }
        public IActionResult Detailsp(Guid id)
        {
            using (CuaHangGiayDBContext shopDbContext = new CuaHangGiayDBContext())
            {
                var product = shopDbContext.ChiTietSps
                    .Include(p => p.IdKichCoNavigation)
                    .Include(p => p.IdMauSacNavigation)
                    .Include(p => p.IdKieuSpNavigation)
                    .SingleOrDefault(p => p.Id == id);

                if (product == null)
                {
                    return NotFound();
                }

                return View(product);
            }
        }
        //chi tiet sp//---------------------------------------------------------------------------------------



        //GioHang//-------------------------------------------------------------------------------------------
        [HttpPost]
        public IActionResult UpdateCart(Guid id, int qty)
        {
            CuaHangGiayDBContext shopDbContext = new CuaHangGiayDBContext();
            string userJson = HttpContext.Session.GetString("User");
            User user = JsonConvert.DeserializeObject<User>(userJson);

            // Lấy thông tin giỏ hàng 
            // Tìm sản phẩm trong giỏ hàng
            var cartItem = shopDbContext.GioHangChiTiets
              .Where(x => x.UserId == user.Id && x.IdChiTietSp == id)
              .FirstOrDefault();

            if (cartItem != null)
            {
                // Cập nhật số lượng sản phẩm
                cartItem.SoLuong = qty;

                // Lưu lại thông tin giỏ hàng 
                gioHangChiTietServices.UpdateGioHangChiTiet(cartItem);
                return Json(new { success = true });
            }
            else
            {
                return Json(new { success = false });
            }
        }

        public IActionResult ShowCartsss()
        {
            string userJson = HttpContext.Session.GetString("User");
            User user = JsonConvert.DeserializeObject<User>(userJson);
            using (CuaHangGiayDBContext shopDbContext = new CuaHangGiayDBContext())
            {
                var list = shopDbContext.GioHangChiTiets.Where(x => x.UserId == user.Id).Include("IdChiTietSpNavigation").ToList();
                foreach (var Items in list)
                {
                    if (Items.SoLuong <= 0)
                    {

                        gioHangChiTietServices.DeleteGioHangChiTiet(Items.Id);
                    }
                    if (Items.SoLuong > ChiTietSpServices.GetChiTietSpById(Items.IdChiTietSp).SoLuongTon)
                    {
                        Items.SoLuong = ChiTietSpServices.GetChiTietSpById(Items.IdChiTietSp).SoLuongTon;
                        gioHangChiTietServices.UpdateGioHangChiTiet(Items);
                    }
                }
                return View(list);
            }
        }
        public IActionResult AddToCarts(Guid id, int quantity)
        {
            CuaHangGiayDBContext shopDbContext = new CuaHangGiayDBContext();
            GioHangChiTiet gioHangChiTiet = new GioHangChiTiet();
            var sp = shopDbContext.ChiTietSps.Find(id);
            string userJson = HttpContext.Session.GetString("User");

            if (userJson == null)
            {
                string currentUrl = Request.Headers["Referer"].ToString();
                HttpContext.Session.SetString("CurrentUrl", currentUrl);
                //// Lưu đường dẫn route hiện tại vào Session
                //string currentUrl = HttpContext.Request.Path.ToString();
                //HttpContext.Session.SetString("CurrentUrl", currentUrl);
                // Lưu thông tin trang đích vào Session

                return RedirectToAction("Login");
            }
            else
            {
                User user = JsonConvert.DeserializeObject<User>(userJson);
                //User a = userServices.GetUserById(user.Id);
                gioHangChiTiet.IdChiTietSp = id;
                gioHangChiTiet.UserId = user.Id;
                gioHangChiTiet.SoLuong = quantity;
                gioHangChiTiet.DonGia = sp.GiaBan;
                var cartItem = shopDbContext.GioHangChiTiets
                  .Where(x => x.UserId == user.Id && x.IdChiTietSp == id)
                  .FirstOrDefault();
                if (cartItem == null)
                {
                    if (gioHangChiTietServices.CreateGioHangChiTiet(gioHangChiTiet))
                    {
                        return RedirectToAction("ShowCartsss");
                    }
                    else
                    {
                        return BadRequest();
                    }
                }
                else
                {
                    cartItem.SoLuong += quantity;

                    if (cartItem.SoLuong > sp.SoLuongTon)
                    {
                        cartItem.SoLuong = sp.SoLuongTon;
                    }

                    cartItem.DonGia = sp.GiaBan;

                    if (gioHangChiTietServices.UpdateGioHangChiTiet(cartItem))
                    {
                        return RedirectToAction("ShowCartsss");
                    }
                    else
                    {
                        return BadRequest();
                    }

                }
            }
        }


        public IActionResult UpdateToCarts(GioHangChiTiet p)
        {
            if (gioHangChiTietServices.UpdateGioHangChiTiet(p))
            {
                return RedirectToAction("ShowCartsss");
            }
            else return BadRequest();
        }


        public IActionResult DeleteCart(Guid id)
        {
            if (gioHangChiTietServices.DeleteGioHangChiTiet(id))
            {
                return RedirectToAction("ShowCartsss");
            }
            else return View("Index");
        }
        //Giohang//-------------------------------------------------------------------------------------------



        //ThongBao//------------------------------------------------------------------------------------------

        //ThongBao//------------------------------------------------------------------------------------------



        //MauSac//--------------------------------------------------------------------------------------------
        public IActionResult ShowListMausac()
        {
            using (CuaHangGiayDBContext shopDbContext = new CuaHangGiayDBContext())
            {
                var list = shopDbContext.MauSacs.ToList();
                return View(list);
            }
        }
        public IActionResult DetailsMauSac(Guid id)
        {
            CuaHangGiayDBContext shopDbContext = new CuaHangGiayDBContext();
            var product = shopDbContext.MauSacs.Find(id);
            return View(product);
        }

        public IActionResult AddMausac()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddMausac(MauSac p)
        {


            if (mauSacServices.CreateMauSac(p))
            {
                return RedirectToAction("ShowListMausac");
            }
            else return BadRequest();
        }



        [HttpGet]
        public IActionResult UpdateMauSac(Guid id)
        {
            MauSac p = mauSacServices.GetMauSacById(id);
            return View(p);
        }
        [HttpPost]
        public IActionResult UpdateMauSac(MauSac p)
        {
            if (mauSacServices.UpdateMauSac(p))
            {
                return RedirectToAction("ShowListMausac");
            }
            else return BadRequest();
        }


        public IActionResult DeleteMauSac(Guid id)
        {
            if (mauSacServices.DeleteMauSac(id))
            {
                return RedirectToAction("ShowListMausac");
            }
            else return View("Index");
        }
        //MauSac//--------------------------------------------------------------------------------------------



        //KickCo//--------------------------------------------------------------------------------------------
        public IActionResult AddKichCo()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddKichCo(KichCo p)
        {

            if (kichCoServices.CreateKichCo(p))
            {
                return RedirectToAction("ShowListKichCo");
            }
            else return BadRequest();
        }
        public IActionResult ShowListKichCo()
        {
            using (CuaHangGiayDBContext shopDbContext = new CuaHangGiayDBContext())
            {
                var list = shopDbContext.KichCos.ToList();
                return View(list);
            }
        }
        public IActionResult DetailsKickCo(Guid id)
        {
            CuaHangGiayDBContext shopDbContext = new CuaHangGiayDBContext();
            var product = shopDbContext.MauSacs.Find(id);
            return View(product);
        }



        [HttpGet]
        public IActionResult UpdateKickCo(Guid id)
        {
            KichCo p = kichCoServices.GetKichCoById(id);
            return View(p);
        }
        [HttpPost]
        public IActionResult UpdateKickCo(KichCo p)
        {
            if (kichCoServices.UpdateKichCo(p))
            {
                return RedirectToAction("ShowListKichCo");
            }
            else return BadRequest();
        }


        public IActionResult DeleteKichCo(Guid id)
        {
            if (kichCoServices.DeleteKichCo(id))
            {
                return RedirectToAction("ShowListKichCo");
            }
            else return View("Index");
        }
        //KickCo//--------------------------------------------------------------------------------------------



        //Kieusp//--------------------------------------------------------------------------------------------
        public IActionResult AddKieuSp()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddKieuSp(KieuSp p)
        {

            if (kieuSpServices.CreateKieuSp(p))
            {
                return RedirectToAction("ShowListKieuSp");
            }
            else return BadRequest("");
        }
        public IActionResult ShowListKieuSp()
        {
            using (CuaHangGiayDBContext shopDbContext = new CuaHangGiayDBContext())
            {
                var list = shopDbContext.KieuSps.ToList();
                return View(list);
            }
        }
        public IActionResult DetailsKieuSp(Guid id)
        {
            CuaHangGiayDBContext shopDbContext = new CuaHangGiayDBContext();
            var product = shopDbContext.KieuSps.Find(id);
            return View(product);
        }



        [HttpGet]
        public IActionResult UpdateKieuSp(Guid id)
        {
            KieuSp p = kieuSpServices.GetKieuSpById(id);
            return View(p);
        }
        [HttpPost]
        public IActionResult UpdateKieuSp(KieuSp p)
        {
            if (kieuSpServices.UpdateKieuSp(p))
            {
                return RedirectToAction("ShowListKieuSp");
            }
            else return BadRequest();
        }

        public IActionResult DeleteKieuSp(Guid id)
        {
            if (kieuSpServices.DeleteKieuSp(id))
            {
                return RedirectToAction("ShowListKieuSp");
            }
            else return View("Index");
        }
        //Kieusp//--------------------------------------------------------------------------------------------



        //Role//----------------------------------------------------------------------------------------------
        //Role//----------------------------------------------------------------------------------------------



        //User//----------------------------------------------------------------------------------------------
        public IActionResult Login(string usernameOrEmail, string password)
        {
            string currentUrl = HttpContext.Session.GetString("CurrentUrl");
            User user = userServices.GetUserBy(usernameOrEmail, password);
            if (user != null)
            {
                if (currentUrl != null)
                {
                    HttpContext.Session.SetString("User", JsonConvert.SerializeObject(user));
                    // Chuyển hướng đến trang chính của ứng dụng
                    return Redirect(currentUrl);
                }
                else
                {
                    // Lưu thông tin người dùng vào Session
                    HttpContext.Session.SetString("User", JsonConvert.SerializeObject(user));
                    // Chuyển hướng đến trang chính của ứng dụng
                    return RedirectToAction("Index", "Home");
                }

            }
            else
            {
                // Trả về thông báo lỗi nếu thông tin đăng nhập không đúng
                TempData["AlertMessage"] = "Login failed";
                return View();
            }

        }
        public IActionResult LogOut()
        {
            HttpContext.Session.Remove("User");
            return RedirectToAction("Index", "Home");
        }

        public IActionResult AddUser()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddUser(User p, GioHang cart)
        {
            if (userServices.CreateUser(p))
            {
                Guid userId = p.Id;
                cart.UserId = userId;

                if (gioHangServices.CreateGioHang(cart))
                {
                    return RedirectToAction("Login");
                }
                else
                {
                    return BadRequest();
                }

            }
            else return BadRequest();
        }
        public IActionResult UserProfile()
        {
            // Lấy thông tin người dùng từ Session
            string userJson = HttpContext.Session.GetString("User");
            User user = JsonConvert.DeserializeObject<User>(userJson);
            // Lấy ID người dùng
            User a = userServices.GetUserById(user.Id);
            return View(a);
        }

        [HttpGet]
        public IActionResult UpdateUser(Guid id)
        {
            KieuSp p = kieuSpServices.GetKieuSpById(id);
            return View(p);
        }
        [HttpPost]
        public IActionResult UpdateUser(KieuSp p)
        {
            if (kieuSpServices.UpdateKieuSp(p))
            {
                return RedirectToAction("ShowListKieuSp");
            }
            else return BadRequest();
        }
        //User//----------------------------------------------------------------------------------------------



        //Dathang//-------------------------------------------------------------------------------------------
        public IActionResult ShowDatHang()
        {
            string userJson = HttpContext.Session.GetString("User");
            User user = JsonConvert.DeserializeObject<User>(userJson);
            using (CuaHangGiayDBContext shopDbContext = new CuaHangGiayDBContext())
            {
                var list = shopDbContext.GioHangChiTiets.Where(x => x.UserId == user.Id).Include("IdChiTietSpNavigation").ToList();
                return View(list);
            }
        }

        //Dathang//-------------------------------------------------------------------------------------------



        //HoaDon//--------------------------------------------------------------------------------------------

        private string MaTT()
        {
            if (hoaDonServices.GetAllHoaDons().Count > 0)
            {
                return "HD" + Convert.ToString(hoaDonServices.GetAllHoaDons().Max(c => Convert.ToInt32(c.Ma.Substring(2, c.Ma.Length - 2)) + 1));
            }
            else return "HD1";
        }

        public IActionResult AddHoaDon(int status, string sdt, string ten, string diachi)
        {
            CuaHangGiayDBContext shopDbContext = new CuaHangGiayDBContext();
            HoaDon hoaDon = new HoaDon();
            string userJson = HttpContext.Session.GetString("User");
            User user = JsonConvert.DeserializeObject<User>(userJson);
            //string gioHangChiTietJson = HttpContext.Session.GetString("GioHangChiTiet");
            //List<GioHangChiTiet> lstgioHangChiTiet = JsonConvert.DeserializeObject<List<GioHangChiTiet>>(gioHangChiTietJson);

            var listghct = shopDbContext.GioHangChiTiets.Where(x => x.UserId == user.Id).ToList();
            hoaDon.UserId = user.Id;
            hoaDon.Ma = MaTT();
            hoaDon.NgayTao = DateTime.Now;
            hoaDon.TrangThai = status;

            if (hoaDonServices.CreateHoaDon(hoaDon))
            {
                Guid idhd = hoaDon.Id;
                //List<HoaDonChiTiet> lsthdct = new List<HoaDonChiTiet>();
                foreach (var item in listghct)
                {
                    HoaDonChiTiet hoaDonChiTiet = new HoaDonChiTiet();
                    hoaDonChiTiet.IdHoaDon = idhd;
                    hoaDonChiTiet.DonGia = item.DonGia;
                    hoaDonChiTiet.SoLuong = item.SoLuong;
                    hoaDonChiTiet.IdChiTietSp = item.IdChiTietSp;
                    hoaDonChiTiet.Sdt = sdt;
                    hoaDonChiTiet.DiaChi = diachi;
                    hoaDonChiTiet.Ten = ten;
                    //lsthdct.Add(hoaDonChiTiet);
                    ChiTietSp p = ChiTietSpServices.GetChiTietSpById(item.IdChiTietSp);
                    p.SoLuongTon = p.SoLuongTon - hoaDonChiTiet.SoLuong;
                    if (hoaDonChiTietServices.CreateHoaDonChiTiet(hoaDonChiTiet))
                    {
                        ChiTietSpServices.UpdateChiTietSp(p);
                        gioHangChiTietServices.DeleteGioHangChiTiet(item.Id);
                    }
                }
                return RedirectToAction("Index");
            }
            else return BadRequest("");
        }
        public IActionResult ShowListHoaDon()
        {
            using (CuaHangGiayDBContext shopDbContext = new CuaHangGiayDBContext())
            {
                var list = shopDbContext.HoaDons.ToList();
                return View(list);
            }
        }
        public IActionResult DetailsHoaDon(Guid id)
        {
            CuaHangGiayDBContext shopDbContext = new CuaHangGiayDBContext();
            var product = shopDbContext.HoaDonChiTiets.Where(x => x.IdHoaDon == id).ToList();
            return View(product);
        }



        [HttpGet]
        public IActionResult UpdateHoaDon(Guid id)
        {
            HoaDon p = hoaDonServices.GetHoaDonById(id);
            return View(p);
        }
        [HttpPost]
        public IActionResult UpdateHoaDon(HoaDon p)
        {
            if (hoaDonServices.UpdateHoaDon(p))
            {
                return RedirectToAction("ShowListHoaDon");
            }
            else return BadRequest();
        }

        public IActionResult DeleteHoaDon(Guid id)
        {
            if (hoaDonServices.DeleteHoaDon(id))
            {
                return RedirectToAction("ShowListHoaDon");
            }
            else return View("Index");
        }
        //HoaDon//--------------------------------------------------------------------------------------------



        //HoaDonChiTiet//-------------------------------------------------------------------------------------
        public IActionResult DetailsHoaDonChiTiets(Guid id)
        {
            CuaHangGiayDBContext shopDbContext = new CuaHangGiayDBContext();
            var hdct = shopDbContext.HoaDonChiTiets.Where(a => a.IdHoaDon == id).Include("IdChiTietSpNavigation").Include("IdHoaDonNavigation").ToList();
            return View(hdct);
        }

        public IActionResult ShowListHoaDonChiTiet()
        {
            using (CuaHangGiayDBContext shopDbContext = new CuaHangGiayDBContext())
            {
                var list = shopDbContext.HoaDonChiTiets.ToList();
                return View(list);
            }
        }
        public IActionResult DetailsHoaDonChiTiet(Guid id)
        {
            CuaHangGiayDBContext shopDbContext = new CuaHangGiayDBContext();
            var hdct = shopDbContext.HoaDonChiTiets.Find(id);
            return View(hdct);
        }



        [HttpGet]
        public IActionResult UpdateHoaDonChiTiet(Guid id)
        {
            HoaDonChiTiet p = hoaDonChiTietServices.GetHoaDonChiTietById(id);
            return View(p);
        }
        [HttpPost]
        public IActionResult UpdateHoaDonChiTiet(HoaDonChiTiet p)
        {
            if (hoaDonChiTietServices.UpdateHoaDonChiTiet(p))
            {
                return RedirectToAction("ShowListHoaDonChiTiet");
            }
            else return BadRequest();
        }

        public IActionResult DeleteHoaDonChiTiet(Guid id)
        {
            if (hoaDonChiTietServices.DeleteHoaDonChiTiet(id))
            {
                return RedirectToAction("ShowListHoaDonChiTiet");
            }
            else return View("Index");
        }
        //HoaDonChitiet//-------------------------------------------------------------------------------------
        public IActionResult DangNhap(string usernameOrEmail, string password)
        {
            User user = userServices.GetUserBy(usernameOrEmail, password);
            if (user != null)
            {
                HttpContext.Session.SetString("User", JsonConvert.SerializeObject(user));
                return RedirectToAction("Index", "Home");
            }
            else
            {
                TempData["AlertMessage"] = "Login failed";
                return View();
            }

        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}