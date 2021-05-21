using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WEBMF.Utility;

namespace WEBMF.Models
{
    public class ProjetoViewModel : BaseViewModel
    {

        public Materiais Materiais = new Materiais();

        [Required(ErrorMessage = "O campo {0} deve ser preenchido")]
        [Display(Name = "Nome do Projeto")]
        public string NomeProjeto { get; set; }

        [Required(ErrorMessage = "O campo {0} deve ser preenchido")]
        [Display(Name = "Box da foto")]
        public string BoxFoto { get; set; }

        [Required(ErrorMessage = "O campo {0} deve ser seleciodado")]
        public string Espessura { get; set; }


        [Required(ErrorMessage = "O campo {0} deve ser seleciodado")]
        public string Tecnologia { get; set; }


        [Required(ErrorMessage = "O campo {0} deve ser seleciodado")]
        public string Adesivo { get; set; }

        [Required(ErrorMessage = "O campo {0} deve ser seleciodado")]
        public string Furo { get; set; }

        [Required(ErrorMessage = "O campo {0} deve ser seleciodado")]
        public string Termo { get; set; }

        [RequiredIf("Termo", "SIM", ErrorMessage = "Preencha o projeto termo")]
        [Display(Name = "Projeto termo")]
        public string ProjTermo { get; set; }

        [Required(ErrorMessage = "O campo {0} deve ser seleciodado")]
        [Display(Name = "Tarja Magnetica")]
        public string TarjaMag { get; set; }

        public string Obs { get; set; }

        [Required(ErrorMessage = "O campo {0} deve ser seleciodado")]
        [Display(Name = "Cliente")]
        public int? ClienteID { get; set; }


        [Display(Name = "Unidade")]
        public int? UnidadeID { get; set; }

        public IFormFile Imagem { get; set; }

        public byte[] ImagemEmByte { get; set; }
        public string ImagemEmBase64
        {
            get
            {
                if (ImagemEmByte != null)
                    return Convert.ToBase64String(ImagemEmByte);
                else
                    return string.Empty;
            }
        }
    }
}