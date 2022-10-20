using Libros.API.Repository;
using Libros.Domain.DTOs;
using Libros.Domain.DTOs.GetDTOs;
using Libros.Domain.DTOs.PostDTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Libros.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        protected ResponseDTO _responseDTO;
        protected ResponseVoidDTO _responseVoidDTO;
        private ICategoryRepository _categoryRepository;
        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
            _responseVoidDTO = new ResponseVoidDTO();
            _responseDTO = new ResponseDTO();
        }

        [HttpGet]
        public async Task<Object> Get()
        {
            IEnumerable<CategoriaDTO> categoriaDTO = null;
            try
            {
                categoriaDTO = await _categoryRepository.GetCategories();
                _responseDTO.Success = true;
                _responseDTO.Result = categoriaDTO;
                _responseDTO.Message = "Listado de Categorías";
            }
            catch (Exception ex)
            {
                _responseDTO.Message = "Algo ocurrió :(";
                _responseDTO.ErrorMessages = new List<string>() { ex.ToString() };
                throw;
            }
            return Ok(_responseDTO);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<Object> GetById(int id)
        {
            string nombreCategoria = string.Empty;
            try
            {
                nombreCategoria = await _categoryRepository.GetCategoryById(id);
                _responseDTO.Success = true;
                _responseDTO.Result = nombreCategoria;
                _responseDTO.Message = "Categorías";
            }
            catch (Exception ex)
            {
                _responseDTO.Message = "Algo ocurrió :(";
                _responseDTO.ErrorMessages = new List<string>() { ex.ToString() };
                throw;
            }
            return Ok(_responseDTO);
        }

        [HttpPost]
        public async Task<object> Post(CategoriaPostDTO categoria)
        {
            try
            {
                await _categoryRepository.AddCategory(categoria);
                _responseVoidDTO.Success = true;
                _responseVoidDTO.Message = "Ha registrado una nueva Categoria";
            }
            catch (Exception ex)
            {
                _responseVoidDTO.Message = "Algo ocurrió :(";
                _responseVoidDTO.ErrorMessages = new List<string>() { ex.ToString() };
                throw;
            }
            return Ok(_responseVoidDTO);
        }

        [HttpPut]
        public async Task<object> Put(CategoriaDTO categoria)
        {
            try
            {
                await _categoryRepository.UpdateCategory(categoria);
                _responseVoidDTO.Success = true;
                _responseVoidDTO.Message = "Ha actualizado la Categoria";
            }
            catch (Exception ex)
            {
                _responseVoidDTO.Message = "Algo ocurrió :(";
                _responseVoidDTO.ErrorMessages = new List<string>() { ex.ToString() };
                throw;
            }
            return Ok(_responseVoidDTO);
        }
    }
}
