namespace Proyecto.Domain.Entities
{
    public class Categoria
    {
        // Atributos y Propiedades
        public int id { get; set; }
        public string nombre { get; set; }

        // Constructor vacío (necesario para serialización o frameworks)
        public Categoria() { }

        // Constructor con parámetros
        public Categoria(int id, string nombre)
        {
            this.id = id;
            this.nombre = nombre;
        }
    }
}