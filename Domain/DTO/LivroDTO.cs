using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.DTO
{
    public class LivroDTO
    {
        public string Author { get; set; }
        public string Name { get; set; }
        public double? PrecoInicial { get; set; }
        public double? PrecoFinal { get; set; }
        public string Genero { get; set; }
        public string Ilustrador { get; set; }
        public int? QuantidadePaginasInicial { get; set; }
        public int? QuantidadePaginasFinal
        {
            get; set;
        }
    }
}
