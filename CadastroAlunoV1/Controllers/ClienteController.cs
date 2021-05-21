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
    public class ClienteController : BaseController<ClienteViewModel>
    {
        public ClienteController()
        {
            DAO = new ClienteDAO();
            GeraProximoId = false;
        }
        protected override void PreencheDadosParaView(string Operacao, ClienteViewModel model)
        {
            base.PreencheDadosParaView(Operacao, model);
            PreparaListaRepresentantesParaCombo();
            PreparaListaTiposEnvioParaCombo();
        }

        private void PreparaListaRepresentantesParaCombo()
        {
            FuncionarioDAO funcDAO = new FuncionarioDAO();
            List<FuncionarioViewModel> listaRep = funcDAO.FiltraFunction(null, null, "COMERCIAL");
            List<SelectListItem> listaRepresentante = new List<SelectListItem>();

            listaRepresentante.Add(new SelectListItem("Selecione um representante...", ""));
            foreach (var rep in listaRep)
            {
                SelectListItem item = new SelectListItem(rep.Nome, rep.Id.ToString());
                listaRepresentante.Add(item);
            }
            ViewBag.Representantes = listaRepresentante;
        }
        private void PreparaListaTiposEnvioParaCombo()
        {
            List<String> listaTiposEnvio = ClienteViewModel.TiposEnvio;
            List<SelectListItem> selecionarListaTiposEnvio = new List<SelectListItem>();

            selecionarListaTiposEnvio.Add(new SelectListItem("Selecione um Tipo de Envio...", ""));
            foreach (var tipoEnvio in listaTiposEnvio)
            {
                SelectListItem item = new SelectListItem(tipoEnvio, tipoEnvio);
                selecionarListaTiposEnvio.Add(item);
            }
            ViewBag.TiposEnvio = selecionarListaTiposEnvio;
        }
    }
}
