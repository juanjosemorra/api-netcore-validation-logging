using api_netcore_validation_logging.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api_netcore_validation_logging.DTOs
{
    public class BeerDTO
    {
        [Required(ErrorMessage = "Id requerido")]
        public int beerId { get; set; }

        [CustomValidationAttibute("^[a-zA-Z]", ErrorMessage = "El nombre no cumple el formato valido")]
        [MaxLength(10, ErrorMessage = "La longuitud máxima es de 10 caracteres")]
        public string name { get; set; }
        public virtual string description { get; set; }
    }
}
