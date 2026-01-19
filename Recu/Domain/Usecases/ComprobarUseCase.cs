using Domain.Interfaces.Repositories;
using Domain.Interfaces.UseCases;

namespace Domain.UseCases;

public class ComprobarUseCase : IComprobarUseCase
{
    private readonly IPersonaRepository _personaRepo;

    public ComprobarUseCase(IPersonaRepository personaRepo)
    {
        _personaRepo = personaRepo;
    }

    public bool ComprobarSeleccion(int personaId, int departamentoIdSeleccionado)
    {
        // Buscamos la persona para ver su departamento real
        var persona = _personaRepo.getListadoPersonas().FirstOrDefault(p => p.Id == personaId);

        if (persona == null) return false;

        // Comparamos el ID real con el que seleccionó el usuario
        return persona.IdDepartamento == departamentoIdSeleccionado;
    }
}