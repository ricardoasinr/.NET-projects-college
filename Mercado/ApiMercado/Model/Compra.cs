using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiMercado.Model
{
    public enum EstadoType
    {
        Pendiente = 0,
        Comprado = 1,
        Anulado = -2
    }
    public class Compra
    {
        [Key]
        public int CompraId { get; set; }
        [Required]
        public string Detalle { get; set; }
        [Required]
        public EstadoType Estado { get; set; }
        public decimal Costo { get; set; }

    }
}
