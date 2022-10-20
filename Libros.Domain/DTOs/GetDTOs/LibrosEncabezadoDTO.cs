using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libros.Domain.DTOs.GetDTOs
{
    public class LibrosEncabezadoDTO
    {
        //Este modelo es utilizado para traer los registros de la base de datos
        //de la entidad LibrosEncabezado
        public int Id { get; set; }
        public string NombreLibro { get; set; }
        public string Autor { get; set; }
        public string AnioPub { get; set; }
        public int IdCategoria { get; set; }
        public string Categoria { get; set; }
        public int Ejemplares { get; set; }
    }
}
