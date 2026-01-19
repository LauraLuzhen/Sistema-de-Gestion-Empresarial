using Domain.Entities;
namespace Domain.Interfaces.UseCases;
public interface IListadoUseCase { List<Persona> GetPersonas(); List<Departamento> GetDepartamentos(); }