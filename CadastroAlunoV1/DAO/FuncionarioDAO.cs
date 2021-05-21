using WEBMF.Models;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace WEBMF.DAO
{
    public class FuncionarioDAO : BaseDAO<FuncionarioViewModel>
    {
        protected override SqlParameter[] CriaParametros(FuncionarioViewModel model)
        {
            SqlParameter[] parametros = {
            new SqlParameter("Id", model.Id),
            new SqlParameter("Nome", model.Nome),
            new SqlParameter("Setor", model.Setor),
            new SqlParameter("Senha", model.Senha),
            new SqlParameter("Usuario", model.Usuario)
            };
            return parametros;
        }

        internal void AtivaFuncs()
        {
            HelperDAO.ExecutaProc("spAtivaFuncionarios", null);
        }

        public bool VerificaUsuario(string usuario)
        {
            SqlParameter[] parametros = {
            new SqlParameter("Usuario", usuario),
            };
            var tabela = HelperDAO.ExecutaProcSelect("spVerificaUsuario", parametros);
            return tabela.Rows.Count > 0;
        }

        public override void Delete(int id)
        {
            var p = new SqlParameter[]
            {
                new SqlParameter("id", id)
            };
            HelperDAO.ExecutaProc("spDelete"+Tabela, p);
        }
        public override List<FuncionarioViewModel> Listagem()
        {
            var tabela = HelperDAO.ExecutaProcSelect("spListagem"+Tabela,null);
            List<FuncionarioViewModel> lista = new List<FuncionarioViewModel>();
            foreach (DataRow registro in tabela.Rows)
            {
                lista.Add(MontaModel(registro));
            }
            return lista;
        }

        public List<FuncionarioViewModel> FiltraFunction(int? Id, string Nome, string Setor)
        {
            SqlParameter[] parametros = {
            HelperDAO.NullSqlParameter("Id", Id),
            new SqlParameter("Nome", string.IsNullOrEmpty(Nome) ? "DEFAULT" : Nome),
            new SqlParameter("Setor", string.IsNullOrEmpty(Setor) ? "DEFAULT" : Setor),
            };
            var strId = Id.HasValue ? "@Id" : "DEFAULT";
            var strNome = string.IsNullOrEmpty(Nome) ? "DEFAULT" : "@Nome";
            var strSetor = string.IsNullOrEmpty(Setor) ? "DEFAULT" : "@Setor";

            var tabela = HelperDAO.ExecutaFuncSelect("SELECT * from [dbo].[FiltroFuncionario] ("+strId+","+strNome+ ","+strSetor+") ", parametros);
            List<FuncionarioViewModel> lista = new List<FuncionarioViewModel>();
            foreach (DataRow registro in tabela.Rows)
            {
                lista.Add(MontaModel(registro));
            }
            return lista;
        }

        protected override FuncionarioViewModel MontaModel(DataRow registro)
        {
            FuncionarioViewModel f = new FuncionarioViewModel()
            {
                Id = (int)registro["Id"],
                Nome = registro["Nome"].ToString(),
                Setor = registro["Setor"].ToString(),
                Senha = registro["Senha"].ToString(),
                Usuario = registro["Usuario"].ToString()
            };
            return f;
        }

        protected override void SetTabela()
        {
            Tabela = "Funcionarios";
        }
    }
}
