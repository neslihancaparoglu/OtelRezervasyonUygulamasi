using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Repository.Contracts;
using System.Diagnostics;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepositoryUser _userRepository;

        public HomeController(IRepositoryUser userRepository)
        {
            _userRepository = userRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public async Task<IActionResult> Index(User user)
        {
            if (ModelState.IsValid)
            {
                bool result = await _userRepository.CreateUserAsync(user);
                if (result)
                {
                    // Başarıyla kaydedildi, istediğiniz bir işlemi yapabilirsiniz
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    // Kayıt sırasında bir hata oluştu
                    // Uygun bir hata mesajı döndürebilir veya hata sayfasına yönlendirebilirsiniz
                    return View("Error");
                }
            }

            // Model doğrulama hatası durumunda buraya gelinir
            return View();
        }
    }
}
