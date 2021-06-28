using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_ZiekenhuisOpnames.Models
{
    public class IDImage
    {
        public int IDImageId { get; private set; }
        public byte[] Image { get; set; }
    }
}
