using Microsoft.AspNetCore.Mvc;
using BasicMVCAPP.Services;

namespace BasicMVCAPP.Controllers
{
    public class AboutController : Controller
    {
        private readonly Contributers _contributers;

        public AboutController(Contributers c)
        {
            this._contributers = c;
        }
        public IActionResult Index()
        {
            var Contributers_=_contributers.GetAll();
            return View(Contributers_);
        }
    }
}
