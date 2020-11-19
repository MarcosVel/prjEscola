<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPrincipal.Master" AutoEventWireup="true" CodeBehind="cTurma.aspx.cs" Inherits="prjEscola.cTurma" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <section class="featured">
        <div class="containerCentral">

            <%--<h3 style="background: #dff0d8; margin: 0; padding: 5px; border: 1px solid #387030; font-size: 12pt; color: #387030">Cadastro de Pontos</h3>--%>
            <h3 class="h3">Cadastro de Alunos</h3>
            <div style="float: left; width: 100%;">
                <fieldset>
                    <div>
                        <div class="form-group">

                            <div>
                                <label for="nome">
                                    Nome do Aluno</label>
                                <asp:TextBox ID="txtNome" runat="server" Columns="50" CssClass="form-control" MaxLength="50" Width="100%" TabIndex="1"></asp:TextBox>

                            </div>

                            <div class="row">
                                <div class="col-md-4">
                                    <label for="nome">
                                        CPF</label>
                                    <asp:TextBox ID="txtCPF" runat="server" Columns="50" CssClass="form-control" MaxLength="50" Width="100%" TabIndex="1"></asp:TextBox>
                                </div>
                                <div class="col-md-4">
                                    <label for="nome">
                                        Data de Nascimento 
                                    </label>
                                    <asp:TextBox ID="txtDtNascimento" runat="server" Columns="50" CssClass="form-control" MaxLength="50" Width="100%" TabIndex="1"></asp:TextBox>

                                </div>

                                 <div class="col-md-4">
                                    <label for="nome">
                                        Telefone 
                                    </label>
                                    <asp:TextBox ID="txtTelefone" runat="server" Columns="50" CssClass="form-control" MaxLength="50" Width="100%" TabIndex="1"></asp:TextBox>

                                </div>
                            </div>
                            <div>
                            </div>
                            <div>
                                <label for="nome">
                                    e-mail</label>
                                <asp:TextBox ID="txtemail" runat="server" Columns="50" CssClass="form-control" MaxLength="50" Width="100%" TabIndex="1"></asp:TextBox>

                            </div>

                            <div>
                            </div>
                            <div>
                                <label for="nome">
                                    Mãe
                                </label>
                                <asp:TextBox ID="txtMae" runat="server" Columns="50" CssClass="form-control" MaxLength="50" Width="100%" TabIndex="1"></asp:TextBox>

                            </div>
                            <div>
                                <label for="nome">
                                    Pai 
                                </label>
                                <asp:TextBox ID="txtPai" runat="server" Columns="50" CssClass="form-control" MaxLength="50" Width="100%" TabIndex="1"></asp:TextBox>

                            </div>



                        </div>
                    </div>


                </fieldset>
                <div class="form-group">
                    <div class="form-group row">
                        <div class="col-md-3">
                            <asp:Button ID="cmdConfirmar" runat="server" Font-Bold="True"
                                Text="Incluir" CssClass="btn btn-success" Width="100%" OnClick="cmdConfirmar_Click1"/>
                        </div>
                        <div class="col-md-3">
                            <asp:Button ID="cmdExluir" runat="server" Font-Bold="True"
                                Text="Excluir" CssClass="btn btn-success" Width="100%" Enabled="False" OnClick="cmdExluir_Click" />
                        </div>
                        <div class="col-md-3">
                            <asp:Button ID="cmdLimpar" runat="server" Font-Bold="True"
                                Text="Limpar" CssClass="btn btn-success" Width="100%" OnClick="cmdLimpar_Click" />
                        </div>
                        <div class="col-md-3">
                            <asp:Button ID="cmdSair" runat="server" Font-Bold="True"
                                Text="Sair" CssClass="btn btn-success" Width="100%" />
                        </div>
                    </div>
                </div>

                <fieldset>

                    <div>
                        <h4>Alunos Cadastrados</h4>
                    </div>
                    <div>
                        <asp:DataGrid ID="dgAlunos" runat="server" AutoGenerateColumns="False"
                            BackColor="White" BorderColor="Black" BorderStyle="Double" BorderWidth="0px"
                            CellPadding="4" CellSpacing="1" HorizontalAlign="Left" Style="border-right: black thin solid; border-top: black thin solid; border-left: black thin solid; border-bottom: black thin solid; background-color: black"
                            Width="492px" AllowPaging="True" TabIndex="2" OnSelectedIndexChanged="dgAlunos_SelectedIndexChanged1">
                            <FooterStyle BackColor="White" CssClass="dgFooterStyle" Font-Bold="False" Font-Italic="False"
                                Font-Overline="False" Font-Strikeout="False" Font-Underline="False"
                                ForeColor="#333333" />
                            <SelectedItemStyle BackColor="#339966" CssClass="dgSelectedItemStyle" Font-Bold="True"
                                ForeColor="White" />
                            <PagerStyle BackColor="White" Font-Bold="True" Font-Italic="False" Font-Names="Arial"
                                Font-Overline="False" Font-Size="Small" Font-Strikeout="False" Font-Underline="False"
                                ForeColor="Black" HorizontalAlign="Center" Mode="NumericPages" NextPageText=""
                                PrevPageText="" />
                            <AlternatingItemStyle CssClass="dgAlternatingItemStyle" />
                            <ItemStyle BackColor="White" CssClass="dgItemStyle" Font-Bold="False" Font-Italic="False"
                                Font-Overline="False" Font-Strikeout="False" Font-Underline="False" ForeColor="#333333"
                                HorizontalAlign="Left" />
                            <HeaderStyle BackColor="#387030" CssClass="dgHeaderStyle" Font-Bold="True" Font-Italic="False"
                                Font-Overline="False" Font-Strikeout="False" Font-Underline="False" ForeColor="White"
                                HorizontalAlign="Left" />
                            <Columns>
                                <asp:BoundColumn DataField="ID_ALUNO" Visible="False"></asp:BoundColumn>
                                <asp:ButtonColumn CommandName="Select" DataTextField="CPF" HeaderText="CPF"></asp:ButtonColumn>
                                <asp:ButtonColumn CommandName="Select" DataTextField="NOME"
                                    HeaderText="NOME">
                                    <HeaderStyle Width="70%" />
                                </asp:ButtonColumn>
                                <asp:ButtonColumn
                                    HeaderText="EMAIL" DataTextField="EMAIL"></asp:ButtonColumn>
                            </Columns>
                        </asp:DataGrid>
                    </div>


                </fieldset>


            </div>
        </div>
    </section>
</asp:Content>
