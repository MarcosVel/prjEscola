using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using prjEscola.App_Code.DAL;
using prjEscola.BLL;

namespace prjEscola.BLL {

    public class Aluno {
        private static string connString = Funcoes.connString;
        private Int32 _id_aluno = 0;
        private string _CPF = "";
        private string _NOME = "";
        private string _EMAIL = "";
        private string _TELEFONE = "";
        private string _NOME_MAE = "";
        private string _NOME_PAI = "";
        private DateTime _DATA_NASCIMENTO = DateTime.Now;

        public static string ConnString { get => connString; set => connString = value; }
        public int Id_aluno { get => _id_aluno; set => _id_aluno = value; }
        public string CPF { get => _CPF; set => _CPF = value; }
        public string NOME { get => _NOME; set => _NOME = value; }
        public string EMAIL { get => _EMAIL; set => _EMAIL = value; }
        public string TELEFONE { get => _TELEFONE; set => _TELEFONE = value; }
        public string NOME_MAE { get => _NOME_MAE; set => _NOME_MAE = value; }
        public string NOME_PAI { get => _NOME_PAI; set => _NOME_PAI = value; }
        public DateTime DATA_NASCIMENTO { get => _DATA_NASCIMENTO; set => _DATA_NASCIMENTO = value; }

        public void Inserir() {
            string meuSQL = "INSERT INTO TB_ALUNO(CPF, NOME, EMAIL, TELEFONE, DATA_NASCIMENTO, NOME_MAE, NOME_PAI) VALUES " +
                   "('" + _CPF.Trim() + "', '" + _NOME.Trim() + "', '" + _EMAIL.Trim() + "', '" + _TELEFONE + "', '" + _DATA_NASCIMENTO + "', '" + _NOME_MAE + "', '" + _NOME_PAI + "');";
            SqlHelper.ExecuteNonQuery(connString, CommandType.Text, meuSQL);
        }

        public void Alterar() {
            string meuSQL = " UPDATE TB_ALUNO SET " +
                " CPF = '" + _CPF + "', " +
                " NOME = '" + _NOME + "', " +
                " EMAIL = '" + _EMAIL + "', " +
                " TELEFONE = '" + _TELEFONE + "', " +
                " DATA_NASCIMENTO = '" + _DATA_NASCIMENTO + "', " +
                " NOME_MAE = '" + _NOME_MAE + "', " +
                " NOME_PAI = '" + _NOME_PAI + "' " +
                " WHERE ID_ALUNO = " + _id_aluno;
            SqlHelper.ExecuteNonQuery(connString, CommandType.Text, meuSQL);

        }

        public void Excluir(Int32 CODIGO) {
            string meuSQL = "DELETE TB_ALUNO WHERE ID_ALUNO = " + CODIGO;
            SqlHelper.ExecuteNonQuery(connString, CommandType.Text, meuSQL);
        }

        public static DataSet PesquisarAluno() {
            string meuSQL = "SELECT * FROM TB_ALUNO";
            DataSet ds = SqlHelper.ExecuteDataset(connString, CommandType.Text, meuSQL);
            return ds;
        }

        public static DataSet PreencheGridAluno() {
            string meuSQL = "SELECT ID_ALUNO, NOME, CPF, EMAIL FROM TB_ALUNO";
            DataSet ds = SqlHelper.ExecuteDataset(connString, CommandType.Text, meuSQL);
            return ds;
        }

        public void MonstrarDados_Alunos(Int32 CODIGO) {
            string meuSQL = "SELECT * FROM TB_ALUNO WHERE ID_ALUNO = " + CODIGO;
            DataSet ds = SqlHelper.ExecuteDataset(connString, CommandType.Text, meuSQL);

            if((ds.Tables[0].Rows.Count > 0)) {
                DataRow dr = ds.Tables[0].Rows[0];
                _id_aluno = Convert.ToInt32(dr["ID_ALUNO"]);
                _NOME = Convert.ToString(dr["NOME"]);
                _CPF = Convert.ToString(dr["CPF"]);
                _EMAIL = Convert.ToString(dr["EMAIL"]);
                _DATA_NASCIMENTO = Convert.ToDateTime(dr["DATA_NASCIMENTO"]);
                _NOME_MAE = Convert.ToString(dr["NOME_MAE"]);
                _NOME_PAI = Convert.ToString(dr["NOME_PAI"]);
                _TELEFONE = Convert.ToString(dr["TELEFONE"]);
            }
        }
    }
}