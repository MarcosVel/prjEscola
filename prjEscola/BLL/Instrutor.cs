using prjEscola.App_Code.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace prjEscola.BLL {
    public class Instrutor {
        private static string connString = Funcoes.connString;

        public static DataSet PreencheCboInstrutor() {
            string meuSQL = "SELECT ID_INSTRUTOR, NOME_INSTRUTOR FROM TB_INSTRUTOR";
            DataSet ds = SqlHelper.ExecuteDataset(connString, CommandType.Text, meuSQL);
            return ds;
        }
    }
}