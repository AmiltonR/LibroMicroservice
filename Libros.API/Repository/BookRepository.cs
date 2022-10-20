using AutoMapper;
using Libros.Domain.DTOs;
using Libros.Domain.DTOs.GetDTOs;
using Libros.Domain.DTOs.PostDTOs;
using Libros.Domain.DTOs.PutDTOs;
using Libros.Domain.Entities;
using Libros.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;

namespace Libros.API.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly BookContext _db;
        private IMapper _mapper;
        public BookRepository(BookContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<IEnumerable<LibrosEncabezadoDTO>> GetLibrosEncabezado()
        {
           var query = await _db.Categoria
                .Join(
                    _db.LibrosEncabezado,
                    categoria => categoria.Id,
                    libros => libros.categoria.Id,
                    (categoria, libros) => new LibrosEncabezadoDTO
                    {
                        Id = libros.Id,
                        NombreLibro = libros.NombreLibro,
                        Autor = libros.Autor,
                        AnioPub = libros.AnioPub,
                        IdCategoria = libros.IdCategoria,
                        Categoria = categoria.NombreCategoria,
                        Ejemplares = libros.Ejemplares
                    }
                ).ToListAsync();

            List<LibrosEncabezadoDTO> librosList = query;
            return librosList;
        }
        public async Task<LibrosEncabezadoSimpDTO> GetLibro(int id)
        {
            LibrosEncabezado? libros = await _db.LibrosEncabezado.FirstOrDefaultAsync(l => l.Id == id);
            LibrosEncabezadoSimpDTO? libroDto = _mapper.Map<LibrosEncabezadoSimpDTO>(libros);
            return libroDto;
        }

        public async Task<IEnumerable<LibrosEncabezadoDTO>> GetLibrosEncabezadoByCategory(int Id)
        {
            var query = await _db.Categoria
               .Join(
                   _db.LibrosEncabezado,
                   categoria => categoria.Id,
                   libros => libros.categoria.Id,
                   (categoria, libros) => new LibrosEncabezadoDTO
                   {
                       NombreLibro = libros.NombreLibro,
                       Autor = libros.Autor,
                       AnioPub = libros.AnioPub,
                       IdCategoria = libros.IdCategoria,
                       Categoria = categoria.NombreCategoria,
                       Ejemplares = libros.Ejemplares
                   }
               ).Where(l => l.IdCategoria == Id).ToListAsync();

            List<LibrosEncabezadoDTO> librosList = query;
            return librosList;
        }
        public async Task<bool> SaveNewBook(LibroEncNuevoDTO libroPost)
        {
            bool flag = false;
            try
            {
                //Recibir parámetro como LIbroEncNuevoDTO
                LibroEncNuevoDTO libro = libroPost;

                //Dividir la respuesta
                LibrosEncabezadoPostDTO libroEncabezado = new LibrosEncabezadoPostDTO(libro.NombreLibro, libro.Autor, libro.AnioPub, libro.IdCategoria, 1);

                LibrosEncabezado libroEncabezadoAdd = _mapper.Map<LibrosEncabezadoPostDTO, LibrosEncabezado>(libroEncabezado);

                _db.LibrosEncabezado.Add(libroEncabezadoAdd);
                await _db.SaveChangesAsync();

                LibrosEncabezado? libroConsulta = await _db.LibrosEncabezado.Where(x => x.NombreLibro == libro.NombreLibro).FirstOrDefaultAsync();

                int idLibro = libroConsulta.Id;

                LibrosDetallePostSimpDTO librosDetalle = new LibrosDetallePostSimpDTO(libro.Isbn, libro.Condicion, libro.Editorial, libro.Detalle, libro.FechaIngreso);
                //Guardar los Libros en LibroDetalles
                try
                {
                    LibrosDetalle librosDetalleAdd = _mapper.Map<LibrosDetallePostSimpDTO, LibrosDetalle>(librosDetalle);
                    librosDetalleAdd.IdLibro = idLibro;
                    librosDetalleAdd.EstadoPrestamo = 'B';
                    _db.LibrosDetalle.Add(librosDetalleAdd);
                    await _db.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    throw;
                }

                flag = true;

            }
            catch (Exception ex)
            {
                throw;
            }
            return flag;
        }

        public async Task<int> SetNewQuantity(LibrosEncPutQuantityDTO librosQuantity)
        {
            int flag = 0;
            LibrosEncPutQuantityDTO librosQ = librosQuantity;
            LibrosEncabezado librosEncabezado = _mapper.Map<LibrosEncPutQuantityDTO, LibrosEncabezado>(librosQ);
            LibrosEncabezado? libros = await _db.LibrosEncabezado.Where(x => x.Id == librosQ.Id).FirstOrDefaultAsync();
            libros.Ejemplares = libros.Ejemplares + librosQ.Ejemplares;
            flag = await _db.SaveChangesAsync();
            return flag;
        }

        public async Task<bool> UpdateBook(LibroEncPutDTO libroUpdate)
        {
            bool flag = false;
            try
            {
                LibroEncPutDTO libro = libroUpdate;
                LibrosEncabezado libroEncabezado = _mapper.Map<LibroEncPutDTO, LibrosEncabezado>(libro);
                _db.LibrosEncabezado.Attach(libroEncabezado);
                _db.Entry(libroEncabezado).Property(l => l.NombreLibro).IsModified = true;
                _db.Entry(libroEncabezado).Property(l => l.Autor).IsModified = true;
                _db.Entry(libroEncabezado).Property(l => l.AnioPub).IsModified = true;
                _db.Entry(libroEncabezado).Property(l => l.IdCategoria).IsModified = true;
                await _db.SaveChangesAsync();
                flag = true;

            }
            catch (Exception)
            { 
                throw;
            }
            return flag;
        }

        public async Task<IEnumerable<CategoriaLibrosDTO>> CategoriaLibros()
        {
            var query = _db.LibrosEncabezado
                     .GroupBy(l => new { l.IdCategoria, l.Ejemplares, l.categoria.NombreCategoria })
                    .Select(g => new
                    {
                        g.Key.IdCategoria,
                        g.Key.NombreCategoria,
                        Ejemplares = g.Sum(o => o.Ejemplares),
                    });

            List<CategoriaLibrosDTO> list = new List<CategoriaLibrosDTO>();
            foreach (var item in query)
            {
                var r = new CategoriaLibrosDTO
                {
                    IdCategoria = item.IdCategoria,
                    NombreCategoria = item.NombreCategoria,
                    Ejemplares = item.Ejemplares
                };
                list.Add(r);
            }

            return list;
        }
    }
}

