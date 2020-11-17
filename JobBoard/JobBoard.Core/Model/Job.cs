using System;
using System.Collections.Generic;
using System.Text;

namespace JobBoard.Core.Model
{
    /// <summary>
    /// Clase que maneja los jobs
    /// </summary>
    public class Job
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public Job()
        {
            FechaExpiracion = DateTimeOffset.Now;
        }

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

        /// <summary>
        /// Fecha de ingreso
        /// </summary>
        public DateTimeOffset FechaIngreso { get; set; }
    }
}
