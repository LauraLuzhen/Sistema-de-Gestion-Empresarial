namespace Domain.Entities;

public class Departamento
{
    public int Id { get; set; }
    public string Nombre { get; set; }

    public Departamento() { }
    public Departamento(int id, string nombre)
    {
        Id = id;
        Nombre = nombre;
    }
}