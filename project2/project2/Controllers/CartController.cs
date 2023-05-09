using Microsoft.AspNetCore.Mvc;

using project2.Helpers;
using project2.Models;

namespace project2.Controllers
{
  
    public class CartController : Controller
    {
        /*private readonly MyDbContext _context;

        public CartController(MyDbContext context)
        {
            _context = context;
        }


        
        
        public List<CartItem> Carts
        {
            get
            {
                var data = HttpContext.Session.Get<List<CartItem>>("GioHang");
                if (data == null)
                {
                    data = new List<CartItem>();
                }
                return data;
            }
        }

        public IActionResult Index()
        {
            return View(Carts);
        }

     
        public IActionResult AddToCart(int id, int SoLuong)
        {
            var myCart = Carts;
            var item = myCart.SingleOrDefault(p => p.MaHh == id);

            if (item == null)//chưa có
            {
                var hangHoa = _context.HangHoas.SingleOrDefault(p => p.MaHh == id);
                item = new CartItem
                {
                    MaHh = id,
                    TenHH = hangHoa.TenHh,
                    DonGia = hangHoa.DonGia.Value,
                    SoLuong = SoLuong,
                    Hinh = hangHoa.Hinh
                };
                myCart.Add(item);
            }
            else
            {
                item.SoLuong += SoLuong;
            }
            HttpContext.Session.Set("GioHang", myCart);

            return RedirectToAction("Index");
        }

        public IActionResult UpdateCart(int id, int SoLuong)
        {
            var myCart = Carts;
            var item = myCart.SingleOrDefault(p => p.MaHh == id);

            if (item == null)
            {
                return NotFound();
            }

            item.SoLuong = SoLuong;
            HttpContext.Session.Set("GioHang", myCart);

            return RedirectToAction("Index");
        }

        public IActionResult RemoveFromCart(int id)
        {
            var myCart = Carts;
            var item = myCart.SingleOrDefault(p => p.MaHh == id);

            if (item != null)
            {
                myCart.Remove(item);
                HttpContext.Session.Set("GioHang", myCart);
            }

            return RedirectToAction("Index");
        }


        public IActionResult ClearCart()
        {
            HttpContext.Session.Remove("GioHang");

            return RedirectToAction("Index");
        }

        public IActionResult Checkout()
        {
            // Lấy thông tin giỏ hàng từ Session
            var cartItems = HttpContext.Session.Get<List<CartItem>>("GioHang");
            if (cartItems == null || cartItems.Count == 0)
            {
                return RedirectToAction("Index");
            }

            // Lấy thông tin khách hàng từ Session
            var maKh = HttpContext.Session.GetInt32("MaKh");
            var khachHang = _context.KhachHangs.FirstOrDefault(kh => kh.MaKh == maKh);
            
            // Tạo đơn hàng mới

            var hoaDon = new HoaDon
            {

                MaKh = maKh.ToString(), 
                NgayDat = DateTime.Now,
                TrangThai = 0, // Trạng thái đơn hàng mới được đặt là chưa xử lý
                PhiVanChuyen = cartItems.Sum(ci => ci.SoLuong * ci.DonGia)
            };

            // Lưu đơn hàng vào cơ sở dữ liệu
            _context.HoaDons.Add(hoaDon);
            _context.SaveChanges();

            // Tạo chi tiết đơn hàng và lưu vào cơ sở dữ liệu
            foreach (var cartItem in cartItems)
            {
                var chiTietHd = new ChiTietHd
                {
                    MaHd = hoaDon.MaHd,
                    MaHh = cartItem.MaHh,
                    DonGia = cartItem.DonGia,
                    SoLuong = cartItem.SoLuong,
                    GiamGia = 0
                };
                _context.ChiTietHds.Add(chiTietHd);
            }
            _context.SaveChanges();

            // Xóa giỏ hàng
            HttpContext.Session.Remove("GioHang");

            // Hiển thị trang thông báo thanh toán thành công và thông tin đơn hàng
            return View("CheckoutSuccess", hoaDon);
        }*/
    }
  

}
