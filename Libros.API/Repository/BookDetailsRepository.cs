using AutoMapper;
using Libros.Domain.DTOs.GetDTOs;
using Libros.Domain.DTOs.PostDTOs;
using Libros.Domain.DTOs.PutDTOs;
using Libros.Domain.Entities;
using Libros.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Libros.API.Repository
{
    public class BookDetailsRepository : IBookDetailsRepository
    {
        //Controlador de Libros Detalle
        private readonly BookContext _db;
        private IMapper _mapper;
        private IBookRepository _bookRepository;
        public BookDetailsRepository(BookContext db, IMapper mapper, IBookRepository bookRepository)
        {
            _db = db;
            _mapper = mapper;
            _bookRepository = bookRepository;
        }

        public async Task<IEnumerable<LibrosDetalleDTO>> GetLibrosDetalle(int id)
        {
            List<LibrosDetalle> libros = await _db.LibrosDetalle.Where(l => l.IdLibro == id && l.Estado == 1).ToListAsync();
            return _mapper.Map<List<LibrosDetalleDTO>>(libros);
        }

        public async Task<LibrosDetalleDTO> GetLibroDetalleById(int id)
        {
            LibrosDetalle? libros = await _db.LibrosDetalle.Where(l => l.Id == id && l.Estado == 1).FirstOrDefaultAsync();
            return _mapper.Map<LibrosDetalle,LibrosDetalleDTO>(libros);
        }

        public async Task<bool> SaveNewBook(LibrosEncPutNewBooks libros)
        {
            bool flag = false;
            LibrosEncPutNewBooks _libros = libros;
            LibrosDetallePostSimpDTO librosDetalle = new LibrosDetallePostSimpDTO(_libros.Isbn, _libros.Condicion, _libros.Editorial,_libros.Detalle, _libros.FechaIngreso);

            try
            {
                LibrosDetalle? detalle = _mapper.Map<LibrosDetallePostSimpDTO, LibrosDetalle>(librosDetalle);
                detalle.IdLibro = _libros.Id;
                detalle.EstadoPrestamo = 'B';
                _db.LibrosDetalle.Add(detalle);
                await _db.SaveChangesAsync();

                LibrosEncPutQuantityDTO? setQuantity = new LibrosEncPutQuantityDTO(_libros.Id, 1);

                await _bookRepository.SetNewQuantity(setQuantity);
                await _db.SaveChangesAsync();
                flag = true;
            }
            catch (Exception)
            {
                throw;
            }
            return flag;
        }


        public async Task<bool> DeleteBook(int Id, int op)
        {
            int _Id = Id;
            int option = op;
            bool flag = false;
            try
            {
                LibroDetalleDeleteDTO libroSetInactive = null;
                if (op == 0)
                {
                    libroSetInactive = new LibroDetalleDeleteDTO
                    {
                        Id = _Id,
                        Estado = 0
                    };
                }
                else
                {
                    libroSetInactive = new LibroDetalleDeleteDTO
                    {
                        Id = _Id,
                        Estado = 1
                    };
                }

                LibrosDetalle libro = _mapper.Map<LibroDetalleDeleteDTO, LibrosDetalle>(libroSetInactive);
                _db.LibrosDetalle.Attach(libro);
                _db.Entry(libro).Property(x => x.Estado).IsModified = true;
                _db.SaveChanges();

                flag = true;
            }
            catch (Exception)
            {
                throw;
            }
            return flag;
        }

        public async Task<bool> UpdateBook(LibrosDetallePutDTO libroUpdate)
        {
            bool flag = false;
            LibrosDetallePutDTO libro = libroUpdate;
            LibrosDetalle libroDetalle = _mapper.Map<LibrosDetallePutDTO, LibrosDetalle>(libro);
            try
            {
                _db.LibrosDetalle.Attach(libroDetalle);
                _db.Entry(libroDetalle).Property(l => l.Isbn).IsModified = true;
                _db.Entry(libroDetalle).Property(l => l.Condicion).IsModified = true;
                _db.Entry(libroDetalle).Property(l => l.Editorial).IsModified = true;
                _db.Entry(libroDetalle).Property(l => l.Detalle).IsModified = true;
                _db.Entry(libroDetalle).Property(l => l.FechaIngreso).IsModified = true;
                await _db.SaveChangesAsync();
                flag = true;
            }
            catch (Exception)
            {
                throw;
            }
            return flag;
        }
    }
}
