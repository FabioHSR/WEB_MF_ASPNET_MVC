using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WEBMF.Models
{
    public class ClienteViewModel : BaseViewModel
    {

        [Required(ErrorMessage = "Preencha o campo Fantasia.")]
        public string Fantasia { get; set; }

        [Required(ErrorMessage = "Selecione um Representante")]
        public int? Representante { get; set; }

        public string Envio { get; set; }
        public static List<string> TiposEnvio = new List<string>()
        { "SEDEX", "PAC", "CARTA REGISTRADA","CARTA SIMPLES",
                "RETIRA", "TRANSPORTADORA", "MARCOS"};

        public string Obs { get; set; }
    }
}
