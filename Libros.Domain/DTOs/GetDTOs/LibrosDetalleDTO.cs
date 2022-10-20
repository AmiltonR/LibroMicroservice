using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libros.Domain.DTOs.GetDTOs
{
    public class LibrosDetalleDTO
    {
        public int Id { get; set; }
        //public string NombreLibro { get; set; }
        public string Isbn { get; set; }
        public char Condicion { get; set; }
        public char EstadoPrestamo { get; set; }
        public string Editorial { get; set; }
        public string Detalle { get; set; }
        public DateTime Fecha_Ingreso { get; set; }
        public int Estado { get; set; }
    }
}
