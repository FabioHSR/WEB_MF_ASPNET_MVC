using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WEBMF.DAO
{
    public static class ConexaoBD
    {        
        public static SqlConnection GetConexao()
        {
            string strCon = "Data Source=DESKTOP-U26BJ62\\SQLEXPRESS;Initial Catalog=WEBMF2;integrated security=true";
            //string strCon = "Data Source=LOCALHOST;Initial Catalog=WEBMF2;integrated security=true";
            SqlConnection conexao = new SqlConnection(strCon);
            conexao.Open();
            return conexao;
        }
    }
}
