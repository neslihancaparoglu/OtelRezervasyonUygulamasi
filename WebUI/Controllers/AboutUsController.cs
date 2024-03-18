using Entities.ModelsDto;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace WebUI.Controllers
{
    public class AboutUsController : Controller
    {
        private readonly IAboutUsService _aboutService;

        public AboutUsController(IAboutUsService aboutService)
        {
            _aboutService = aboutService;
        }

        public IActionResult Index()
        {
            var about = _aboutService.GetAllAboutUs();
            return View("ShowAboutUs", about);
        }
    }
}
