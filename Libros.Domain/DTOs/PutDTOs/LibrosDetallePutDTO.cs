using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libros.Domain.DTOs.PutDTOs
{
    public class LibrosDetallePutDTO
    {
        public LibrosDetallePutDTO(string isbn, char condicion, string editorial, string detalle, DateTime fechaIngreso)
        {
            Isbn = isbn;
            Condicion = condicion;
            Editorial = editorial;
            Detalle = detalle;
            FechaIngreso = fechaIngreso;
        }

        //Este modelo se utiliza para almacenar un lote de un 
        //libro existente
        //Se referencia a este modelo desde LibrosEncPutNewBooks
        public int Id { get; set; }
        public string Isbn { get; set; }
        public char Condicion { get; set; }
        public string Editorial { get; set; }
        public string Detalle { get; set; }
        public DateTime FechaIngreso { get; set; }
    }
}
