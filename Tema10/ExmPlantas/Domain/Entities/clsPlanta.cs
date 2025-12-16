namespace Proyecto.Domain.Entities
{
    public class Planta
    {
        // Atributos y Propiedades
        public int id { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public double precio { get; set; }
        public int idCategoria { get; set; }
        public string nombreCategoria { get; set; }

        // Constructor vacío
        public Planta() { }

        // Constructor básico (sin nombre de categoría)
        public Planta(int id, string nombre, string descripcion, double precio, int idCategoria)
        {
            this.id = id;
            this.nombre = nombre;
            this.descripcion = descripcion;
            this.precio = precio;
            this.idCategoria = idCategoria;
        }

        // Constructor completo (con nombre de categoría para visualización en UI)
        public Planta(int id, string nombre, string descripcion, double precio, int idCategoria, string nombreCategoria)
        {
            this.id = id;
            this.nombre = nombre;
            this.descripcion = descripcion;
            this.precio = precio;
            this.idCategoria = idCategoria;
            this.nombreCategoria = nombreCategoria;
        }
    }
}