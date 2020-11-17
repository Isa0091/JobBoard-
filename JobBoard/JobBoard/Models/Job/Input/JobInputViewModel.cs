using JobBoard.Models.Job.CustomValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JobBoard.Models.Job.Input
{
    /// <summary>
    /// Maneja los datos de job 
    /// </summary>
    public class JobInputViewModel
    {
        public JobInputViewModel()
        {
            Codigo = null;
        }
        /// <summary>
        /// Codigo
        /// </summary>
        public Guid? Codigo { get; set; }
        /// <summary>
        /// Titulo del trabajo
        /// </summary>
        [Required(ErrorMessage = "El titulo es requerido")]
        [MaxLength(256,ErrorMessage = "La cantidad maxima de caracteres es de 256")]
        public string Titulo { get; set; }

        /// <summary>
        /// Descripcion del trabajo
        /// </summary>
        [Required(ErrorMessage = "La descripcion es requerida")]
        [MaxLength(1500, ErrorMessage = "La cantidad maxima e caracteres es de 1500")]
        public string Descripcion { get; set; }

        /// <summary>
        /// Fecha de expiracion del trabajo
        /// </summary>
        [Required(ErrorMessage = "La fecha de expiracion es requerido")]
        [ValidateFechaExpiracionAttribute]
        public string FechaExpiracionJob { get; set; }
    }
}
