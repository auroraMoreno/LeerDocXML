using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeerDocXML.Models
{
    public class Album
    {
        public int Id { get; set; }
        public String Titulo { get; set; }
        public String Autor { get; set; }
        public DateTime FechaPublicacion { get; set; }
    }
}
