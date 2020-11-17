using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobBoard.Models.Job.Input
{
    /// <summary>
    /// Filtros del listado
    /// </summary>
    public class FiltrosJobInputViewModel
    {
        /// <summary>
        /// Titulo
        /// </summary>
        public string FiltroTitulo { get; set; }

        /// <summary>
        /// Fecha de inicio de expiracion
        /// </summary>
        public string FechaExpiracionInicio { get; set; }

        /// <summary>
        /// Fecha fin de expiracion
        /// </summary>
        public string FechaExpiracionFin { get; set; }
    }
}
