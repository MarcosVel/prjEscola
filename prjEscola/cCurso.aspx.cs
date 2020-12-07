using prjEscola.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace prjEscola {
    public partial class cCurso : System.Web.UI.Page {
        protected Int32 codigo_curso;
        protected void Page_Load(object sender, EventArgs e) {
            if (!Page.IsPostBack)
            {
                preencheGridCurso();
            }
        }

        void preencheGridCurso()
        {
            dgCurso.DataSource = Curso.PreencheGridCurso();
            dgCurso.DataBind();
        }
        /*
        protected void cmdConfirmar_Click(object sender, EventArgs e)
        {
            adicionarCurso();
        }
        */
        protected void cmdConfirmar_Click(object sender, EventArgs e) {
            adicionarCurso();
        }
        private void adicionarCurso()
        {
            Curso curso = new Curso();
            curso.DSC_CURSO = txtDescCurso.Text.ToString().Trim();
            curso.REQUISITO = txtRequisito.Text.ToString().Trim();
            curso.CARGA_HORARIA = Convert.ToInt32(txtCargaHoraria.Text);
            curso.VALOR_CURSO = txtValorCurso.Text.ToString().Trim();

            if (cmdConfirmar.Text == "Incluir")
            {
                curso.Inserir();
            }
            else
            {
                curso.ID_CURSO = Convert.ToInt32(dgCurso.SelectedItem.Cells[0].Text);
                curso.Alterar();
            }
            LimparCampos();
            preencheGridCurso();
        }

        private void LimparCampos()
        {
            txtDescCurso.Text = "";
            txtRequisito.Text = "";
            txtCargaHoraria.Text = "";
            txtValorCurso.Text = "";
            codigo_curso = 0;
            cmdConfirmar.Text = "Incluir";
            cmdExluir.Enabled = false;
        }

        void MostrarDados(String cod_curso)
        {
            Curso curso = new Curso();
            curso.MonstrarDados_Curso(int.Parse(cod_curso));
            codigo_curso = curso.ID_CURSO;
            txtDescCurso.Text = curso.DSC_CURSO;   
            txtRequisito.Text = curso.REQUISITO;
            txtCargaHoraria.Text = Convert.ToString(curso.CARGA_HORARIA);
            txtValorCurso.Text = curso.VALOR_CURSO;
        }

        protected void dgCurso_SelectedIndexChanged(object sender, EventArgs e) {
            MostrarDados(dgCurso.SelectedItem.Cells[0].Text);
            cmdConfirmar.Text = "Alterar";
            cmdExluir.Enabled = true;
        }

        protected void cmdExluir_Click(object sender, EventArgs e) {
            Curso curso = new Curso();
            curso.Excluir(Convert.ToInt32(dgCurso.SelectedItem.Cells[0].Text));
            preencheGridCurso();
            LimparCampos();
        }

        protected void cmdLimpar_Click(object sender, EventArgs e) {
            LimparCampos();
        }

    }
}