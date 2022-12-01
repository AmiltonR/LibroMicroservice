using Libros.API.Repository;
using Libros.Domain.DTOs;
using Libros.Domain.DTOs.GetDTOs;
using Libros.Domain.DTOs.PostDTOs;
using Libros.Domain.DTOs.PutDTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Libros.API.Controllers
{
    [Route("api/BooksDetails")]
    [ApiController]
    public class BooksDetailsController : ControllerBase
    {
        protected ResponseDTO _responseDTO;
        protected ResponseVoidDTO _responseVoidDTO;
        private IBookDetailsRepository _bookDetailsRepository;
        public BooksDetailsController(IBookDetailsRepository bookDetailsRepository)
        {
            _bookDetailsRepository = bookDetailsRepository;
            _responseDTO = new ResponseDTO();
            _responseVoidDTO = new ResponseVoidDTO();
        }

        [HttpGet]
        //Obtiene todos los libros. Se usa en el microservicio de préstamos
        public async Task<Object> GetAllBooks()
        {
            IEnumerable<LibrosDTO> librosDto = null;
            try
            {
                librosDto = await _bookDetailsRepository.GetAllBooks();
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
        [Route("{id}")]
        public async Task<Object> GetBooks(int id)
        {
            IEnumerable<LibrosDetalleDTO> librosDto = null;
            try
            {
                librosDto = await _bookDetailsRepository.GetLibrosDetalle(id);
                _responseDTO.Result = librosDto;
                _responseDTO.Success = true;
                _responseDTO.Message ="Libros";
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
        [Route("get/{id}")]
        public async Task<Object> GetBookById(int id)
        {
            LibrosDetalleDTO librosDto = null;
            try
            {
                librosDto = await _bookDetailsRepository.GetLibroDetalleById(id);
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

        [HttpPost]
        public async Task<Object> Post(LibrosEncPutNewBooks libros)
        {
            LibrosEncPutNewBooks _libros = libros;
            try
            {
                await _bookDetailsRepository.SaveNewBook(_libros);
                _responseVoidDTO.Success = true;
                _responseVoidDTO.Message = "Los libros has sido registrados correctamente";
            }
            catch (Exception ex)
            {
                _responseVoidDTO.ErrorMessages = new List<string>() { ex.ToString() };
                throw;
            }
            return Ok(_responseVoidDTO);
        }

        [HttpPut]
        public async Task<Object> Put(LibrosDetallePutDTO libroUpdate)
        {
            LibrosDetallePutDTO _libro = libroUpdate;
            try
            {
                await _bookDetailsRepository.UpdateBook(_libro);
                _responseVoidDTO.Success = true;
                _responseVoidDTO.Message = "El  ha sido Actualizado correctamente";
            }
            catch (Exception ex)
            {
                _responseVoidDTO.ErrorMessages = new List<string>() { ex.ToString() };
                throw;
            }
            return Ok(_responseVoidDTO);
        }

        [HttpDelete]
        [Route("{id}/{op}")]
        public async Task<Object> Delete(int id, int op)
        {
            int _id = id;
            int _op = op;
            try
            {
                await _bookDetailsRepository.DeleteBook(_id, _op);
                _responseDTO.Success = true;
                if (_op==0)
                {
                    _responseDTO.Message = "El registro del libro se desactivó correctamente";
                }
                else
                {
                    _responseDTO.Message = "El registro del libro se Activó correctamente";
                }
            }
            catch (Exception ex)
            {
                _responseDTO.ErrorMessages = new List<string>() { ex.ToString() };
                throw;
            }
            return Ok(_responseDTO);
        }
    }
}
