using prjEscola.App_Code.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace prjEscola.BLL {
    public class Turma {
        private static string connString = Funcoes.connString;

        private Int32 _ID_TURMA;
        private Int32 _ID_INSTRUTOR;
        private Int32 _ID_CURSO;
        private DateTime _DATA_INICIO;
        private DateTime _DATA_TERMINO;
        private Int32 _CARGA_HORARIA;

        public int ID_TURMA { get => _ID_TURMA; set => _ID_TURMA = value; }
        public int ID_INSTRUTOR { get => _ID_INSTRUTOR; set => _ID_INSTRUTOR = value; }
        public int ID_CURSO { get => _ID_CURSO; set => _ID_CURSO = value; }
        public DateTime DATA_INICIO { get => _DATA_INICIO; set => _DATA_INICIO = value; }
        public DateTime DATA_TERMINO { get => _DATA_TERMINO; set => _DATA_TERMINO = value; }
        public int CARGA_HORARIA { get => _CARGA_HORARIA; set => _CARGA_HORARIA = value; }

        public void Inserir() {
            string meuSQL = "INSERT INTO TB_TURMA(ID_INSTRUTOR, ID_CURSO, DATA_INICIO, DATA_TERMINO, CARGA_HORARIA) VALUES " +
                   "('" + _ID_INSTRUTOR + "', '" + _ID_CURSO + "', '" + (_DATA_INICIO) + "', '" + (_DATA_TERMINO) + "'," +
                   " '" + _CARGA_HORARIA + "')";
            SqlHelper.ExecuteNonQuery(connString, CommandType.Text, meuSQL);
        }
        public void Alterar() {
            string meuSQL = " UPDATE TB_TURMA SET " +
                " ID_INSTRUTOR = '" + _ID_INSTRUTOR + "', " +
                " ID_CURSO = '" + _ID_CURSO + "', " +
                " DATA_INICIO = '" + _DATA_INICIO + "', " +
                " DATA_TERMINO = '" + _DATA_TERMINO + "', " +
                " CARGA_HORARIA = '" + _CARGA_HORARIA + "' " +
                " WHERE ID_TURMA = " + _ID_TURMA;
            SqlHelper.ExecuteNonQuery(connString, CommandType.Text, meuSQL);

        }

        public void Excluir(Int32 CODIGO) {
            string meuSQL = "DELETE TB_TURMA WHERE ID_TURMA = " + CODIGO;
            SqlHelper.ExecuteNonQuery(connString, CommandType.Text, meuSQL);
        }

        public static DataSet PesquisarTurma() {
            string meuSQL = "SELECT * FROM TB_TURMA";
            DataSet ds = SqlHelper.ExecuteDataset(connString, CommandType.Text, meuSQL);
            return ds;
        }

        public static DataSet PreencheGridTurma() {
            string meuSQL = "SELECT dbo.TB_TURMA.ID_TURMA, dbo.TB_INSTRUTOR.NOME_INSTRUTOR, dbo.TB_CURSO.DSC_CURSO, dbo.TB_TURMA.ID_INSTRUTOR, dbo.TB_TURMA.ID_CURSO, dbo.TB_TURMA.DATA_INICIO, dbo.TB_TURMA.DATA_TERMINO, " 
                + " dbo.TB_TURMA.CARGA_HORARIA" 
                + " FROM dbo.TB_TURMA INNER JOIN" 
                + " dbo.TB_INSTRUTOR ON dbo.TB_TURMA.ID_INSTRUTOR = dbo.TB_INSTRUTOR.ID_INSTRUTOR INNER JOIN" 
                + " dbo.TB_CURSO ON dbo.TB_TURMA.ID_CURSO = dbo.TB_CURSO.ID_CURSO";
            DataSet ds = SqlHelper.ExecuteDataset(connString, CommandType.Text, meuSQL);
            return ds;
        }

        public void MonstrarDados_Turma(Int32 CODIGO) {
            string meuSQL = "SELECT * FROM TB_TURMA WHERE ID_TURMA = " + CODIGO;
            DataSet ds = SqlHelper.ExecuteDataset(connString, CommandType.Text, meuSQL);

            if ((ds.Tables[0].Rows.Count > 0)) {
                DataRow dr = ds.Tables[0].Rows[0];
                _ID_TURMA = Convert.ToInt32(dr["ID_TURMA"]);
                _ID_INSTRUTOR = Convert.ToInt32(dr["ID_INSTRUTOR"]);
                _ID_CURSO = Convert.ToInt32(dr["ID_CURSO"]);
                _DATA_INICIO = Convert.ToDateTime(dr["DATA_INICIO"]);
                _DATA_TERMINO = Convert.ToDateTime(dr["DATA_TERMINO"]);
                _CARGA_HORARIA = Convert.ToInt32(dr["CARGA_HORARIA"]);
            }
        }
    }
}