using System;
using System.Collections.Generic;
using System.Text;

namespace JobBoard.Core.DTO
{
    /// <summary>
    /// Define los datos a considerar en una consulta paginada
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ResultadoPaginadoDTO<T> where T : class
    {
        /// <summary>
        /// Cantidad de registros existente en la consulta
        /// </summary>
        public int CantidadTotal { get; set; }

        /// <summary>
        /// Lista de registros de la consulta
        /// </summary>
        public List<T> Resultado { get; set; }
    }
}