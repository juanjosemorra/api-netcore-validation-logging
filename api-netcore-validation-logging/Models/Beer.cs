using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api_netcore_validation_logging.Models
{
    public class Beer
    {
        [Required]
        public int beerId { get; set; }

        [Required]
        [MaxLength(10)]
        public string name { get; set; }
        
        public string description { get; set; }
    }
}
