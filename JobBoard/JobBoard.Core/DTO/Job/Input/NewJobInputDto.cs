using System;
using System.Collections.Generic;
using System.Text;

namespace JobBoard.Core.DTO.Job.Input
{
    /// <summary>
    /// Datos de entrada
    /// </summary>
    public class NewJobInputDto
    {

        /// <summary>
        /// Titulo del trabajo
        /// </summary>
        public string Titulo { get; set; }

        /// <summary>
        /// Descripcion del trabajo
        /// </summary>
        public string Descripcion { get; set; }

        /// <summary>
        /// Fecha de expiracion del trabajo
        /// </summary>
        public DateTimeOffset FechaExpiracion { get; set; }
    }
}
