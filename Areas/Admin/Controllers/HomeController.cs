using Microsoft.AspNetCore.Mvc;
using Tarea_Unidad_3.Services;

namespace Tarea_Unidad_3.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        private readonly EspeciesService especiesService;

        public HomeController(EspeciesService especiesService)
        {
            this.especiesService = especiesService;
        }

        public IActionResult Index(int? id)
        {
            var vm = especiesService.GetEspeciesAdmin(id);
            return View(vm);
        }
    }

}
