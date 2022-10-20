using AutoMapper;
using Libros.Domain.DTOs.GetDTOs;
using Libros.Domain.DTOs.PostDTOs;
using Libros.Domain.DTOs.PutDTOs;
using Libros.Domain.Entities;
using System.Net.Http.Headers;

namespace Libros.API
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<LibrosEncabezado, LibrosEncPutQuantityDTO>();
                config.CreateMap<LibrosEncPutQuantityDTO, LibrosEncabezado>();
                //Detalle
                config.CreateMap<LibrosDetalle, LibrosDetalleDTO>();
                config.CreateMap<LibrosDetalleDTO, LibrosDetalle>();

                config.CreateMap<LibrosDetallePostSimpDTO, LibrosDetalle>();
                config.CreateMap<LibrosDetalle, LibrosDetallePostSimpDTO>();

                //Encabezado nuevo libro
                config.CreateMap<LibrosEncabezadoPostDTO, LibrosEncabezado>();
                config.CreateMap<LibrosEncabezado, LibrosEncabezadoPostDTO>();

                config.CreateMap<LibroEncPutDTO, LibrosEncabezado>();
                config.CreateMap<LibrosEncabezado, LibroEncPutDTO>();

                config.CreateMap<LibroDetalleDeleteDTO, LibrosDetalle>();
                config.CreateMap<LibrosDetalle, LibroDetalleDeleteDTO>();

                
                config.CreateMap<LibrosDetallePutDTO, LibrosDetalle>();
                config.CreateMap<LibrosDetalle, LibrosDetallePutDTO>();

                config.CreateMap<LibrosEncabezadoSimpDTO, LibrosEncabezado>();
                config.CreateMap<LibrosEncabezado, LibrosEncabezadoSimpDTO>();

                //CATEGORIAS
                config.CreateMap<Categorias, CategoriaPostDTO>();
                config.CreateMap<CategoriaPostDTO, Categorias>();

                config.CreateMap<Categorias, CategoriaDTO>();
                config.CreateMap<CategoriaDTO, Categorias>();

            });
            return mappingConfig;
        }
    }
}
