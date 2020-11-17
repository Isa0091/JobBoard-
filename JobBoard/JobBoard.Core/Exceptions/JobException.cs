using System;
using System.Collections.Generic;
using System.Text;

namespace JobBoard.Core.Exceptions
{
    /// <summary>
    /// Maneja las excepciones
    /// </summary>
    public class JobException : Exception
    {
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="tipoError"></param>
        /// <param name="codigoError"></param>
        /// <param name="mensaje"></param>
        public JobException(TipoErrorJob tipoError, string mensaje) : base(mensaje)
        {
            TipoError = tipoError;
        }

        /// <summary>
        /// Tipo de error retornado
        /// </summary>
        public TipoErrorJob TipoError { get; set; }

        /// <summary>
        ///  Tipos de errores 
        /// </summary>
        public enum TipoErrorJob
        {
            /// <summary>
            /// El elemento al que se desea acceder no existe
            /// </summary>
            NoExiste,

        }
    }
}
