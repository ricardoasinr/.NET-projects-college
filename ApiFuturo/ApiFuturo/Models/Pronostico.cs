using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiFuturo.Models
{
    public class Pronostico
    {
        [Key]
        public string FuturId { get; set; }
        [Required]
        public string Palabras { get; set; }
        [Required]
        public string Vision { get; set; }

        [Url]
        public string LinkImagen { get; set; }
    }
}
