using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cypres2._0.Models.ManoDeObra
{
    //DTO means Data Transfer Object
    public class ManoDeObraGridDto
    {
        public int Id { get; set; }
        public int Codigo { get; set; }
        public string Descripcion { get; set; }
        public string Unidad { get; set; }
        public string Moneda { get; set; }
        public double COrigen { get; set; }
        public double CFinal { get; set; }
        public string VRef { get; set; }
        public DateTime Fecha { get; set; }
        public bool Revisado { get; set; }
        public bool Calificada { get; set; }
    }
}
