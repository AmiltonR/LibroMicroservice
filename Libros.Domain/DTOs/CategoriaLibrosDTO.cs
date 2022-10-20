using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libros.Domain.DTOs
{
    public class CategoriaLibrosDTO
    {
        public int IdCategoria { get; set; }
        public string NombreCategoria { get; set; }
        public int Ejemplares { get; set; }
    }
}
