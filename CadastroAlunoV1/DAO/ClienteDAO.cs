using WEBMF.Models;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace WEBMF.DAO
{
    public class ClienteDAO : BaseDAO<ClienteViewModel>
    {
        protected override SqlParameter[] CriaParametros(ClienteViewModel model)
        {
            SqlParameter[] parametros = {
            new SqlParameter("Id", model.Id),
            new SqlParameter("Fantasia", model.Fantasia),
            new SqlParameter("Representante", model.Representante),
            new SqlParameter("Envio", model.Envio),
            new SqlParameter("Obs", model.Obs),
            };
            return parametros;
        }

        protected override ClienteViewModel MontaModel(DataRow registro)
        {
            ClienteViewModel cliente = new ClienteViewModel()
            {
                Id = (int)registro["Id"],
                Fantasia = registro["Fantasia"].ToString(),
                Envio = registro["Envio"].ToString(),
                Representante = (int)registro["Representante"],
                Obs = registro["Obs"].ToString()
            };
            return cliente;
        }

        public override List<ClienteViewModel> Listagem()
        { 
            var tabela = HelperDAO.ExecutaProcSelect("spListagemClientes", null);
            List<ClienteViewModel> lista = new List<ClienteViewModel>();
            foreach (DataRow registro in tabela.Rows)
            {
                lista.Add(MontaModel(registro));
            }
            return lista;
        }
        public override ClienteViewModel Consulta(int id)
        {
            return base.Consulta(id);
        }

        public override void Delete(int id)
        {
            var p = new SqlParameter[]
            {
                new SqlParameter("id", id),
            };
            HelperDAO.ExecutaProc("spDeleteCliente", p);
        }

        protected override void SetTabela()
        {
            Tabela = "Clientes";
        }
    }
}
