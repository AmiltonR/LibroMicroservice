﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libros.Domain.DTOs.GetDTOs
{
    public class LibrosEncabezadoSimpDTO
    {
        public string NombreLibro { get; set; }
        public string Autor { get; set; }
        public string AnioPub { get; set; }
        public int IdCategoria { get; set; }
    }
}
