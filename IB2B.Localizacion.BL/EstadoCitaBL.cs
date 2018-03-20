using ES.DentalPeruERP.BE;
using ES.DentalPeruERP.DAC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.DentalPeruERP.BL
{
    public class EstadoCitaBL
    {
        #region Singleton

        private static EstadoCitaBL vInstancia = null;
        private EstadoCitaBL()
        {
        }
        public static EstadoCitaBL Instancia
        {
            get { if (vInstancia == null) vInstancia = new EstadoCitaBL(); return vInstancia; }
        }
        #endregion

        public List<EstadoCitaBE> EstadoCita_Sel()
        {
            return EstadoCitaDAC.Instancia.EstadoCita_Sel();
        }
    }
}
