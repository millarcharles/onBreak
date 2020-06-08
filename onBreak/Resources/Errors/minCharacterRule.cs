using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace onBreak.Resources.Errors
{
    public class MinCharacterRule : ValidationRule
    {
        public int minCharacters { get; set; }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            String charStr = value as string;
            if (charStr.Length < minCharacters)
                return new ValidationResult(false,"Campo no puede estar vacio");

            return new ValidationResult(true, null);
        }    
    }
}
