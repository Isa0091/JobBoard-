using JobBoard.Models.Job.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JobBoard.Models.Job.CustomValidation
{
    public class ValidateFechaExpiracionAttribute : ValidationAttribute
    {
        /// <summary>
        /// Valida el tipo de documento ingresado
        /// </summary>
        /// <param name="value"></param>
        /// <param name="validationContext"></param>
        /// <returns></returns>
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTimeOffset fechaValida = DateTime.Now.Date;
            DateTimeOffset fechaEnviada = Convert.ToDateTime(value.ToString()).AddHours(23).AddMinutes(59);

            if (fechaEnviada < fechaValida)
            {
                    return new ValidationResult(
                        $"La fecha de expiracion debe ser mayor o igual al dia actual", new[] { nameof(JobInputViewModel.FechaExpiracionJob) });
            }

            return ValidationResult.Success;
        }
    }
}