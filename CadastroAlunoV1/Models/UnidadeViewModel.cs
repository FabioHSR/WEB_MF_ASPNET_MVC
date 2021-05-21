using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WEBMF.Models
{
    public class UnidadeViewModel : PadraoViewModel
    {
        [Required]
        public string Unidade { get; set; }
        public string Obs { get; set; }
        public string Envio { get; set; }
        [Required]
        public int ClienteId { get; set; }
    }
}
