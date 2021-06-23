using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_ZiekenhuisOpnames.Models.Validations
{
    // example: [ValidateLeeftijd(min: "01/01/1900", max: "01/01/2021", ErrorMessage = "Not Valid")]

    public class ValidateLeeftijd : ValidationAttribute
    {
        public DateTime Minimum;
        public DateTime Maximum;
        public ValidateLeeftijd()
        {
            Minimum = new DateTime(1900, 1, 1);
            Maximum = DateTime.Now;
        }
        public ValidateLeeftijd(string min, string max)
        {
            if (!DateTime.TryParse(min, System.Globalization.CultureInfo.GetCultureInfo("nl-BE"), System.Globalization.DateTimeStyles.None, out Minimum))
                Minimum = new DateTime(1900, 1, 1);
            if (!DateTime.TryParse(max, System.Globalization.CultureInfo.GetCultureInfo("nl-BE"), System.Globalization.DateTimeStyles.None, out Maximum))
                Maximum = DateTime.Now;
            if (String.IsNullOrEmpty(ErrorMessage))
                ErrorMessage = $"Ongeldige leeftijd: Maximum leeftijd is {Minimum.ToString("dd/mm/yyyy")} en minimum leeftijd is {Maximum.ToString("dd/mm/yyyy")}";
        }

        public override bool IsValid(object value)
        {
            if (value != null)
                if (value is DateTime)
                {
                    DateTime date = DateTime.Parse(value.ToString());
                    return ((date > Minimum) && (date < Maximum));
                }
            return true;
        }
    }
}
