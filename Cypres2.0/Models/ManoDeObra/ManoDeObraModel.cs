namespace Cypres2._0.Models.ManoDeObra
{
    public class ManoDeObraModel
    {
        /// <summary>
        /// Primary key - AutoNumber in Access
        /// </summary>
        public int Id { get; set; }                     

        /// <summary>
        /// Código 
        /// </summary>
        public int Codigo { get; set; }              

        /// <summary>
        /// Descripción
        /// </summary>
        public string Descripcion { get; set; } = string.Empty;


        public int IdUnidad { get; set; }
        public int IdFamilia { get; set; }            
        public double COrigen { get; set; }
        public int IdMoneda { get; set; }
        public double CFinal { get; set; }                

        /// <summary>
        /// Reference to equipment
        /// </summary>
        public string VRef { get; set; } = string.Empty;  

        public int EquiposRef { get; set; }         

        /// <summary>
        /// Date and time
        /// </summary>
        public DateTime Fecha { get; set; }

        public int IdBdatos { get; set; }               
        public bool Revisado { get; set; }              
        public double IndiceRedeterminacion { get; set; } 
        public bool Calificada { get; set; }         
    }
}
