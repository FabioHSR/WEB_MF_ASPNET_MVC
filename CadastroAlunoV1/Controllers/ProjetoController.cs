using WEBMF.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEBMF.Models;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WEBMF.Controllers
{
    public class ProjetoController : BaseController<ProjetoViewModel>
    {
        public ProjetoController()
        {
            DAO = new ProjetoDAO();
            GeraProximoId = false;
        }
        protected override void PreencheDadosParaView(string Operacao, ProjetoViewModel model)
        {
            base.PreencheDadosParaView(Operacao, model);
            PreparaListaClientesParaCombo();
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
        public byte[] ConvertImageToByte(IFormFile file)
        {
            if (file != null)
                using (var ms = new MemoryStream())
                {
                    file.CopyTo(ms);
                    return ms.ToArray();
                }
            else
                return null;
        }

        protected override void ValidaDados(ProjetoViewModel model, string operacao)
        {

            if (model.Imagem == null && operacao == "I")
                ModelState.AddModelError("Imagem", "Escolha uma imagem.");

            if (model.Imagem != null && model.Imagem.Length / 1024 / 1024 >= 2)
                ModelState.AddModelError("Imagem", "Imagem limitada a 2 mb.");

            if (ModelState.IsValid)
            {

                if (operacao == "A" && model.Imagem == null)
                {
                    ProjetoViewModel proj = DAO.Consulta(model.Id);
                    model.ImagemEmByte = proj.ImagemEmByte;
                }
                else
                {
                    model.ImagemEmByte = ConvertImageToByte(model.Imagem);
                }
            }
        }
    }
}
