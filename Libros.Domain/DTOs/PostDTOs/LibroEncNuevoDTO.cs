using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libros.Domain.DTOs.PostDTOs
{
    public class LibroEncNuevoDTO
    {
        //Utilicese cuando se desea registrar un lote de libros del
        //que no existían ejemplares anteriormente
        //Se tendrá que aneexar los detalles de un libro para crear el registro en ambas tablas
        //Encabezado - Detalle

        //Modela la estructura Json de respuesta
        public string NombreLibro { get; set; }
        public string Autor { get; set; }
        public string AnioPub { get; set; }
        public int IdCategoria { get; set; }
        public int Ejemplares { get; set; } = 1;
        public string Isbn { get; set; }
        public char Condicion { get; set; } = 'N';
        public string Editorial { get; set; }
        public string Detalle { get; set; }
        public DateTime FechaIngreso { get; set; }
    }
}
