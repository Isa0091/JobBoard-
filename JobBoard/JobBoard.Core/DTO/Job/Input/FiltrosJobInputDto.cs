using System;
using System.Collections.Generic;
using System.Text;

namespace JobBoard.Core.DTO.Job.Input
{
    /// <summary>
    /// Filtros para el listado
    /// </summary>
    public class FiltrosJobInputDto
    {
        /// <summary>
        /// Titulo
        /// </summary>
        public string Titulo { get; set; }

        /// <summary>
        /// Fecha de inicio de expiracion
        /// </summary>
        public DateTimeOffset FechaExpiracionInicio { get; set; }

        /// <summary>
        /// Fecha fin de expiracion
        /// </summary>
        public DateTimeOffset? FechaExpiracionFin { get; set; }
    }
}
