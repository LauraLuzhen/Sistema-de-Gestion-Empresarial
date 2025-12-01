namespace MandoMissions.Entidades
{
    public class clsMision
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Recompensa { get; set; }

        public clsMision(string nombre, string descripcion, string recompensa)
        {
            Nombre = nombre;
            Descripcion = descripcion;
            Recompensa = recompensa;
        }
    }
}