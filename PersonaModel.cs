using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioMaui {
    public class PersonaModel {
        public string nombre { get; set; } = "";
        public string apellido { get; set; } = "";

        public char sexo { get; set; } = 'M';
        public string fh_nac { get; set; } = "2024-19-11";

        public int id_rol = 1;

    }
}
