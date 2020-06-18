using System;
using System.Collections.Generic;
using System.Text;

namespace DogBredsModel
{
    public class Raza
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public List<RazaCaracFisic> CaracFisics { get; set; }
        public List<RazaOrigen> Origenes { get; set; }
        public string Altura { get; set; }
        public string EsperanzaDeVida { get; set; }
        public List<RazaHairType> TiposDePelo { get; set; }
        public string Actividad { get; set; }
    }
}
