using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPICepdi.Models
{
    public class Medicamentos
    {   
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idMedicamento { get; set; }
        public string nombre { get; set; } = string.Empty;
        public string concentracion { get; set; } = string.Empty;
        public int? idformafarmaceutica { get; set; }
        public decimal? precio { get; set; }
        public int? stock { get; set; }
        public string? presentacion { get; set; } = string.Empty;
        public int? bhabilitado { get; set; }

        // Propiedad de navegación a FormasFarmaceuticasClass
        public FormasFarmaceuticasClass? FormaFarmaceutica { get; set; }
    }
}