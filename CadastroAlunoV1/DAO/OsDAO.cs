using WEBMF.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

namespace WEBMF.DAO
{
    public class OsDAO : BaseDAO<OsViewModel>
    {
        protected override SqlParameter[] CriaParametros(OsViewModel model)
        {
            SqlParameter[] parametros = {
            new SqlParameter("Id", model.Id),
            new SqlParameter("Status", model.Status),
            new SqlParameter("OSTipo", model.OSTipo),
            new SqlParameter("Orientacao", model.Orientacao),
            new SqlParameter("Termo", model.Termo),
            new SqlParameter("Ribbon", model.Ribbon),
            new SqlParameter("Overlay", model.Overlay),
            HelperDAO.NullSqlParameter("ClienteId", model.ClienteId),
            new SqlParameter("Multi", model.Multi),
            HelperDAO.NullSqlParameter("Inicio", model.Inicio),
            HelperDAO.NullSqlParameter("Fim", model.Fim),
            HelperDAO.NullSqlParameter("Lancamento", model.Lancamento),
            HelperDAO.NullSqlParameter("Foto", model.Foto),
            HelperDAO.NullSqlParameter("Link", model.Link),
            HelperDAO.NullSqlParameter("Impressao", model.Impressao),
            HelperDAO.NullSqlParameter("Laminacao", model.Laminacao),
            HelperDAO.NullSqlParameter("Corte", model.Corte),
            HelperDAO.NullSqlParameter("Ordenacao", model.Ordenacao),
            HelperDAO.NullSqlParameter("TermoOp", model.TermoOp),
            HelperDAO.NullSqlParameter("ConfOP", model.ConfOP),
            new SqlParameter("Obs", model.Obs),
            HelperDAO.NullSqlParameter("TotalProduzido", model.TotalProduzido),
            new SqlParameter("Emails", model.Emails)
            };

            return parametros;
        }

        protected override OsViewModel MontaModel(DataRow registro)
        {
            OsViewModel os = new OsViewModel();
            os.Id = (int)registro["Id"];
            os.Status = registro["Status"].ToString();
            os.OSTipo = registro["OsTipo"].ToString();
            os.ClienteId = registro["ClienteId"] != DBNull.Value ? (int?)registro["ClienteId"] : null;
            if (os.ClienteId.HasValue)
            {
                var cliDAO = new ClienteDAO();
                int _cliId = (int)os.ClienteId;
                os.ClienteNome = cliDAO.Consulta(_cliId).Fantasia;
            }
            os.Multi = registro["Multi"].ToString();
            os.Orientacao = registro["Orientacao"].ToString();
            os.Inicio = registro["Inicio"] != DBNull.Value ? (DateTime?)registro["Inicio"] : null;
            os.Fim = registro["Fim"] != DBNull.Value ? (DateTime?)registro["Fim"] : null;
            os.Foto = registro["Foto"] != DBNull.Value ? (int?)registro["Foto"] : null;
            os.Link = registro["Link"] != DBNull.Value ? (int?)registro["Link"] : null;
            os.Impressao = registro["Impressao"] != DBNull.Value ? (int?)registro["Impressao"] : null;
            os.Laminacao = registro["Laminacao"] != DBNull.Value ? (int?)registro["Laminacao"] : null;
            os.Corte = registro["Corte"] != DBNull.Value ? (int?)registro["Corte"] : null;
            os.Ordenacao = registro["Ordenacao"] != DBNull.Value ? (int?)registro["Ordenacao"] : null;
            os.Termo = registro["Termo"].ToString();
            os.Ribbon = registro["Ribbon"].ToString();
            os.Overlay = registro["Overlay"].ToString();
            os.TermoOp = registro["TermoOp"] != DBNull.Value ? (int?)registro["TermoOp"] : null;
            os.Obs = registro["Obs"].ToString();
            os.ConfOP = registro["ConfOp"] != DBNull.Value ? (int?)registro["ConfOp"] : null;
            os.TotalProduzido = registro["TotalProduzido"] != DBNull.Value ? (int?)registro["TotalProduzido"] : null;
            os.Emails = registro["Emails"].ToString();
            os.Projetos = ProjetoOsDAO.Listagem(os);
            var itemsCliente = new List<SelectListItem>();
            var itemsOS = new List<SelectListItem>();
            ProjetoDAO projDAO = new ProjetoDAO();
            var projetosCliente = projDAO.ProjetosDoCliente(os.ClienteId);
            foreach (var proj in projetosCliente)
            {
                var item = new SelectListItem
                {
                    Value = proj.Id.ToString(),
                    Text = proj.NomeProjeto
                };
                if (os.Projetos.Contains(proj.Id))
                {
                    itemsOS.Add(item);
                }
                else
                {
                    itemsCliente.Add(item);
                }
            }
            os.ProjetosCliente = new MultiSelectList(itemsCliente.OrderBy(i => i.Text), "Value", "Text");
            os.ProjetosOS = new MultiSelectList(itemsOS.OrderBy(i => i.Text), "Value", "Text");

            return os;
        }

        public override void Insert(OsViewModel model)
        {
            var tabela = HelperDAO.ExecutaProcSelect("spInsert" + Tabela, CriaParametros(model));
            if (tabela.Rows.Count > 0)
            {
                var osId = Convert.ToInt32(tabela.Rows[0][0].ToString());
                model.Id = osId;
            }
        }


        protected override void SetTabela()
        {
            Tabela = "OS";
        }
    }
}
