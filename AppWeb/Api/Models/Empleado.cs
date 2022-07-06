using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Models
{
    public class Empleado
    {
        public int id_empleado { get; set; }
        public int dpi{ get; set;}
        public string nombre { get; set; }

        public string apellidos { get; set; }

        public string fecha_baja { get; set; }

        public string fecha_inicio { get; set; }

        public string fecha_ult_aumento { get; set; }

        public int sueldo { get; set; }

        public int cod_depto { get; set; }

        public int cod_puesto { get; set; }
    }
}
