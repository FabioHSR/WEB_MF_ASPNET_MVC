using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WEBMF.Models
{
    public class FuncionarioViewModel : BaseViewModel
    {
        [Required(ErrorMessage = "{0} deve ser preenchido.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "{0} deve ser preenchido.")]
        public string Setor { get; set; }

        public static List<string> Setores = new List<string>
        { "PRODUÇÃO","EXPEDIÇÃO","GERENCIA","COMERCIAL","DIREÇÃO" };

        [StringLength(20, ErrorMessage = "{0} deve ter entre {2} e {1} dígitos.", MinimumLength = 4)]
        [Required(ErrorMessage = "{0} deve ser preenchido.")]
        public string Usuario { get; set; }

        [StringLength(10, ErrorMessage = "{0} deve ter entre {2} e {1} dígitos.", MinimumLength = 4)]        
        [Required(ErrorMessage = "{0} deve ser preenchido.")]
        public string Senha { get; set; }


    }
}
