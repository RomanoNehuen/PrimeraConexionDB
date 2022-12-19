using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Pokemon
    {
        //anotation para modificar nombre de columna
        //agregar el using System.ComponentModel
        public int Id { get; set; }
        [DisplayName("Número")]
        public int Numero { get; set; }
        public string Nombre { get; set; }
        //ponerlo siempre arriba del atributo que quiero modificar
        [DisplayName("Descripción")]
        public string Descripcion { get; set; }
        public string UrlImagen { get; set; }

        public Elemento Tipo { get; set; }
        public Elemento Debilidad { get; set; }


    }
}
