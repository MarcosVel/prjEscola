using prjEscola.App_Code.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace prjEscola.BLL {
    public class Instrutor {
        private static string connString = Funcoes.connString;

        private Int32 _ID_INSTRUTOR;
        private string _NOME_INSTRUTOR;
        private string _EMAIL;
        private string _VALOR_HORA;
        private string _CERTIFICADOS;

        public int ID_INSTRUTOR { get => _ID_INSTRUTOR; set => _ID_INSTRUTOR = value; }
        public string NOME_INSTRUTOR { get => _NOME_INSTRUTOR; set => _NOME_INSTRUTOR = value; }
        public string EMAIL { get => _EMAIL; set => _EMAIL = value; }
        public string VALOR_HORA { get => _VALOR_HORA; set => _VALOR_HORA = value; }
        public string CERTIFICADOS { get => _CERTIFICADOS; set => _CERTIFICADOS = value; }

        public void Inserir() {
            string meuSQL = "INSERT INTO TB_INSTRUTOR (NOME_INSTRUTOR, EMAIL, VALOR_HORA, CERTIFICADOS) VALUES " +
                "('" + _NOME_INSTRUTOR + "', '" + _EMAIL + "', '" + _VALOR_HORA + "', '" + _CERTIFICADOS + "')";
            SqlHelper.ExecuteNonQuery(connString, CommandType.Text, meuSQL);
        }

        public void Alterar() {
            string meuSQL = " UPDATE TB_INSTRUTOR SET " +
                " NOME_INSTRUTOR = '" + _NOME_INSTRUTOR + "', " +
                " EMAIL = '" + _EMAIL + "', " +
                " VALOR_HORA = '" + _VALOR_HORA + "', " +
                " CERTIFICADOS = '" + _CERTIFICADOS + "' " +
                " WHERE ID_INSTRUTOR = " + _ID_INSTRUTOR;
            SqlHelper.ExecuteNonQuery(connString, CommandType.Text, meuSQL);
        }

        public void Excluir(Int32 CODIGO) {
            string meuSQL = "DELETE TB_INSTRUTOR WHERE ID_INSTRUTOR = " + CODIGO;
            SqlHelper.ExecuteNonQuery(connString, CommandType.Text, meuSQL);
        }

        public static DataSet PesquisarInstrutor() {
            string meuSQL = "SELECT * FROM TB_INSTRUTOR";
            DataSet ds = SqlHelper.ExecuteDataset(connString, CommandType.Text, meuSQL);
            return ds;
        }

        public static DataSet PreencheGridInstrutor() {
            string meuSQL = "SELECT ID_INSTRUTOR, NOME_INSTRUTOR, EMAIL, VALOR_HORA, CERTIFICADOS FROM TB_INSTRUTOR";
            DataSet ds = SqlHelper.ExecuteDataset(connString, CommandType.Text, meuSQL);
            return ds;
        }

        public void MonstrarDados_Instrutor(Int32 CODIGO) {
            string meuSQL = "SELECT * FROM TB_INSTRUTOR WHERE ID_INSTRUTOR = " + CODIGO;
            DataSet ds = SqlHelper.ExecuteDataset(connString, CommandType.Text, meuSQL);

            if ((ds.Tables[0].Rows.Count > 0)) {
                DataRow dr = ds.Tables[0].Rows[0];
                _ID_INSTRUTOR = Convert.ToInt32(dr["ID_INSTRUTOR"]);
                _NOME_INSTRUTOR = Convert.ToString(dr["NOME_INSTRUTOR"]);
                _EMAIL = Convert.ToString(dr["EMAIL"]);
                _VALOR_HORA = Convert.ToString(dr["VALOR_HORA"]);
                _CERTIFICADOS = Convert.ToString(dr["CERTIFICADOS"]);
            }
        }

        public static DataSet PreencheCboInstrutor() {
            string meuSQL = "SELECT ID_INSTRUTOR, NOME_INSTRUTOR FROM TB_INSTRUTOR";
            DataSet ds = SqlHelper.ExecuteDataset(connString, CommandType.Text, meuSQL);
            return ds;
        }
    }
}