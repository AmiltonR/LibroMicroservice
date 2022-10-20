using Libros.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libros.Infrastructure
{
    public class BookContext : DbContext
    {
        public BookContext(DbContextOptions<BookContext> options) : base(options)
        {

        }
        public DbSet<Categorias> Categoria { get; set; }
        public DbSet<LibrosEncabezado> LibrosEncabezado { get; set; }
        public DbSet<LibrosDetalle> LibrosDetalle { get; set; }
        
    }
}
