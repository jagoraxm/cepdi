using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPICepdi.Models
{
    public class FormasFarmaceuticasClass
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idFormaFarmaceutica { get; set; }
        public string nombre { get; set; } = string.Empty;
        public int? habilitado { get; set; }
        public ICollection<Medicamentos> Medicamentoss { get; set; }
    }
}