using Microsoft.AspNetCore.Mvc;
using project2.Entities;

namespace project2.Areas.ADMINS.Controllers
{
    [Area("ADMINS")]
    public class TourController : Controller
    {

        private readonly TourdulichContext _context;

        public TourController(TourdulichContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.Tours);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Tour loai, IFormFile Hinh)
        {
            if (ModelState.IsValid)
            {
                if (Hinh != null)
                {
                    var urlFull = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Hinh", "Tour", Hinh.FileName);
                    using (var file = new FileStream(urlFull, FileMode.Create))
                    {
                        await Hinh.CopyToAsync(file);
                    }

                    loai.Hinh = Hinh.FileName;
                }

                _context.Add(loai);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Edit(int id)
        {
            var loai = _context.Tours.SingleOrDefault(lo => lo.MaTour == id);
            if (loai == null)
            {
                return RedirectToAction("Index");
            }

            return View(loai);
        }

        [HttpPost]
        public IActionResult Edit(Tour loai, IFormFile HinhUpload)
        {
            if (ModelState.IsValid)
            {
                if (HinhUpload != null)
                {
                    var urlFull = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Hinh", "Loai", HinhUpload.FileName);
                    using (var file = new FileStream(urlFull, FileMode.Create))
                    {
                        HinhUpload.CopyTo(file);
                    }

                    loai.Hinh = HinhUpload.FileName;
                }

                _context.Update(loai);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Delete(int id)
        {
            KhachSan tour = _context.KhachSans.Where(row => row.MaKhachSan == id).FirstOrDefault();
            return View(tour);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id, KhachSan p)
        {

            KhachSan khachSan = _context.KhachSans.Where(row => row.MaKhachSan == id).FirstOrDefault();
            _context.KhachSans.Remove(khachSan);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
