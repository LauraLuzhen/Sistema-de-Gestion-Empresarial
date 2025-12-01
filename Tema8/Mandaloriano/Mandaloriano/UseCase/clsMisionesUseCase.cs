using MandoMissions.Data;
using MandoMissions.Entidades;
using System.Collections.Generic;
using System.Linq;

namespace MandoMissions.UseCases
{
    public class clsMisionesUseCase
    {
        private clsMisionesDAL _dataAccess = new clsMisionesDAL();

        public List<string> ObtenerNombresMisiones()
        {
            return _dataAccess.ObtenerTodasLasMisiones().Select(m => m.Nombre).ToList();
        }

        public clsMision ObtenerDetallesMision(string nombreMision)
        {
            return _dataAccess.ObtenerMisionPorNombre(nombreMision);
        }
    }
}