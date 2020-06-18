using System;
using System.Collections.Generic;
using System.Text;

namespace DogBredsModel
{
    public class RazaHairType
    {
        public int RazaId { get; set; }
        public Raza Raza { get; set; }
        public int HairTypeId { get; set; }
        public HairType HairType { get; set; }
    }
}
