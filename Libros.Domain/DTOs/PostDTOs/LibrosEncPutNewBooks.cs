using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libros.Domain.DTOs.PostDTOs
{
    public class LibrosEncPutNewBooks
    {
        //Este modelo es utilizado cuando se agregan ejemplares
        //de un libro existente
        public int Id { get; set; }
        public string Isbn { get; set; }
        public char Condicion { get; set; }
        public string Editorial { get; set; }
        public string Detalle { get; set; }
        public DateTime FechaIngreso { get; set; }
    }
}
