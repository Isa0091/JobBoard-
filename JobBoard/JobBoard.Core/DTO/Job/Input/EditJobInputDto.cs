using System;
using System.Collections.Generic;
using System.Text;

namespace JobBoard.Core.DTO.Job.Input
{
    /// <summary>
    /// maneja la edicion de los datos de el job
    /// </summary>
    public class EditJobInputDto
    {
        /// <summary>
        /// Identificador del trabajo
        /// </summary>
        public Guid Codigo { get; set; }

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
