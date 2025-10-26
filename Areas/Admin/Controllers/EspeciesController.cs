using Microsoft.AspNetCore.Mvc;
using Tarea_Unidad_3.Services;
using static Tarea_Unidad_3.Models.ViewModels.AdminAnimalesViewModels;

namespace Tarea_Unidad_3.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class EspeciesController : Controller
    {
        private readonly EspeciesService especiesService;

        public EspeciesController(EspeciesService especiesService)
        {
            this.especiesService = especiesService;
        }

        [HttpGet]
        [HttpPost]
        public IActionResult Index(int? id)
        {
            var vm = especiesService.GetEspeciesAdmin(id);
            return View(vm);
        }

        [HttpGet]
        public IActionResult Agregar()
        {
            var vm = especiesService.GetForAgregar();
            return View(vm);
        }

        [HttpPost]
        public IActionResult Agregar(AgregarEspecieViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                vm.Clases = especiesService.GetForAgregar().Clases;
                return View(vm);
            }

            especiesService.Agregar(vm);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Editar(int id)
        {
            EditarEspecieViewModel vm;
            try
            {
                vm = especiesService.GetForEditar(id);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                vm = new EditarEspecieViewModel
                {
                    Id = id,
                    Clases = especiesService.GetForAgregar().Clases
                };
            }
            return View(vm);
        }

        [HttpPost]
        public IActionResult Editar(EditarEspecieViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                vm.Clases = especiesService.GetForAgregar().Clases;
                return View(vm);
            }

            especiesService.Editar(vm);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Eliminar(int id)
        {
            EliminarEspecieViewModel vm;
            try
            {
                vm = especiesService.GetForEliminar(id);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                vm = new EliminarEspecieViewModel { Id = id };
            }
            return View(vm);
        }

        [HttpPost]
        public IActionResult Eliminar(EliminarEspecieViewModel vm)
        {
            try
            {
                especiesService.Eliminar(vm.Id);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(vm);
            }

            return RedirectToAction("Index");
        }
    }
}
