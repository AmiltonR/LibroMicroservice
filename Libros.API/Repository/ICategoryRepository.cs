using Libros.Domain.DTOs.GetDTOs;
using Libros.Domain.DTOs.PostDTOs;
using Libros.Domain.DTOs.PutDTOs;

namespace Libros.API.Repository
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<CategoriaDTO>> GetCategories();
        Task<string> GetCategoryById(int id);
        Task<bool> UpdateCategory(CategoriaDTO categoria);

        Task<bool> AddCategory(CategoriaPostDTO categoria);
    }
}
