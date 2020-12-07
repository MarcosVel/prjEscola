using prjEscola.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace prjEscola {
    public partial class cMatricula : System.Web.UI.Page {
        protected Int32 codigo_matricula;
        protected void Page_Load(object sender, EventArgs e) {
            if (!Page.IsPostBack) {
                /* preencheCboTurma(); */
                preencheCboAluno();
                preencheGridMatricula();
            }
        }
        /*
        void preencheCboTurma() {
            
        }
        */

        void preencheCboAluno() {
            cboAluno.DataTextField = "NOME";
            cboAluno.DataValueField = "ID_ALUNO";
            cboAluno.DataSource = Aluno.PreencheCboAluno();
            cboAluno.DataBind();
        }

        void preencheGridMatricula() {
            dgMatricula.DataSource = Matricula.PreencheGridMatricula();
            dgMatricula.DataBind();
        }

        protected void cmdConfirmar_Click(object sender, EventArgs e) {
            AdicionarMatricula();
        }

        private void AdicionarMatricula() {
            Matricula matricula = new Matricula();
            //matricula.ID_TURMA = Convert.ToInt32(cboTurma.SelectedItem.Value);
            matricula.ID_ALUNO = Convert.ToInt32(cboAluno.SelectedItem.Value);
            matricula.DATA_MATRICULA = Convert.ToDateTime(txtMatricula.Text);

            if (cmdConfirmar.Text == "Incluir") {
                matricula.Inserir();
            }
            else {
                matricula.ID_MATRICULA = Convert.ToInt32(dgMatricula.SelectedItem.Cells[0].Text);
                matricula.Alterar();
            }
            LimparCampos();
            preencheGridMatricula();
        }

        private void LimparCampos() {
            //cboTurma.SelectedIndex = -1;
            cboAluno.SelectedIndex = -1;
            txtMatricula.Text = "";            
            codigo_matricula = 0;
            cmdConfirmar.Text = "Incluir";
            cmdExluir.Enabled = false;
        }

        void MostrarDados(String cod_matricula) {
            Matricula matricula = new Matricula();
            matricula.MonstrarDados_Matricula(int.Parse(cod_matricula));
            codigo_matricula = matricula.ID_MATRICULA;
            //cboTurma.Text = Convert.ToString(matricula.ID_TURMA);
            cboAluno.Text = Convert.ToString(matricula.ID_ALUNO);
            txtMatricula.Text = Convert.ToString(matricula.DATA_MATRICULA);            
        }

        protected void dgMatricula_SelectedIndexChanged(object sender, EventArgs e) {
            MostrarDados(dgMatricula.SelectedItem.Cells[0].Text);
            cmdConfirmar.Text = "Alterar";
            cmdExluir.Enabled = true;
        }

        protected void cmdExluir_Click(object sender, EventArgs e) {
            Matricula matricula = new Matricula();
            matricula.Excluir(Convert.ToInt32(dgMatricula.SelectedItem.Cells[0].Text));
            preencheGridMatricula();
            LimparCampos();
        }

        protected void cmdLimpar_Click(object sender, EventArgs e) {
            LimparCampos();
        }
    }
}