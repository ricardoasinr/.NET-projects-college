using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAltura.Models
{
    public enum MascotaType
    {
        Perro = 0,
        Gato = 1,
        Hamster = 2,
        Tortuga = 3
    }
    public class AlturaCliente
    {



        [Key]
        public int ClienteId { get; set; }

        [Required(ErrorMessage = "El nombre del cliente es requerido")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "El nombre debe tener mas de 3 letras")]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "La altura del cliente es requerido")]
       
        [Display(Name = "Altura")]
        public int Altura { get; set; }

        [Required(ErrorMessage = "La mascota es requerida")]
        [Display(Name = "Escoge tu mascota")]
        public MascotaType Mascota { get; set; }





    }
}
