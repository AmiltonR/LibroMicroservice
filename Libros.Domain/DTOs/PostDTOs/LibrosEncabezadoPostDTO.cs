using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libros.Domain.DTOs.PostDTOs
{
    public class LibrosEncabezadoPostDTO
    {
        //Cuando se recibe un lote de libros de un nuevo libro, la respuesta se divide en dos
        //y el encabezado es capurado por este modelo. Este modelo se mapeará a la entidad LibrosEncabezado
        public LibrosEncabezadoPostDTO(string nombreLibro, string autor, string anioPub, int idCategoria, int ejemplares)
        {
            NombreLibro = nombreLibro;
            Autor = autor;
            AnioPub = anioPub;
            IdCategoria = idCategoria;
            Ejemplares = ejemplares;
        }

        public string NombreLibro { get; set; }
        public string Autor { get; set; }
        public string AnioPub { get; set; }
        public int IdCategoria { get; set; }
        public int Ejemplares { get; set; }
    }
}
