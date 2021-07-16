using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api_netcore_validation_logging.DTOs
{
    public class BeerUpdateDTO: BeerDTO
    {        
        [Required(ErrorMessage="Descripcion requerida")]
        [MaxLength(100, ErrorMessage = "La longuitud máxima es de 100 caracteres")]
        public override string description { get; set; }
    }
}
