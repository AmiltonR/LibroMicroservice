using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libros.Domain.DTOs.GetDTOs
{
    public class LibrosDTO
    {
        public int Id { get; set; }
        public string NombreLibro { get; set; }
        public string Isbn { get; set; }
        public string  Condicion { get; set; }
        public string Editorial { get; set; }
        public string Detalle { get; set; }
        public string  FechaIngreso { get; set; }
    }
}
