using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FullTecno.Models
{
    public class Audifonos
    {
        public int Id { get; set; }
        public string? Nombre_producto { get; set; }


        public int Stock { get; set; }

        public decimal Price { get; set; }
    }
}
