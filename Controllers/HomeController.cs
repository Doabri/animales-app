using Microsoft.AspNetCore.Mvc;
using Tarea_Unidad_3.Models.ViewModels;
using Tarea_Unidad_3.Repositories;

namespace Tarea_Unidad_3.Controllers
{
    public class HomeController : Controller
    {
        EspeciesRepository especiesRepo = new();
        ClaseRepository claseRepo = new();
        public IActionResult Index()
        {
            ClaseRepository claseRepo = new();
            var clases = claseRepo.GetAll();
            var vm = new AnimalesViewModels.IndexViewModel
            {
                Clases = clases.Select(x => new AnimalesViewModels.ClaseModel
                {
                    Id = x.Id,
                    Nombre = x.Nombre ?? "",
                    Descripcion = x.Descripcion
                }),
                Especies = new List<AnimalesViewModels.EspecieModel>()
            };

            return View(vm);
        }

        public IActionResult Clases(int id)
        {
            var clase = claseRepo.Get(id);

            if (clase == null)
            {
                return NotFound();
            }

            var especies = especiesRepo.GetByClase(id);

            var vm = new AnimalesViewModels.IndexViewModel
            {
                IdClaseSeleccionada = id,
                Clases = new List<AnimalesViewModels.ClaseModel> {
                    new AnimalesViewModels.ClaseModel {
                        Id = clase.Id,
                        Nombre = clase.Nombre ?? "" ,
                        Descripcion = clase.Descripcion
                    }
                },
                Especies = especies.Select(x => new AnimalesViewModels.EspecieModel
                {
                    Id = x.Id,
                    Especie = x.Especie,
                    Habitat = x.Habitat,
                    Peso = x.Peso,
                    Tamaño = x.Tamaño,
                    Observaciones = x.Observaciones,
                    ClaseNombre = clase.Nombre
                })
            };

            return View(vm);
        }

        public IActionResult Detalles(int id)
        {
            var especie = especiesRepo.Get(id);
            if (especie == null)
            {
                return NotFound();
            }

            // Buscar la clase asociada
            var clase = claseRepo.Get(especie.IdClase ?? 0);

            // Mapear a DetallesViewModel
            var vm = new AnimalesViewModels.DetallesViewModel
            {
                Id = especie.Id,
                Especie = especie.Especie,
                Habitat = especie.Habitat,
                Peso = especie.Peso,
                Tamaño = especie.Tamaño,
                Observaciones = especie.Observaciones,
                ClaseNombre = clase?.Nombre
            };

            return View(vm);
        }
    }
}


