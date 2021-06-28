using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_ZiekenhuisOpnames.Models
{
    public class PatientViewModel : Patient
    {
        [DisplayName("Foto identiteitskaart (voorkant)")]
        public IFormFile ID_Voorkant { get; set; }
        [DisplayName("Foto identiteitskaart (achterkant)")]
        public IFormFile ID_Achterkant { get; set; }

        public IEnumerable<SelectListItem> Geslachten { get; set; } = new List<SelectListItem>()
        {
            new SelectListItem("Man","M"),
            new SelectListItem("Vrouw","V"),
            new SelectListItem("Onbekend","O")
        };
        //public PatientViewModel()
        //{
        //    Geslachten = new List<SelectListItem>();
        //}
    }
}
