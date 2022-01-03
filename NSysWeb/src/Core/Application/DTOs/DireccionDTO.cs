using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class DireccionDTO
    {
        public int DireccionId { get; set; }
        public int IdAsentamiento { get; set; }
        public string Estatus { get; set; }
        public string Calle { get; set; }
        public string EntreLaCalle { get; set; }
        public string YlaCalle { get; set; }
        public string NumeroExterior { get; set; }
        public string NumeroInterior { get; set; }
        public double Latitud { get; set; }
        public double Longitud { get; set; }
        public string Referencia { get; set; }
        public string Foto { get; set; }
        public bool EsFiscal { get; set; }
    }
}
