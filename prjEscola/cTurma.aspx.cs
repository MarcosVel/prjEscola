using prjEscola.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace prjEscola {
    public partial class cTurma : System.Web.UI.Page {
        protected Int32 codigo_turma;
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
            dgTurma.DataSource = Turma.PreencheGridTurma();
            dgTurma.DataBind();
        }

        protected void cmdConfirmar_Click(object sender, EventArgs e) {
            AdicionarTurma();
            /*preencheGridTurma();*/
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
                turma.ID_TURMA = Convert.ToInt32(dgTurma.SelectedItem.Cells[0].Text);
                turma.Alterar();
            }
            LimparCampos();
            preencheGridTurma();
        }

        private void LimparCampos() {
            cboCurso.SelectedIndex = -1;
            cboInstrutor.SelectedIndex = -1;
            txtData_Inicio.Text = "";
            txtData_Termino.Text = "";
            txtCargaHoraria.Text = "";
            codigo_turma = 0;
            cmdConfirmar.Text = "Incluir";
            cmdExluir.Enabled = false;
        }

        void MostrarDados(String cod_turma) {
            Turma turma = new Turma();
            turma.MonstrarDados_Turma(int.Parse(cod_turma));
            codigo_turma = turma.ID_TURMA;
            cboInstrutor.Text = Convert.ToString(turma.ID_INSTRUTOR);
            cboCurso.Text = Convert.ToString(turma.ID_CURSO);
            txtData_Inicio.Text = Convert.ToString(turma.DATA_INICIO);
            txtData_Termino.Text = Convert.ToString(turma.DATA_TERMINO);
            txtCargaHoraria.Text = Convert.ToString(turma.CARGA_HORARIA);
        }
        /*
        protected void grvTurma_RowCommand(object sender, GridViewCommandEventArgs e) {
            MostrarDados(e.CommandArgument.ToString());
        }
        */
        protected void dgTurma_SelectedIndexChanged(object sender, EventArgs e) {
            MostrarDados(dgTurma.SelectedItem.Cells[0].Text);
            cmdConfirmar.Text = "Alterar";
            cmdExluir.Enabled = true;
        }
        

        protected void cmdExluir_Click(object sender, EventArgs e) {
            Turma turma = new Turma();
            turma.Excluir(Convert.ToInt32(dgTurma.SelectedItem.Cells[0].Text));
            preencheGridTurma();
            LimparCampos();
        }

        protected void cmdLimpar_Click(object sender, EventArgs e) {
            LimparCampos();
        }

    }
}