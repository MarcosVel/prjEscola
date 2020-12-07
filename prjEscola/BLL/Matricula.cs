using prjEscola.App_Code.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace prjEscola.BLL {
    public class Matricula {
        private static string connString = Funcoes.connString;

        private Int32 _ID_MATRICULA;
        private Int32 _ID_TURMA;
        private Int32 _ID_ALUNO;
        private DateTime _DATA_MATRICULA;

        public int ID_MATRICULA { get => _ID_MATRICULA; set => _ID_MATRICULA = value; }
        public int ID_TURMA { get => _ID_TURMA; set => _ID_TURMA = value; }
        public int ID_ALUNO { get => _ID_ALUNO; set => _ID_ALUNO = value; } 
        public DateTime DATA_MATRICULA { get => _DATA_MATRICULA; set => _DATA_MATRICULA = value; }

        public void Inserir()
        {
            string meuSQL = "INSERT INTO TB_MATRICULA (ID_TURMA, ID_ALUNO, DATA_MATRICULA) VALUES " +
                "('" + _ID_TURMA + "', '" + _ID_ALUNO + "', '" + _DATA_MATRICULA + "')";
            SqlHelper.ExecuteNonQuery(connString, CommandType.Text, meuSQL);
        }

        public void Alterar()
        {
            string meuSQL = " UPDATE TB_MATRICULA SET " +
                " ID_TURMA = '" + _ID_TURMA + "', " +
                " ID_ALUNO = '" + _ID_ALUNO + "', " +
                " DATA_MATRICULA = '" + _DATA_MATRICULA + "' " +
                " WHERE ID_MATRICULA = " + _ID_MATRICULA;
            SqlHelper.ExecuteNonQuery(connString, CommandType.Text, meuSQL);
        }

        public void Excluir(Int32 CODIGO)
        {
            string meuSQL = " DELETE TB_MATRICULA WHERE ID_MATRICULA = " + CODIGO;
            SqlHelper.ExecuteNonQuery(connString, CommandType.Text, meuSQL);
        }

        public static DataSet PesquisarMatricula()
        {
            string meuSQL = " SELECT * FROM TB_MATRICULA ";
            DataSet ds = SqlHelper.ExecuteDataset(connString, CommandType.Text, meuSQL);
            return ds;
        }

        public static DataSet PreencheGridMatricula()
        {
            string meuSQL = "SELECT ID_MATRICULA, ID_TURMA, ID_ALUNO, DATA_MATRICULA FROM TB_MATRICULA";
            DataSet ds = SqlHelper.ExecuteDataset(connString, CommandType.Text, meuSQL);
            return ds;
        }

        public void MonstrarDados_Matricula(Int32 CODIGO)
        {
            string meuSQL = "SELECT * FROM TB_MATRICULA WHERE ID_MATRICULA = " + CODIGO;
            DataSet ds = SqlHelper.ExecuteDataset(connString, CommandType.Text, meuSQL);

            if ((ds.Tables[0].Rows.Count > 0))
            {
                DataRow dr = ds.Tables[0].Rows[0];
                _ID_MATRICULA = Convert.ToInt32(dr["ID_MATRICULA"]);
                _ID_TURMA = Convert.ToInt32(dr["ID_TURMA"]);
                _ID_ALUNO = Convert.ToInt32(dr["ID_ALUNO"]);
                _DATA_MATRICULA = Convert.ToDateTime(dr["DATA_MATRICULA"]);
            }
        }

        public static DataSet PreencheCboMatricula()
        {
            string meuSQL = "SELECT ID_MATRICULA, DATA_MATRICULA FROM TB_INSTRUTOR";
            DataSet ds = SqlHelper.ExecuteDataset(connString, CommandType.Text, meuSQL);
            return ds;
        }

    }
}