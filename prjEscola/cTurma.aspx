<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPrincipal.Master" AutoEventWireup="true" CodeBehind="cTurma.aspx.cs" Inherits="prjEscola.cTurma" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <section class="featured">
        <div class="containerCentral">

            <%--<h3 style="background: #dff0d8; margin: 0; padding: 5px; border: 1px solid #387030; font-size: 12pt; color: #387030">Cadastro de Pontos</h3>--%>
            <h3 class="h3">Cadastro de Turma</h3>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>                    
                    <div style="float: left; width: 100%;">
                        <fieldset>

                            <div class="form-group">
                                <div class="row">
                                    <div class="col-md-6">
                                        <label for="nome">
                                            Instrutor</label>

                                        <asp:DropDownList ID="cboInstrutor" CssClass="form-control" runat="server"></asp:DropDownList>
                                    </div>
                                    <div class="col-md-6">
                                        <label for="nome">
                                            Curso</label>

                                        <asp:DropDownList ID="cboCurso" CssClass="form-control" runat="server" OnSelectedIndexChanged="cboCurso_SelectedIndexChanged"></asp:DropDownList>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-4">
                                        <label for="nome">
                                            Data de Início</label>
                                        <asp:TextBox ID="txtData_Inicio" runat="server" Columns="50" CssClass="form-control" MaxLength="50" Width="100%" TabIndex="1"></asp:TextBox>
                                    </div>
                                    <div class="col-md-4">
                                        <label for="nome">
                                            Data de Término
                                        </label>
                                        <asp:TextBox ID="txtData_Termino" runat="server" Columns="50" CssClass="form-control" MaxLength="50" Width="100%" TabIndex="1"></asp:TextBox>

                                    </div>

                                    <div class="col-md-4">
                                        <label for="nome">
                                            Carga Horária 
                                        </label>
                                        <asp:TextBox ID="txtCargaHoraria" runat="server" Columns="50" CssClass="form-control" MaxLength="50" Width="100%" TabIndex="1"></asp:TextBox>

                                    </div>
                                </div>
                            </div>

                        </fieldset>
                        <div class="form-group">
                            <div class="form-group row">
                                <div class="col-md-3">
                                    <asp:Button ID="cmdConfirmar" runat="server" Font-Bold="True"
                                        Text="Incluir" CssClass="btn btn-success" Width="100%" OnClick="cmdConfirmar_Click" />
                                </div>
                                <div class="col-md-3">
                                    <asp:Button ID="cmdExluir" runat="server" Font-Bold="True"
                                        Text="Excluir" CssClass="btn btn-success" Width="100%" Enabled="False" />
                                </div>
                                <div class="col-md-3">
                                    <asp:Button ID="cmdLimpar" runat="server" Font-Bold="True"
                                        Text="Limpar" CssClass="btn btn-success" Width="100%" />
                                </div>
                                <div class="col-md-3">
                                    <asp:Button ID="cmdSair" runat="server" Font-Bold="True"
                                        Text="Sair" CssClass="btn btn-success" Width="100%" />
                                </div>
                            </div>
                        </div>

                        <fieldset>

                            <div>
                                <h4>Turmas Cadastradas</h4>
                            </div>
                            <div>
                                <asp:GridView ID="grvTurma" runat="server" AutoGenerateColumns="false" OnRowCommand="grvTurma_RowCommand">
                                    <Columns>
                                        <asp:TemplateField HeaderText="CODIGO">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lblIdTurma" runat="server" CommandArgument='<%#Eval("ID_TURMA").ToString()%>' Text='<%#Eval("ID_TURMA").ToString()%>'>
                                                </asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="DSC_CURSO" HeaderText="CURSO" />
                                        <asp:BoundField DataField="NOME_INSTRUTOR" HeaderText="INSTRUTOR" />
                                        <asp:BoundField DataField="DATA_INICIO" HeaderText="INICIO" />
                                        <asp:BoundField DataField="DATA_TERMINO" HeaderText="TERMINO" />
                                        <asp:BoundField DataField="CARGA_HORARIA" HeaderText="CARGA HORÁRIA" />
                                    </Columns>
                                    <SelectedRowStyle BackColor="Yellow" />
                                </asp:GridView>
                            </div>


                        </fieldset>


                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </section>
</asp:Content>
