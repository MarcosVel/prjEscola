using prjEscola.App_Code.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace prjEscola.BLL {
    public class Curso {
        private static string connString = Funcoes.connString;

        private Int32 _ID_CURSO;
        private string _DSC_CURSO;
        private string _REQUISITO;
        private Int32 _CARGA_HORARIA;
        private string _VALOR_CURSO;

        public int ID_CURSO { get => _ID_CURSO; set => _ID_CURSO = value; }
        public string DSC_CURSO { get => _DSC_CURSO; set => _DSC_CURSO = value; }
        public string REQUISITO { get => _REQUISITO; set => _REQUISITO = value; }
        public int CARGA_HORARIA { get => _CARGA_HORARIA; set => _CARGA_HORARIA = value; }
        public string VALOR_CURSO { get => _VALOR_CURSO; set => _VALOR_CURSO = value; }

        public void Inserir()
        {
            string meuSQL = "INSERT INTO TB_CURSO (DSC_CURSO, REQUISITO, CARGA_HORARIA, VALOR_CURSO) VALUES " +
                "('" + _DSC_CURSO + "', '" + _REQUISITO + "', '" + _CARGA_HORARIA + "', '" + _VALOR_CURSO + "')";
            SqlHelper.ExecuteNonQuery(connString, CommandType.Text, meuSQL);
        }

        public void Alterar()
        {
            string meuSQL = " UPDATE TB_CURSO SET " +
                " DSC_CURSO = '" + _DSC_CURSO + "', " +
                " REQUISITO = '" + _REQUISITO + "', " +
                " CARGA_HORARIA = '" + _CARGA_HORARIA + "', " +
                " VALOR_CURSO = '" + _VALOR_CURSO + "' " +
                " WHERE ID_CURSO = " + _ID_CURSO;
            SqlHelper.ExecuteNonQuery(connString, CommandType.Text, meuSQL);
        }

        public void Excluir(Int32 CODIGO)
        {
            string meuSQL = "DELETE TB_CURSO WHERE ID_CURSO = " + CODIGO;
            SqlHelper.ExecuteNonQuery(connString, CommandType.Text, meuSQL);
        }

        public static DataSet PesquisarCurso()
        {
            string meuSQL = "SELECT * FROM TB_CURSO";
            DataSet ds = SqlHelper.ExecuteDataset(connString, CommandType.Text, meuSQL);
            return ds;
        }

        public static DataSet PreencheGridCurso()
        {
            string meuSQL = "SELECT ID_CURSO, DSC_CURSO, REQUISITO, CARGA_HORARIA, VALOR_CURSO FROM TB_CURSO";
            DataSet ds = SqlHelper.ExecuteDataset(connString, CommandType.Text, meuSQL);
            return ds;
        }

        public void MonstrarDados_Curso(Int32 CODIGO)
        {
            string meuSQL = "SELECT * FROM TB_CURSO WHERE ID_CURSO = " + CODIGO;
            DataSet ds = SqlHelper.ExecuteDataset(connString, CommandType.Text, meuSQL);

            if ((ds.Tables[0].Rows.Count > 0))
            {
                DataRow dr = ds.Tables[0].Rows[0];
                _ID_CURSO = Convert.ToInt32(dr["ID_CURSO"]);
                _DSC_CURSO = Convert.ToString(dr["DSC_CURSO"]);
                _REQUISITO = Convert.ToString(dr["REQUISITO"]);
                _CARGA_HORARIA = Convert.ToInt32(dr["CARGA_HORARIA"]);
                _VALOR_CURSO = Convert.ToString(dr["VALOR_CURSO"]);
            }
        }

        public static DataSet PreencheCboCurso() {
            string meuSQL = "SELECT ID_CURSO, DSC_CURSO FROM TB_CURSO";
            DataSet ds = SqlHelper.ExecuteDataset(connString, CommandType.Text, meuSQL);
            return ds;
        }
    }
}