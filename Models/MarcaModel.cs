using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SecondPartialExam.Entities;

namespace SecondPartialExam.Models
{
    public class MarcaModel
    {
    public Guid Id { get; set; }
    public int Codigo { get; set; }

    public string? Nombre { get; set; }

    public bool Activo { get; set; }

    //public List<Marca> ListadoMarcas { get; set; }
    }
}