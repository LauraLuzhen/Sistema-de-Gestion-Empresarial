namespace Domain.Entities;

public class Persona
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Apellidos { get; set; }
    public string Telefono { get; set; }
    public string Direccion { get; set; }
    public DateTime FechaNac { get; set; }
    public int IdDepartamento { get; set; }

    public Persona() { }

    public Persona(int id, string nombre, string apellidos, string telefono, string direccion, DateTime fechaNac, int idDepartamento)
    {
        Id = id;
        Nombre = nombre;
        Apellidos = apellidos;
        Telefono = telefono;
        Direccion = direccion;
        FechaNac = fechaNac;
        IdDepartamento = idDepartamento;
    }
}