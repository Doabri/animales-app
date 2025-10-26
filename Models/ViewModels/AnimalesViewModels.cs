namespace Tarea_Unidad_3.Models.ViewModels
{
    public class AnimalesViewModels
    {
        public class IndexViewModel
        {
            public IEnumerable<ClaseModel> Clases { get; set; } = null!;
            public IEnumerable<EspecieModel> Especies { get; set; } = null!;
            public int IdClaseSeleccionada { get; set; }
        }
        public class ClaseModel
        {
            public int Id { get; set; }
            public string Nombre { get; set; } = null!;
            public string? Descripcion { get; set; }
        }
        public class EspecieModel
        {
            public int Id { get; set; }
            public string Especie { get; set; } = null!;
            public string? Habitat { get; set; }
            public double? Peso { get; set; }
            public int? Tamaño { get; set; }
            public string? Observaciones { get; set; }
            public string? ClaseNombre { get; set; }
        }
        public class DetallesViewModel
        {
            public int Id { get; set; }
            public string Especie { get; set; } = null!;
            public string? Habitat { get; set; }
            public double? Peso { get; set; }
            public int? Tamaño { get; set; }
            public string? Observaciones { get; set; }
            public string? ClaseNombre { get; set; }
        }

    }
}

