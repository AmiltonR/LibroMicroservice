using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libros.Domain.Entities
{
    public class LibrosEncabezado
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string NombreLibro { get; set; }
        [Required]
        public string Autor { get; set; }
        [Required]
        public string AnioPub { get; set; }
        [Required]
        [ForeignKey("categoria")]
        public int IdCategoria { get; set; }
        [Required]
        public int Ejemplares { get; set; }
        [ForeignKey("IdCategoria")]
        public Categorias categoria { get; set; }
    }
}
