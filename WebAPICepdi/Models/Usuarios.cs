using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPICepdi.Models
{
    public class Usuarios
    {   
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idUsuario { get; set; }
        public string nombre { get; set; } = string.Empty;
        public DateTime fechaCreacion { get; set; }
        public string usuario { get; set; }  = string.Empty;
        public string password { get; set; }  = string.Empty;
        public int? idPerfil { get; set; }
        public int estatus { get; set; }
    }
}