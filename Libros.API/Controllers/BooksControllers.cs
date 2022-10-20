using Libros.API.Repository;
using Libros.Domain.DTOs;
using Libros.Domain.DTOs.GetDTOs;
using Libros.Domain.DTOs.PostDTOs;
using Libros.Domain.DTOs.PutDTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Libros.API.Controllers
{
    [Route("api/Books")]
    [ApiController]
    public class BooksControllers : Controller
    {
        protected ResponseDTO _responseDTO;
        protected ResponseVoidDTO _responseVoidDTO;
        private IBookRepository _bookRepository;
        public BooksControllers(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
            _responseVoidDTO = new ResponseVoidDTO();
            _responseDTO = new ResponseDTO();
        }

        [HttpGet]
        public async Task<Object> Get()
        {
            IEnumerable<LibrosEncabezadoDTO> librosDto = null;
            try
            {
                librosDto = await _bookRepository.GetLibrosEncabezado();
                _responseDTO.Result = librosDto;
                _responseDTO.Success = true;
                _responseDTO.Message = "Libros";
            }
            catch (Exception ex)
            {
                _responseDTO.Message = "Algo ocurió :(";
                _responseDTO.ErrorMessages = new List<string>() { ex.ToString() };
                throw;
            }
            return Ok(_responseDTO);
        }

        [HttpGet]
        [Route("CategoriaLibros")]
        public async Task<Object> GetCategoriaLibros()
        {
            IEnumerable<CategoriaLibrosDTO> list = null;
            try
            {
                list = await _bookRepository.CategoriaLibros();
                _responseDTO.Result = list;
                _responseDTO.Success = true;
                _responseDTO.Message = "Libros";
            }
            catch (Exception ex)
            {
                _responseDTO.Message = "Algo ocurió :(";
                _responseDTO.ErrorMessages = new List<string>() { ex.ToString() };
                throw;
            }
            return Ok(_responseDTO);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<Object> GetById(int id)
        {
            LibrosEncabezadoSimpDTO libroDto = null;
            try
            {
                libroDto = await _bookRepository.GetLibro(id);
                _responseDTO.Result = libroDto;
                _responseDTO.Success = true;
                _responseDTO.Message = "Libro";
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
        [Route("Category/{id}")]
        public async Task<Object> GetByCategoy(int id)
        {
            IEnumerable<LibrosEncabezadoDTO> libroDto = null;
            try
            {
                libroDto = await _bookRepository.GetLibrosEncabezadoByCategory(id);
                _responseDTO.Result = libroDto;
                _responseDTO.Success = true;
                _responseDTO.Message = "Listado de Libros";
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
        public async Task<Object> Post(LibroEncNuevoDTO libroNuevo)
        {
            LibroEncNuevoDTO libro = libroNuevo;
            try
            {
                bool flag = await _bookRepository.SaveNewBook(libro);
                if (flag)
                {
                    _responseVoidDTO.Success = true;
                    _responseVoidDTO.Message = "Datos guardados. ¡Ha registrado un Nuevo Libro!";
                }
            }
            catch (Exception ex)
            {
                _responseVoidDTO.Message = "Algo ocurrió :(";
                _responseVoidDTO.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return Ok(_responseVoidDTO);
        }

        [HttpPut]
        public async Task<Object> Put(LibroEncPutDTO libroUpdate)
        {
            LibroEncPutDTO libro = libroUpdate;
            try
            {
                bool flag = await _bookRepository.UpdateBook(libro);
                if (flag)
                {
                    _responseVoidDTO.Success = true;
                    _responseVoidDTO.Message = "Datos Actualizadoss";
                }
            }
            catch (Exception ex)
            {
                _responseVoidDTO.Message = "Ocurrió un Error :(";
                _responseVoidDTO.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return Ok(_responseVoidDTO);
        }
    }
}
