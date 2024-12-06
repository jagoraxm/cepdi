using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPICepdi.Models
{
    public class FormasFarmaceuticasClass
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string nombre { get; set; } = string.Empty;
        public int? habilitado { get; set; }
        public ICollection<Medicamentos> Medicamentoss { get; set; }
    }
}