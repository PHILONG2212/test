using Microsoft.AspNetCore.Mvc;
using project2.Entities;

namespace project2.Areas.ADMINS.Controllers
{
    public class KhachHangController : Controller
    {
        private readonly TourdulichContext _context;

        public KhachHangController(TourdulichContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
