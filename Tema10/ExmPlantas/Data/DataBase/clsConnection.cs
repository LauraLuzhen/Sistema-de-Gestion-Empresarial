
using Proyecto.Domain.Entities;

namespace Data.DataBase
{
    public class clsConnection
    {
        // Simulamos las tablas de la base de datos como listas estáticas
        public static List<Categoria> TablaCategorias { get; set; } = new List<Categoria>()
        {
            new Categoria(1, "Relajantes"),
            new Categoria(2, "Energizantes"),
            new Categoria(3, "Digestivas"),
            new Categoria(4, "Antiinflamatorias")
        };

        public static List<Planta> TablaPlantas { get; set; } = new List<Planta>()
        {
            new Planta(1, "Valeriana", "Ayuda a conciliar el sueño.", 5.50, 1),
            new Planta(2, "Ginseng", "Aumenta la vitalidad y energía.", 12.00, 2),
            new Planta(3, "Manzanilla", "Alivia pesadez estomacal.", 3.25, 3),
            new Planta(4, "Cúrcuma", "Potente antiinflamatorio natural.", 8.90, 4),
            new Planta(5, "Lavanda", "Reduce el estrés y la ansiedad.", 6.00, 1),
            new Planta(6, "Té Verde", "Antioxidante y estimulante suave.", 4.50, 2)
        };
    }
}
