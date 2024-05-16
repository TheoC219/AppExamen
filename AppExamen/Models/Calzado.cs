using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppExamen.Models
{
    public class Calzado
    {
        public int Id { get; set; }
        public string Tipo { get; set; }
        public double PrecioUnitario { get; set; }
        public int Talla { get; set; }
        public int IVA { get; set; }
        public int MarcaId { get; set; }
    }
}
