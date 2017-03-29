<%@ Page Title="" Language="C#" MasterPageFile="~/HUB.Master" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="UI.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row">
        <div class="col-lg-12">
            <h3>Buscar </h3>
            <div class="alert alert-success alert-dismissable">
                <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
                Bem-vindo ao BIM Sphere. 
                 <br />
                Faça sua busca por código de modelo, nome do modelo ou fabricante...
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-lg-12">
            <div class="input-group input-group-lg">
                <asp:TextBox ID="txtBusca" CssClass="form-control" type="text" placeholder="Fabricante, Modelo, Código ..." runat="server"></asp:TextBox>
                <span class="input-group-btn">
                    <asp:Button ID="btnBuscar" CssClass="btn btn-success" runat="server" Text="Buscar" OnClick="btnBuscar_Click" />
                </span>
            </div>
            <!-- /input-group -->
        </div>
    </div>
    <br />
    <!-- /.row -->
    <div class="row">
        <div class="col-lg-12">
            <asp:Panel ID="pnlResults" runat="server" Visible="true">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h3 class="panel-title"><i class="fa fa-grid"></i>Resultados</h3>
                    </div>
                    <!-- Table -->
                    <div class="panel-body">
                        <asp:GridView ID="gvwResults" runat="server" class="table table-responsive table-hover" AutoGenerateColumns="False" OnRowDataBound="gvwResults_RowDataBound">
                            <Columns>
                                <asp:TemplateField HeaderText="Fabricante">
                                    <ItemTemplate>
                                        <asp:Label ID="lblFabricante" runat="server" Text='<%# Eval("NomeFabricante")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Produto">
                                    <ItemTemplate>
                                        <asp:Label ID="lblProduto" runat="server" Text='<%# Eval("DescricaoProduto")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Família">
                                    <ItemTemplate>
                                        <asp:Label ID="lblFamilia" runat="server" Text='<%# Eval("Familia")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Tipo">
                                    <ItemTemplate>
                                        <asp:Label ID="lblSubtipo" runat="server" Text='<%# Eval("Tipo")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Imagem">
                                    <ItemTemplate>
                                        <div class="thumbnail">
                                            <asp:Image ID="imgProduto" runat="server" ImageUrl='<%=Getbase64Image(Eval("Imagem"))%>'  />
                                        </div>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </asp:Panel>
        </div>
    </div>
    <!-- /.row -->
    <div class="row">
        <asp:Panel ID="pnlError" runat="server" Visible="false">
            <div class="col-sm-12 col-md-12 col-lg-12">
                <div id="divError" class="alert alert-dismissable alert-danger">
                    <button type="button" class="close" data-dismiss="alert">&times;</button>
                    <strong>Atenção</strong>
                    <asp:Label ID="lblErrorMsg" runat="server" Text=""></asp:Label>
                </div>
            </div>
        </asp:Panel>
    </div>
    <div class="row">
        <asp:Panel ID="pnlInfo" runat="server" Visible="false">
            <div class="col-sm-12 col-md-12 col-lg-12">
                <div id="divInfo" class="alert alert-dismissable alert-info">
                    <button type="button" class="close" data-dismiss="alert">&times;</button>
                    <strong>Aviso</strong>
                    <asp:Label ID="lblInfoMsg" runat="server" Text=""></asp:Label>
                </div>
            </div>
        </asp:Panel>
    </div>
    <div class="row">
        <asp:Panel ID="pnlSuccess" runat="server" Visible="false">
            <div class="col-sm-12 col-md-12 col-lg-12">
                <div id="divSuccess" class="alert alert-dismissable alert-success">
                    <button type="button" class="close" data-dismiss="alert">&times;</button>
                    <strong>Aviso</strong>
                    <asp:Label ID="lblSuccessMsg" runat="server" Text=""></asp:Label>
                </div>
            </div>
        </asp:Panel>
    </div>
</asp:Content>
