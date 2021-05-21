using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WEBMF.Models
{
    public class Materiais
    {
        public List<SelectListItem> SimNao = new List<SelectListItem>()
        {
            new SelectListItem("Selecione...", ""), new SelectListItem("SIM", "SIM"),new SelectListItem("NÃO", "NÃO")
        };
        public List<SelectListItem> Espessuras = new List<SelectListItem>()
        {
            new SelectListItem("Selecione...", ""), new SelectListItem("0,76", "0,76"),new SelectListItem("0,45", "0,45")
        };
        public List<SelectListItem> Tecnologias = new List<SelectListItem>()
        {
            new SelectListItem("Selecione...", ""), new SelectListItem("COMUM", "COMUM"),
            new SelectListItem("ADESIVADO", "ADESIVADO"),new SelectListItem("1K", "1K"),
            new SelectListItem("ACURA", "ACURA")
        };
    }
}
