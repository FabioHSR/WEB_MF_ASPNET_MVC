using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using WEBMF.Models;

namespace WEBMF.DAO
{
    public class ConsultaDAO
    {
        public List<ConsultaViewModel> Filtra(string orientacao, string ostipo, string tecnologia)
        {
            SqlParameter[] parametros = {
            new SqlParameter("Orientacao", orientacao),
            new SqlParameter("OsTipo", ostipo ),
            new SqlParameter("Tecnologia", tecnologia),
            };


            var tabela = HelperDAO.ExecutaProcSelect("spMelhoresClientes", parametros);

            List<ConsultaViewModel> lista = new List<ConsultaViewModel>();
            if(tabela!=null && tabela.Rows.Count>0)
            foreach (DataRow registro in tabela.Rows)
            {
                lista.Add(MontaModel(registro));
            }
            return lista;
        }

        private ConsultaViewModel MontaModel(DataRow registro)
        {
            ConsultaViewModel model = new ConsultaViewModel();
            var cliId = registro["ClienteId"] != DBNull.Value ? (int?)registro["ClienteId"] : null;
            if (cliId.HasValue)
            {
                var cliDAO = new ClienteDAO();
                int _cliId = (int)cliId;
                model.NomeCliente = cliDAO.Consulta(_cliId).Fantasia;
            }
            model.TotalProduzido = (int)registro["TotalProduzido"];
            return model;
        }
    }
}
