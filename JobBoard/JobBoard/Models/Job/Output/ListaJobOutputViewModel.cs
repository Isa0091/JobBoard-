using JobBoard.Models.Job.Input;
using JobBoard.Models.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobBoard.Models.Job.Output
{
    /// <summary>
    /// Datos necesarios para render la vista
    /// </summary>
    public class ListaJobOutputViewModel
    {
        /// <summary>
        /// Filtros
        /// </summary>
        public FiltrosJobInputViewModel Filtros { get; set; }

        /// <summary>
        /// Listado de job
        /// </summary>
        public List<JobBoard.Core.Model.Job> ListadoJob{ get; set; }

        /// <summary>
        /// paginacion
        /// </summary>
        public PagingInfo PagingInfo { get; set; }
    }
}
