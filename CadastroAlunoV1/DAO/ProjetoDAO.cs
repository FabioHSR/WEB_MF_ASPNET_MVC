using WEBMF.Models;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System;

namespace WEBMF.DAO
{
    public class ProjetoDAO : BaseDAO<ProjetoViewModel>
    {
        protected override SqlParameter[] CriaParametros(ProjetoViewModel model)
        {
            object imgByte = model.ImagemEmByte;
            if (imgByte == null)
                imgByte = DBNull.Value;

            SqlParameter[] parametros = {
            new SqlParameter("Id", model.Id),
            new SqlParameter("Adesivo", model.Adesivo),
            new SqlParameter("BoxFoto", model.BoxFoto),
            new SqlParameter("ClienteID", model.ClienteID),
            new SqlParameter("Espessura", model.Espessura),
            new SqlParameter("Furo", model.Furo),
            new SqlParameter("imagem", imgByte),
            new SqlParameter("NomeProjeto", model.NomeProjeto),
            new SqlParameter("Obs", model.Obs),
            new SqlParameter("ProjTermo", model.ProjTermo),
            new SqlParameter("TarjaMag", model.TarjaMag),
            new SqlParameter("Tecnologia", model.Tecnologia),
            new SqlParameter("Termo", model.Termo)
            };
            return parametros;
        }

        public List<ProjetoViewModel> ProjetosDoCliente(int? clienteId)
        {
            SqlParameter[] parametros = {
            new SqlParameter("ClienteId", clienteId)
            };
            var tabela = HelperDAO.ExecutaProcSelect("spProjetosDoCliente", parametros);
            List<ProjetoViewModel> lista = new List<ProjetoViewModel>();
            foreach (DataRow registro in tabela.Rows)
            {
                lista.Add(MontaModel(registro));
            }
            return lista;
        }

        protected override ProjetoViewModel MontaModel(DataRow registro)
        {
            ProjetoViewModel proj = new ProjetoViewModel()
            {
                Id = (int)registro["Id"],
                Adesivo = registro["Adesivo"].ToString(),
                BoxFoto = registro["BoxFoto"].ToString(),
                ClienteID = (int)registro["ClienteID"],
                Espessura = registro["Espessura"].ToString(),
                Furo = registro["Furo"].ToString(),
                NomeProjeto = registro["NomeProjeto"].ToString(),
                Obs = registro["Obs"].ToString(),
                ProjTermo = registro["ProjTermo"].ToString(),
                TarjaMag = registro["TarjaMag"].ToString(),
                Tecnologia = registro["Tecnologia"].ToString(),
                Termo = registro["Termo"].ToString()
            };
            if (registro["imagem"] != DBNull.Value)
                proj.ImagemEmByte = registro["imagem"] as byte[];
            return proj;
        }

        protected override void SetTabela()
        {
            Tabela = "Projetos";
        }
    }
}
