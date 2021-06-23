using Microsoft.AspNetCore.Http;
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
    }
}
