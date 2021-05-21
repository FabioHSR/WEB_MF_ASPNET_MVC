using WEBMF.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace WEBMF.DAO
{
    public class UnidadeDAO : PadraoDAO<UnidadeViewModel>
    {
        protected override SqlParameter[] CriaParametros(UnidadeViewModel model)
        {
            SqlParameter[] parametros = {
                new SqlParameter("Id", model.Id),
                new SqlParameter("Unidade", model.Unidade),
                new SqlParameter("Obs", model.Obs),
                new SqlParameter("Envio", model.Envio),
                new SqlParameter("ClienteId", model.ClienteId),
            };
            return parametros;
        }

        protected override UnidadeViewModel MontaModel(DataRow registro)
        {
            UnidadeViewModel uni = new UnidadeViewModel()
            {
                Id = (int)registro["Id"],
                Unidade = registro["Unidade"].ToString(),
                Obs = registro["Obs"].ToString(),
                Envio = registro["Envio"].ToString(),
                ClienteId = (int)registro["ClienteId"]
            };
            return uni;
        }

        public List<UnidadeViewModel> ListagemPorCliente(int clienteId)
        {
            SqlParameter[] parametros = {
                new SqlParameter("ClienteId", clienteId),
            };
            var tabela = HelperDAO.ExecutaProcSelect("spListaUnidadesPorCliente", parametros);
            List<UnidadeViewModel> lista = new List<UnidadeViewModel>();
            foreach (DataRow registro in tabela.Rows)
            {
                lista.Add(MontaModel(registro));
            }
            return lista;
        }

        protected override void SetTabela()
        {
            Tabela = "Unidade";
        }
    }
}
