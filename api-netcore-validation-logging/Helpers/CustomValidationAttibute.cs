using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace api_netcore_validation_logging.Helpers
{
    public class CustomValidationAttibute: ValidationAttribute
    {
        
        public readonly string _mask;

        public string Mask
        {
            get { return _mask; }
        }

        public CustomValidationAttibute(string mask)
        {
            _mask = mask;
        }

        public override bool IsValid(object value)
        {                     
            if (string.IsNullOrEmpty(this.Mask))
            {
                return MatchesMask(this.Mask, (String)value);
            }
            return true;
        }
        
        private bool MatchesMask(string mask, string value)
        {
            Regex rgx = new Regex(@mask);
            return rgx.IsMatch(value); 
        }

        public override string FormatErrorMessage(string name)
        {
            return String.Format(CultureInfo.CurrentCulture, ErrorMessageString, name, this.Mask);
        }
    }
}
