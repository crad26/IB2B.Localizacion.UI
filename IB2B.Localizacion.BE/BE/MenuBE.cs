using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IB2B.Localizacion.BE.BE
{
    public class MenuBE
    {
        public Int32 MenuId { get; set; }
        public String Nombre_Mnu { get; set; }
        public String Html_Mnu { get; set; }
        public Int32 Orden_Mnu { get; set; }
        public Int32 Padre_Mnu { get; set; }
        public Int32 Estado_Mnu { get; set; }
        public String Icono_Mnu { get; set; }
        public String Url { get; set; }
        public Int32 Visible_Mnu { get; set; }
    }
}
