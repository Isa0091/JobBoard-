using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobBoard.Models.Paging
{
    public class PagingVm
    {
        public string UrlPaginaAnterior { get; set; }

        public List<BotonPaginacionVm> Botones { get; set; }

        public string UrlPaginaSiguiente { get; set; }

        public int PaginaActiva { get; set; }

        public string ClasePersonalizada { get; set; }
    }
}
