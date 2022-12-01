using Libros.Domain.DTOs.GetDTOs;
using Libros.Domain.DTOs.PostDTOs;
using Libros.Domain.DTOs.PutDTOs;

namespace Libros.API.Repository
{
    public interface IBookDetailsRepository
    {
        Task<IEnumerable<LibrosDTO>> GetAllBooks();
        Task<IEnumerable<LibrosDetalleDTO>> GetLibrosDetalle(int id);
        Task<LibrosDetalleDTO> GetLibroDetalleById(int id);
        Task<bool> SaveNewBook(LibrosEncPutNewBooks libros);
        Task<bool> DeleteBook(int id, int op);
        Task<bool> UpdateBook(LibrosDetallePutDTO libroUpdate);
    }
}
