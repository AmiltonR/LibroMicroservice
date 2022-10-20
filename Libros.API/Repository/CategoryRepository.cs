using AutoMapper;
using Libros.Domain.DTOs.GetDTOs;
using Libros.Domain.DTOs.PostDTOs;
using Libros.Domain.Entities;
using Libros.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Libros.API.Repository
{
    public class CategoryRepository: ICategoryRepository
    {
        private readonly BookContext _db;
        private IMapper _mapper;

        public CategoryRepository(BookContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public async Task<IEnumerable<CategoriaDTO>> GetCategories()
        {
            try
            {
                List<Categorias> categorias = await _db.Categoria.ToListAsync();
                return _mapper.Map<List<CategoriaDTO>>(categorias);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> UpdateCategory(CategoriaDTO categoria)
        {

            bool flag = false;
            CategoriaDTO _categoria = categoria;
            try
            {
                Categorias categorias = _mapper.Map<CategoriaDTO, Categorias>(_categoria);
                _db.Categoria.Update(categorias);
                await _db.SaveChangesAsync();
                flag = false;
            }
            catch (Exception)
            {
                throw;
            }

            return flag;
        }

        public async Task<bool> AddCategory(CategoriaPostDTO categoria)
        {
            bool flag = false;
            CategoriaPostDTO _categoria = categoria;
            try
            {
                Categorias categorias = _mapper.Map<CategoriaPostDTO, Categorias>(_categoria);
                _db.Categoria.Add(categorias);
                await _db.SaveChangesAsync();
                flag = false;
            }
            catch (Exception)
            {
                throw;
            }

            return flag;
        }

        public async Task<string> GetCategoryById(int id)
        {
            try
            {
                Categorias? categoria = await _db.Categoria.FirstOrDefaultAsync(c => c.Id == id);
                string nombreCategoria= _mapper.Map<CategoriaDTO>(categoria).NombreCategoria;
                return nombreCategoria ;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
