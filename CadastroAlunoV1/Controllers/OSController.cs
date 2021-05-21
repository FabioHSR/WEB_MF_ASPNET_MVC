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
    public class OSController : BaseController<OsViewModel>
    {
        public OSController()
        {
            DAO = new OsDAO();

            GeraProximoId = false;
        }
        public override IActionResult Salvar(OsViewModel model, string Operacao)
        {
            try
            {
                ValidaDados(model, Operacao);
                if (ModelState.IsValid == false)
                {
                    ViewBag.Operacao = Operacao;
                    PreencheDadosParaView(Operacao, model);
                    return View("Form", model);
                }
                else
                {
                    var projetoOsDAO = new ProjetoOsDAO();
                    if (Operacao == "I")
                    {
                        using (var transacao = new System.Transactions.TransactionScope())
                        {
                            DAO.Insert(model);
                            projetoOsDAO.Insert(model);
                            transacao.Complete();
                        }
                    }
                    else
                    {
                        using (var transacao = new System.Transactions.TransactionScope())
                        {                            
                            DAO.Update(model);
                            projetoOsDAO.Update(model);
                            transacao.Complete();
                        }
                    }
                    return RedirectToAction("index");
                }
            }
            catch (Exception erro)
            {
                ViewBag.Erro = "Ocorreu um erro: " + erro.Message;
                ViewBag.Operacao = Operacao;
                PreencheDadosParaView(Operacao, model);
                return View("Form", model);
            }
        }
        protected override void ValidaDados(OsViewModel model, string operacao)
        {
            if (operacao == "A" && DAO.Consulta(model.Id) == null)
                ModelState.AddModelError("Id", "Este registro não existe!");
            if (operacao == "A" && model.Id <= 0)
                ModelState.AddModelError("Id", "Id inválido!");
            if (operacao == "F" && model.Fim.HasValue == false)
                model.Fim = DateTime.Now;
        }
        protected override void PreencheDadosParaView(string Operacao, OsViewModel model)
        {
            base.PreencheDadosParaView(Operacao, model);
            if (Operacao == "I") { model.Inicio = DateTime.Now; }
            PreparaListaClientesParaCombo();
            PreparaListaStatusParaCombo();
            PreparaListaFuncionariosParaCombo();
        }
        private void PreparaListaClientesParaCombo()
        {
            ClienteDAO clienteDao = new ClienteDAO();
            var lista = clienteDao.Listagem();
            List<SelectListItem> sli = new List<SelectListItem>();

            sli.Add(new SelectListItem("Selecione um cliente...", ""));

            foreach (var item in lista)
            {
                SelectListItem i = new SelectListItem(item.Fantasia, item.Id.ToString());
                sli.Add(i);
            }
            ViewBag.Clientes = sli;
        }
        private void PreparaListaStatusParaCombo()
        {
            var lista = OsViewModel.ListStatus;
            List<SelectListItem> sli = new List<SelectListItem>();

            sli.Add(new SelectListItem("Selecione um status...", ""));

            foreach (var item in lista)
            {
                SelectListItem i = new SelectListItem(item, item);
                sli.Add(i);
            }
            ViewBag.Status = sli;
        }


        private void PreparaListaFuncionariosParaCombo()
        {
            FuncionarioDAO DAO = new FuncionarioDAO();
            var lista = DAO.Listagem();
            List<SelectListItem> sli = new List<SelectListItem>();

            sli.Add(new SelectListItem("Selecione um funcionario...", ""));

            foreach (var item in lista)
            {
                SelectListItem i = new SelectListItem(item.Nome, item.Id.ToString());
                sli.Add(i);
            }
            ViewBag.Funcionarios = sli;
            ViewBag.Projetos = sli;
        }

        [HttpPost]
        public List<ProjetoViewModel> PopulaProjetos([FromBody]OsViewModel OS)
        {

            ProjetoDAO projDAO = new ProjetoDAO();
            var lista = projDAO.ProjetosDoCliente(OS.ClienteId);

            return lista;
        }





        //protected override void ValidaDados(OsViewModel model, string operacao)
        //{
        //    base.ValidaDados(model, operacao);
        //    if (string.IsNullOrEmpty(model.Nome))
        //        ModelState.AddModelError("Nome", "Preencha o nome.");
        //    if (model.Mensalidade < 0)
        //        ModelState.AddModelError("Mensalidade", "Campo obrigatório.");
        //    if (model.CidadeId <= 0)
        //        ModelState.AddModelError("CidadeId", "Informe o código da cidade.");
        //    if (model.DataNascimento > DateTime.Now)
        //        ModelState.AddModelError("DataNascimento", "Data inválida!");
        //}
    }
}