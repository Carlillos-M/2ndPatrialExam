using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecondPartialExam.Entities
{
    public class Juguete
    {
        public Guid Id { get; set; }
        public int Codigo { get; set; }
        public string? Nombre { get; set; }
        public decimal Precio { get; set; }
        public DateTime? Vigencia { get; set; }
        public bool Activo { get; set; }

    }
}