using System;
using System.Collections.Generic;
using System.Text;

namespace DogBredsModel
{
    public class HairType
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public List<RazaHairType> RazaHairTypes { get; set; }
    }
}
