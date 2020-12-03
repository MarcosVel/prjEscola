using prjEscola.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace prjEscola {
    public partial class cTurma : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            if (!Page.IsPostBack) {
                preencheCboCurso();
                preencheCboInstrutor();
                preencheGridTurma();
            }
        }

        protected void cboCurso_SelectedIndexChanged(object sender, EventArgs e) {

        }

        void preencheCboCurso() {
            cboCurso.DataTextField = "DSC_CURSO";
            cboCurso.DataValueField = "ID_CURSO";
            cboCurso.DataSource = Curso.PreencheCboCurso();
            cboCurso.DataBind();
        }
        
        void preencheCboInstrutor() {
            cboInstrutor.DataTextField = "NOME_INSTRUTOR";
            cboInstrutor.DataValueField = "ID_INSTRUTOR";
            cboInstrutor.DataSource = Instrutor.PreencheCboInstrutor();
            cboInstrutor.DataBind();
        }

        void preencheGridTurma() {
            grvTurma.DataSource = Turma.PreencheGridTurma();
            grvTurma.DataBind();
        }

        protected void cmdConfirmar_Click(object sender, EventArgs e) {
            AdicionarTurma();
            preencheGridTurma();
        }

        private void AdicionarTurma() {
            Turma turma = new Turma();
            turma.ID_CURSO = Convert.ToInt32(cboCurso.SelectedItem.Value);
            turma.ID_INSTRUTOR = Convert.ToInt32(cboInstrutor.SelectedItem.Value);
            turma.DATA_INICIO = Convert.ToDateTime(txtData_Inicio.Text);
            turma.DATA_TERMINO = Convert.ToDateTime(txtData_Termino.Text);
            turma.CARGA_HORARIA = Convert.ToInt32(txtCargaHoraria.Text);

            if(cmdConfirmar.Text == "Incluir") {
                turma.Inserir();
                

            } else {
                turma.Alterar();
            }
            LimparCampos();
        }

        private void LimparCampos() {
            cboCurso.SelectedIndex = -1;
            cboInstrutor.SelectedIndex = -1;
            txtData_Inicio.Text = "";
            txtData_Termino.Text = "";
            txtCargaHoraria.Text = "";
        }

        protected void grvTurma_RowCommand(object sender, GridViewCommandEventArgs e) {

        }
    }
}