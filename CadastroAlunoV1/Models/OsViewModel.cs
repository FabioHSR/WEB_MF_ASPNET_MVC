using Biblioteca.Exceptions;
using WEBMF.Utility;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WEBMF.Models
{
    [DataContract]
    public class OsViewModel : BaseViewModel
    {
        public Materiais Materiais = new Materiais();
        public string Operacao { get; set; }
        [Required(ErrorMessage ="O campo status é obrigatório")]
        public string Status { get; set; }
        public static List<string> ListStatus = new List<string>()
        {"CORTAR FOTO","LINKAR","PDF EM APROVAÇÃO","IMPRIMIR","LAMINAR","TERMO","EXPEDIÇÃO","FINALIZADO"};
        [Required(ErrorMessage = "O campo tipo é obrigatório")]
        public string OSTipo { get; set; }
        public string[] Tipos = new[] { "Laminado", "Termo-Impressão" };
        [Required(ErrorMessage = "O campo cliente é obrigatório")]
        [DataMember]
        public int? ClienteId { get; set; }
        public string ClienteNome { get; set; }
        [RequiredIf("Operacao", "F", ErrorMessage = "Selecione o(s) projeto(s) para finalizar")]
        public List<int> Projetos { get; set; }
        public MultiSelectList ProjetosCliente { get; set; }
        public MultiSelectList ProjetosOS { get; set; }        
        [BindProperty]
        public string Orientacao { get; set; }
        public string[] Orientacoes = new[] { "Vert.", "Horiz." };
        public string Multi { get; set; }
        public DateTime? Inicio { get; set; }
        public DateTime? Fim { get; set; }
        public DateTime? Lancamento { get; set; }
        public int? Foto { get; set; }
        public int? Link { get; set; }
        public int? Impressao { get; set; }
        public int? Laminacao { get; set; }
        public int? Corte { get; set; }
        public int? Ordenacao { get; set; }
        public string Termo { get; set; }
        public string Ribbon { get; set; }
        public string Overlay { get; set; }
        public int? TermoOp { get; set; }
        public string Obs { get; set; }
        [RequiredIf("Operacao", "F", ErrorMessage = "Preencha o conferinte para finalizar")]
        public int? ConfOP { get; set; }
        [RequiredIf("Operacao", "F", ErrorMessage = "Preencha o Total Produzido para finalizar")]
        public int? TotalProduzido { get; set; }
        //[RequiredIf("Operacao", "F", ErrorMessage = "Preencha o Total Solicitado para finalizar")]
        public string Emails { get; set; }
    }
}
