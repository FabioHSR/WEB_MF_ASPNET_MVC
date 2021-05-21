using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace WEBMF.DAO
{
    public class LoginDAO
    {
        public bool VerificaUsuario(string nome, string senha)
        {
            SqlParameter[] parametros = {
                new SqlParameter("user", nome),
                new SqlParameter("senha", senha)
            };
            var tabela = HelperDAO.ExecutaProcSelect("spLogin", parametros);
            return tabela.Rows.Count > 0;
        }
    }
}
