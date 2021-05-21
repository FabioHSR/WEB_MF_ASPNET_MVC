using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEBMF.DAO;
using WEBMF.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WEBMF.Controllers
{
    public class ConsultaController : Controller
    {

        public ActionResult Filtra(string Orientacao, string OsTipo, string Tecnologia)
        {
            ConsultaDAO DAO = new ConsultaDAO();
            var lista = DAO.Filtra(Orientacao, OsTipo, Tecnologia);
            PreencheDadosParaView();
            return View("Index", lista);
        }
        public ActionResult Index()
        {

            PreencheDadosParaView();
            var lista = new List<ConsultaViewModel>();
            return View(lista);
        }

        public void PreencheDadosParaView()
        {
            PreparaListaOrientacaoParaCombo();
            PreparaListaTiposParaCombo();
            PreparaListaTecnologiasParaCombo();
        }



        private void PreparaListaOrientacaoParaCombo()
        {
            List<string> lista = new List<string>() { "Vert.", "Horiz." };
            List<SelectListItem> listaCombo = new List<SelectListItem>();

            listaCombo.Add(new SelectListItem("Selecione uma orientação...", ""));
            foreach (var rep in lista)
            {
                SelectListItem item = new SelectListItem(rep, rep);
                listaCombo.Add(item);
            }
            ViewBag.Orientacoes = listaCombo;
        }
        private void PreparaListaTiposParaCombo()
        {
            List<string> lista = new List<string>() { "Laminado", "Termo-Impressão" };
            List<SelectListItem> listaCombo = new List<SelectListItem>();

            listaCombo.Add(new SelectListItem("Selecione um tipo...", ""));
            foreach (var rep in lista)
            {
                SelectListItem item = new SelectListItem(rep, rep);
                listaCombo.Add(item);
            }
            ViewBag.Tipos = listaCombo;
        }
        private void PreparaListaTecnologiasParaCombo()
        {


           List<SelectListItem> Tecnologias = new List<SelectListItem>()
            {
            new SelectListItem("Selecione...", ""), new SelectListItem("COMUM", "COMUM"),
            new SelectListItem("ADESIVADO", "ADESIVADO"),new SelectListItem("1K", "1K"),
            new SelectListItem("ACURA", "ACURA")
            };

            ViewBag.Tecnologias = Tecnologias;
        }

    }


}