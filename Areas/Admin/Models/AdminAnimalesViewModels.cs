using System.ComponentModel.DataAnnotations;

namespace Tarea_Unidad_3.Models.ViewModels
{
    public class AdminAnimalesViewModels
    {
        public class AgregarEspecieViewModel
        {
            [Required(ErrorMessage = "El nombre de la especie es requerido")]
            public string Especie { get; set; } = null!;

            [Required(ErrorMessage = "Debe seleccionar una clase")]
            public int IdClase { get; set; }

            public string Habitat { get; set; } = null!;

            [Range(0.01, double.MaxValue, ErrorMessage = "El peso debe ser mayor a 0")]
            public double Peso { get; set; }

            [Range(1, int.MaxValue, ErrorMessage = "El tamaño debe ser mayor a 0")]
            public int Tamaño { get; set; }

            public string? Observaciones { get; set; }

            public IFormFile? Imagen { get; set; }

            // Para llenar el dropdown
            public IEnumerable<AnimalesViewModels.ClaseModel>? Clases { get; set; }
        }

        public class EditarEspecieViewModel : AgregarEspecieViewModel
        {
            public int Id { get; set; }
        }

        public class EliminarEspecieViewModel
        {
            public int Id { get; set; }
            public string Especie { get; set; } = null!;
            public int IdClase { get; set; }
            public string Habitat { get; set; } = null!;
            public double Peso { get; set; }
            public int Tamaño { get; set; }
            public string? Observaciones { get; set; }
        }
    }
}
