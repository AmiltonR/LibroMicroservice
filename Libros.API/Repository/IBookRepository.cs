using Libros.Domain.DTOs;
using Libros.Domain.DTOs.GetDTOs;
using Libros.Domain.DTOs.PostDTOs;
using Libros.Domain.DTOs.PutDTOs;

namespace Libros.API.Repository
{
    public interface IBookRepository
    {
        Task<IEnumerable<LibrosEncabezadoDTO>> GetLibrosEncabezado();
        Task<LibrosEncabezadoSimpDTO> GetLibro(int id);
        Task<IEnumerable<LibrosEncabezadoDTO>> GetLibrosEncabezadoByCategory(int Id);
        Task<int> SetNewQuantity(LibrosEncPutQuantityDTO librosQuantity);
        Task<bool> SaveNewBook(LibroEncNuevoDTO libroPost);
        Task<bool> UpdateBook(LibroEncPutDTO libroUpdate);

        Task<IEnumerable<CategoriaLibrosDTO>> CategoriaLibros();
    }
}
