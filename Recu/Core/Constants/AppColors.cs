using System;
namespace Core.Constants
{
    public static class AppColors
    {
        public const string WinBackground = "#C8E6C9";   
        public const string LooseBackground = "#FFCDD2"; 
        public const string DefaultCard = "#FFFFFF";    

        /// <summary>
        /// Asigna un color pastel según el ID del departamento.
        /// Equivale a la lógica de pistas visuales del juego.
        /// </summary>
        /// <param name="id">ID del departamento</param>
        /// <returns>Código hexadecimal del color</returns>
        public static string GetColorByDeptId(int id)
        {
            return id switch
            {
                1 => "#FFD1DC", 
                2 => "#D1EAFF", 
                3 => "#E2FFD1", 
                4 => "#FFF4D1", 
                5 => "#D1D5FF", 
                _ => DefaultCard
            };
        }
    }
}
