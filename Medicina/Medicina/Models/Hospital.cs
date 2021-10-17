using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Medicina.Models
{
    public enum EspecialidadType
    {
        Pediatria = 0,
        Ginecologia = 1,
        
    }
    public class Hospital
    {



        [Key]
        public int ClienteId { get; set; }

        [Required(ErrorMessage = "El nombre del doctor es requerido")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "El nombre debe tener mas de 3 letras")]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El codigo del doctor es requerido")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "El nombre debe tener mas de 3 letras")]
        [Display(Name = "Codigo")]
        public string Codigo { get; set; }

        [Required(ErrorMessage = "La mascota es requerida")]
        [Display(Name = "Tu especialidad")]
        public EspecialidadType Especialidad { get; set; }





    }

}
