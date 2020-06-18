using System;
using System.Collections.Generic;
using System.Text;

namespace DogBredsModel
{
    public class CaracFisic
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public List<RazaCaracFisic> RazaCaracFisics { get; set; }
    }
}
