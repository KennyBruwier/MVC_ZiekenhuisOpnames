using MVC_ZiekenhuisOpnames.Models.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_ZiekenhuisOpnames.Models
{
    public class Patient
    {
        public int id { get; set; }
        [Required]
        [MaxLength(20, ErrorMessage = "Maximum lengte van 20 characters")]
        public string Voornaam { get; set; }
        [Required]
        [MaxLength(40, ErrorMessage = "Maximum lengte van 40 characters")]
        public string Achternaam { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd, MMMM yyyy}")]
        [ValidateLeeftijd(min: "01/01/1900", max: "01/01/2021")]
        //[Range(typeof(DateTime), "01/01/1900", "01/01/2021",ErrorMessage = "Geldige datums voor de {0} liggen tussen {1} en {2}")]
        public DateTime Leeftijd { get; set; }
        [Required]
        [MaxLength(40, ErrorMessage = "Maximum lengte van 40 characters")]
        public string Straat { get; set; }
        [Required]
        [MaxLength(5, ErrorMessage = "Maximum lengte van 5 characters")]
        public string HuisNr { get; set; }
        public string Bus { get; set; }
        [Required]
        [MaxLength(4, ErrorMessage = "Maximum lengte van 4 characters")]
        public string Postcode { get; set; }
        [Required]
        [MaxLength(20, ErrorMessage = "Maximum lengte van 20 characters")]
        public string Stad { get; set; }
        [Required]
        public char Geslacht { get; set; }
        public string pathImgIdCardVoorkant { get; set; }
        public string pathImgIdCardAchterkant { get; set; }

    }
}
