using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.UseCases;

namespace Domain.UseCases;

public class ListadoUseCase : IListadoUseCase
{
    private readonly IPersonaRepository _personaRepo;
    private readonly IDepartamentoRepository _deptRepo;

    public ListadoUseCase(IPersonaRepository personaRepo, IDepartamentoRepository deptRepo)
    {
        _personaRepo = personaRepo;
        _deptRepo = deptRepo;
    }

    public List<Persona> GetPersonas() => _personaRepo.getListadoPersonas();
    public List<Departamento> GetDepartamentos() => _deptRepo.GetListadoDepartamento();
}