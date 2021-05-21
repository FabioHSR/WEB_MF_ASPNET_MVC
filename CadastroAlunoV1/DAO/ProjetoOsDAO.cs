using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using WEBMF.Models;

namespace WEBMF.DAO
{
    public class ProjetoOsDAO
    {
        private SqlParameter[] CriaParametros(int OsId, int ProjetoId)
        {
            SqlParameter[] parametros = {
            new SqlParameter("OsId", OsId),
            new SqlParameter("ProjetoId", ProjetoId)
            };
            return parametros;
        }
        internal void Insert(OsViewModel model)
        {
            if(model.Projetos != null && model.Projetos.Count > 0)
            {
                foreach(var item in model.Projetos)
                {
                    HelperDAO.ExecutaProc("sp_InsertProjetoOS", CriaParametros(model.Id, item));
                }
            }
        }
        internal void Update(OsViewModel model)
        {
            SqlParameter[] parametros = {
                new SqlParameter("OsId", model.Id)
            };
            
            HelperDAO.ExecutaProc("sp_DeleteProjetoOS", parametros);
            Insert(model);

        }
        internal static List<int> Listagem(OsViewModel model)
        {
            List<int> projetosID = new List<int>();
            SqlParameter[] parametros = {
                new SqlParameter("OsId", model.Id)
            };
            var tabela = HelperDAO.ExecutaProcSelect("sp_ListagemProjetoOS", parametros);
            if(tabela.Rows.Count>0)
            {
                foreach(DataRow r in tabela.Rows)
                {
                    projetosID.Add((int)r["ProjetoId"]);
                }
                
            }
            return projetosID;
        }


    }
}
