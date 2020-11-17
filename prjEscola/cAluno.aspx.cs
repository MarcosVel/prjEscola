using prjEscola.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace prjEscola { 
    public partial class cAluno : System.Web.UI.Page {
        protected Int32 codigo_aluno;
        protected void Page_Load(object sender, EventArgs e) {
            if (!Page.IsPostBack) {
                preencheGridAluno();
            }
        }
        void preencheGridAluno() {
            dgAlunos.DataSource = Aluno.PreencheGridAluno();
            dgAlunos.DataBind();
        }

        protected void cmdConfirmar_Click1(object sender, EventArgs e) {
            adicionarAluno();
        }

        private void adicionarAluno() {
            Aluno aluno = new Aluno();
            aluno.NOME = txtNome.Text.ToString().Trim();
            aluno.CPF = txtCPF.Text.ToString().Trim();
            aluno.DATA_NASCIMENTO = Convert.ToDateTime(txtDtNascimento.Text);
            aluno.EMAIL = txtemail.Text.ToString().Trim();
            aluno.TELEFONE = txtTelefone.Text.ToString().Trim();
            aluno.NOME_MAE = txtMae.Text.ToString().Trim();
            aluno.NOME_PAI = txtPai.Text.ToString().Trim();

            if (cmdConfirmar.Text == "Incluir") {
                aluno.Inserir();
            }
            else {
                aluno.Id_aluno = Convert.ToInt32(dgAlunos.SelectedItem.Cells[0].Text);
                aluno.Alterar();                
            }
            LimparCampos();
            preencheGridAluno();
        }

        private void LimparCampos() {
            txtNome.Text = "";
            txtCPF.Text = "";
            txtDtNascimento.Text = "";
            txtemail.Text = "";
            txtTelefone.Text = "";
            txtMae.Text = "";
            txtPai.Text = "";
            codigo_aluno = 0;
            cmdConfirmar.Text = "Incluir";
            cmdExluir.Enabled = false;
        }

        void MostrarDados(String cod_aluno) {
            Aluno aluno = new Aluno();
            aluno.MonstrarDados_Alunos(int.Parse(cod_aluno));
            codigo_aluno = aluno.Id_aluno; // variavel que recebe o IdAluno
            txtNome.Text = aluno.NOME;
            txtCPF.Text = aluno.CPF;
            txtDtNascimento.Text = Convert.ToString(aluno.DATA_NASCIMENTO);
            txtemail.Text = aluno.EMAIL;
            txtTelefone.Text = aluno.TELEFONE;
            txtMae.Text = aluno.NOME_MAE;
            txtPai.Text = aluno.NOME_PAI;
        }

        protected void dgAlunos_SelectedIndexChanged1(object sender, EventArgs e) {
            MostrarDados(dgAlunos.SelectedItem.Cells[0].Text);
            cmdConfirmar.Text = "Alterar";
            cmdExluir.Enabled = true;
        }

        protected void cmdExluir_Click(object sender, EventArgs e) {
            Aluno aluno = new Aluno();
            aluno.Excluir(Convert.ToInt32(dgAlunos.SelectedItem.Cells[0].Text));
            preencheGridAluno();
            LimparCampos();
        }

        protected void cmdLimpar_Click(object sender, EventArgs e) {
            LimparCampos();
        }
    }
}