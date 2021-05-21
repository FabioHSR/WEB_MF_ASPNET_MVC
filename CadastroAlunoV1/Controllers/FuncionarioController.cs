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
    public class FuncionarioController : BaseController<FuncionarioViewModel>
    {
        public FuncionarioController()
        {
            DAO = new FuncionarioDAO();
            GeraProximoId = false;
        }
        public ActionResult AtivarFuncs()
        {
            var deu = new FuncionarioDAO();
            deu.AtivaFuncs();
            var lista = DAO.Listagem();
            return View("Index", lista);
        }
        public IActionResult Filtra(int? Id, string Nome, string Setor)
        {
            FuncionarioDAO deu = new FuncionarioDAO();
            var lista = deu.FiltraFunction(Id,Nome,Setor);
            return View("Index",lista);
        }
        protected override void ValidaDados(FuncionarioViewModel model, string operacao)
        {            
            var dao = new FuncionarioDAO();
            if (operacao == "I" && model.Usuario!=null && dao.VerificaUsuario(model.Usuario))
                ModelState.AddModelError("Usuario", "Usuario já está em uso!");
            if (operacao == "A" && DAO.Consulta(model.Id) == null && model.Usuario != null && dao.VerificaUsuario(model.Usuario))
                ModelState.AddModelError("Id", "Este registro não existe!");
        }
        protected override void PreencheDadosParaView(string Operacao, FuncionarioViewModel model)
        {
            base.PreencheDadosParaView(Operacao, model);
            PreparaListaSetoresParaCombo();
        }

        private void PreparaListaSetoresParaCombo()
        {
            List<string> lista = FuncionarioViewModel.Setores;
            List<SelectListItem> listaCombo = new List<SelectListItem>();

            listaCombo.Add(new SelectListItem("Selecione um setor...", ""));
            foreach (var rep in lista)
            {
                SelectListItem item = new SelectListItem(rep, rep);
                listaCombo.Add(item);
            }
            ViewBag.Setores = listaCombo;
        }
    }


}