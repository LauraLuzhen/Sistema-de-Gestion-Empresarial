using MandoMissions.Entidades;

namespace MandoMissions.Data
{
    public class clsMisionesDAL
    {
        private List<clsMision> _misiones;

        public clsMisionesDAL()
        {
            // Inicialización de datos
            _misiones = new List<clsMision>
            {
                new clsMision("Rescate de Baby Yoda", "Debes hacerte con Grogu y llevárselo a Luke SkyWalker para su entrenamiento.", "5000 créditos"),
                new clsMision("Recuperar armadura Beskar", "Tu armadura de Beskar ha sido robada. Debes encontrarla.", "2000 créditos"),
                new clsMision("Planeta Sorgon", "Debes llevar a un niño de vuelta a su planeta natal “Sorgon”.", "500 créditos."),
                new clsMision("Renacuajos", "Debes llevar a una Dama Rana y sus huevos de Tatooine a la luna del estuario Trask, donde su esposo fertilizará los huevos.", "500 créditos")
            };
        }

        public List<clsMision> ObtenerTodasLasMisiones()
        {
            return _misiones;
        }

        public clsMision? ObtenerMisionPorNombre(string nombre)
        {
            return _misiones.FirstOrDefault(m => m.Nombre == nombre);
        }
    }
}