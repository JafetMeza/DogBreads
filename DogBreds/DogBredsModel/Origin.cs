using System;
using System.Collections.Generic;
using System.Text;

namespace DogBredsModel
{
    public class Origin
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public List<RazaOrigen> RazaOrigenes { get; set; }
    }
}
