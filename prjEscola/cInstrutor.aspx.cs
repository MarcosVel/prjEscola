using prjEscola.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace prjEscola {
    public partial class cInstrutor : System.Web.UI.Page {
        protected Int32 codigo_instrutor;
        protected void Page_Load(object sender, EventArgs e) {
            if (!Page.IsPostBack) {
                preencheGridInstrutor();
            }
        }
        void preencheGridInstrutor() {
            dgInstrutor.DataSource = Instrutor.PreencheGridInstrutor();
            dgInstrutor.DataBind();
        }

        protected void cmdConfirmar_Click(object sender, EventArgs e) {
            adicionarInstrutor();
        }

        private void adicionarInstrutor() {
            Instrutor instrutor = new Instrutor();
            instrutor.NOME_INSTRUTOR = txtNomeInstrutor.Text.ToString().Trim();
            instrutor.EMAIL = txtEmailInstrutor.Text.ToString().Trim();
            instrutor.VALOR_HORA = txtValor_Hora.Text.ToString().Trim();
            instrutor.CERTIFICADOS = txtCertificados.Text.ToString().Trim();
            

            if (cmdConfirmar.Text == "Incluir") {
                instrutor.Inserir();
            }
            else {
                instrutor.ID_INSTRUTOR = Convert.ToInt32(dgInstrutor.SelectedItem.Cells[0].Text);
                instrutor.Alterar();
            }
            LimparCampos();
            preencheGridInstrutor();
        }

        private void LimparCampos() {
            txtNomeInstrutor.Text = "";
            txtEmailInstrutor.Text = "";
            txtValor_Hora.Text = "";
            txtCertificados.Text = "";
            codigo_instrutor = 0;
            cmdConfirmar.Text = "Incluir";
            cmdExluir.Enabled = false;
        }

        void MostrarDados(String cod_instrutor) {
            Instrutor instrutor = new Instrutor();
            instrutor.MonstrarDados_Instrutor(int.Parse(cod_instrutor));
            codigo_instrutor = instrutor.ID_INSTRUTOR;
            txtNomeInstrutor.Text = instrutor.NOME_INSTRUTOR;
            txtEmailInstrutor.Text = instrutor.EMAIL;
            txtValor_Hora.Text = instrutor.VALOR_HORA;
            txtCertificados.Text = instrutor.CERTIFICADOS;
        }

        protected void dgInstrutor_SelectedIndexChanged(object sender, EventArgs e) {
            MostrarDados(dgInstrutor.SelectedItem.Cells[0].Text);
            cmdConfirmar.Text = "Alterar";
            cmdExluir.Enabled = true;
        }

        protected void cmdExluir_Click(object sender, EventArgs e) {
            Instrutor instrutor = new Instrutor();
            instrutor.Excluir(Convert.ToInt32(dgInstrutor.SelectedItem.Cells[0].Text));
            preencheGridInstrutor();
            LimparCampos();
        }

        protected void cmdLimpar_Click(object sender, EventArgs e) {
            LimparCampos();
        }
    }
}