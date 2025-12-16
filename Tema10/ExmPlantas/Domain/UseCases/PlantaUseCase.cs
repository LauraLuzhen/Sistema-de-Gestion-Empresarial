using Proyecto.Domain.Dtos;
using Proyecto.Domain.Entities;
using Proyecto.Domain.Interfaces.Repositories;
using Proyecto.Domain.Interfaces.UseCases;

namespace Proyecto.Domain.UseCases
{
    public class PlantaUseCase : IPlantaUseCase
    {
        private readonly IPlantasRepository _plantasRepository;
        private readonly ICategoriaRepository _categoriaRepository;

        // Inyección de dependencias de ambos repositorios
        public PlantaUseCase(IPlantasRepository plantasRepository, ICategoriaRepository categoriaRepository)
        {
            _plantasRepository = plantasRepository;
            _categoriaRepository = categoriaRepository;
        }

        public int updatePrecioPlanta(int id, double nuevoPrecio)
        {
            // 1. Buscamos la planta actual para conocer su precio previo
            Planta plantaActual = _plantasRepository.getPlantaById(id);

            if (plantaActual != null)
            {
                // 2. Aplicamos la regla de negocio: el precio debe ser mayor al anterior
                if (nuevoPrecio > plantaActual.precio)
                {
                    return _plantasRepository.updatePrecio(id, nuevoPrecio);
                }
                else
                {
                    // Retornamos un código especial (por ejemplo -1) para indicar error de validación
                    return -1;
                }
            }
            return 0; // Planta no encontrada
        }

        public ListadoPlantaPorCategoriaDto getListadoPlantaPorCategoria(int? idCategoria)
        {
            ListadoPlantaPorCategoriaDto dto = new ListadoPlantaPorCategoriaDto();

            // Cargamos siempre el desplegable
            dto.listaCategorias = _categoriaRepository.getAll();

            // Si el usuario seleccionó una categoría válida, cargamos las plantas
            if (idCategoria.HasValue && idCategoria.Value > 0)
            {
                dto.idCategoria = idCategoria.Value;
                dto.listaPlantas = _plantasRepository.getPlantaByCategoriaId(idCategoria.Value);
            }

            return dto;
        }

        public PlantaPorNombreCategoriaDto getPlataPorNombreCategoria(int? idPlanta)
        {
            PlantaPorNombreCategoriaDto dto = new PlantaPorNombreCategoriaDto();

            if (idPlanta.HasValue)
            {
                dto.idPlanta = idPlanta.Value;
                dto.planta = _plantasRepository.getPlantaById(idPlanta.Value);

                // Si la planta no tiene el nombre de la categoría, lo recuperamos
                if (dto.planta != null && string.IsNullOrEmpty(dto.planta.nombreCategoria))
                {
                    dto.planta.nombreCategoria = _categoriaRepository.getNombreCategoriaById(dto.planta.idCategoria);
                }
            }

            return dto;
        }
    }
}