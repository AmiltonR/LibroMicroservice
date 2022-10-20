using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libros.Domain.DTOs.PutDTOs
{
    public class LibrosEncPutQuantityDTO
    {
        //Este modelo se utiliza para actualizar el campo ejemplares en 
        //la entidad LibrosEncabezado
        public LibrosEncPutQuantityDTO(int id, int ejemplares)
        {
            Id = id;
            Ejemplares = ejemplares;
        }

        public int Id { get; set; }
        public int Ejemplares { get; set; }
    }
}
