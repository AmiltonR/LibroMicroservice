using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libros.Domain.DTOs.PutDTOs
{
    public class LibroDetalleDeleteDTO
    {
        public int Id { get; set; }
        public int Estado { get; set; } = 1;
    }
}
