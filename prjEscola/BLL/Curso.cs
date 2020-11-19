using prjEscola.App_Code.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace prjEscola.BLL {
    public class Curso {
        private static string connString = Funcoes.connString;

        public static DataSet PreencheCboCurso() {
            string meuSQL = "SELECT ID_CURSO, DSC_CURSO FROM TB_CURSO";
            DataSet ds = SqlHelper.ExecuteDataset(connString, CommandType.Text, meuSQL);
            return ds;
        }
    }
}