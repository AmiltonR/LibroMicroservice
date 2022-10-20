using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libros.Domain.Entities
{
    public class LibrosDetalle
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [ForeignKey("librosEncabezado")]
        public int IdLibro { get; set; }
        [Required]
        public string Isbn { get; set; }
        [Required]
        public char Condicion { get; set; }
        public string Detalle { get; set; }
        public string Editorial { get; set; }
        public char EstadoPrestamo { get; set; }
        [Required]
        public DateTime FechaIngreso { get; set; }
        public int Estado { get; set; } = 1;
        [ForeignKey("IdLibro")]
        public virtual LibrosEncabezado librosEncabezado { get; set; }
    }
}
