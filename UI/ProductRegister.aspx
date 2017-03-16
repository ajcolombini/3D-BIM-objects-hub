<%@ Page Title="" Language="C#" MasterPageFile="~/HUB.Master" AutoEventWireup="true" CodeBehind="ProductRegister.aspx.cs" Inherits="UI.Register" %>

<%@ MasterType VirtualPath="~/HUB.Master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="//netdna.bootstrapcdn.com/twitter-bootstrap/2.3.1/css/bootstrap-combined.no-icons.min.css" rel="stylesheet"/>

    <div class="float-container">
        <div class="row">
            <div class="col-lg-12">
                <h3>Produtos </h3>
            </div>
        </div>
        <div class="row">
            <div class="col-sm-12 col-md-10 col-lg-8">
                <div class="panel panel-default">
                    <div class="panel-body">
                        <div class="form-group row">
                            <label for="lblFabricanteNome" class="col-sm-2 col-form-label">Fabricante</label>
                            <div class="col-sm-10 col-md-10 col-lg-12">
                                <asp:Label ID="lblFabricanteNome" runat="server" Text=""></asp:Label>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-sm-12 col-md-10 col-lg-8">
                <div class="panel panel-default">

                    <div class="panel-body">

                        <div class="form-group row">
                            <label for="txtCodigo" class="col-sm-2 col-form-label">Código do Produto</label>
                            <div class="col-sm-10 col-md-10 col-lg-12">
                                <asp:TextBox ID="txtCodigo" class="form-control" runat="server" placeholder="" required></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-group row">
                            <label for="txtFormalName" class="col-sm-2 col-form-label">Nome Produto</label>
                            <div class="col-sm-10 col-md-10 col-lg-12">
                                <asp:TextBox ID="txtName" class="form-control" runat="server" placeholder="" required></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-group row">
                            <label for="txtDescricao" class="col-sm-2 col-form-label">Descrição</label>
                            <div class="col-sm-10 col-md-10 col-lg-12">
                                <asp:TextBox ID="txtDescricao" class="form-control" runat="server" placeholder="" required></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-group row">
                            <label for="txtPhone" class="col-sm-2 col-form-label">Família</label>
                            <div class="col-sm-8 col-md-6 col-lg-6">
                                <asp:DropDownList ID="ddlFamilia" runat="server" required CssClass="form-control"></asp:DropDownList>
                            </div>
                        </div>

                        <div class="form-group row">
                            <label for="ddlCategoria" class="col-sm-2 col-form-label">Categoria</label>
                            <div class="col-sm-8 col-md-6 col-lg-6">
                                <asp:DropDownList ID="ddlCategoria" runat="server" CssClass="form-control"></asp:DropDownList>
                            </div>
                        </div>

                        <div class="form-group row">
                            <label for="inputPassword" class="col-sm-2 col-form-label">Subgrupo</label>
                            <div class="col-sm-8 col-md-6 col-lg-6">
                                <asp:DropDownList ID="ddlSubgrupo" runat="server" CssClass="form-control"></asp:DropDownList>
                            </div>
                        </div>

                        <div class="form-group row">
                            <label for="ddlVoltagem" class="col-sm-2 col-form-label">Voltagem</label>
                            <div class="col-sm-8 col-md-6 col-lg-4">
                                <div class="dropdown">
                                    <asp:DropDownList ID="ddlVoltagem" runat="server" CssClass="form-control">
                                        <asp:ListItem Text="110 V" Value="110"></asp:ListItem>
                                        <asp:ListItem Text="220 V" Value="220"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>

                        <div class="form-group row">
                            <label for="ddlClasseConsumo" class="col-sm-2 col-form-label">Classificação Consumo PROCEL</label>
                            <div class="col-sm-8 col-md-6 col-lg-4">
                                <asp:DropDownList ID="ddlClasseConsumo" runat="server" CssClass="form-control">
                                    <asp:ListItem Text="Classe A" Value="A"></asp:ListItem>
                                    <asp:ListItem Text="Classe B" Value="B"></asp:ListItem>
                                    <asp:ListItem Text="Classe C" Value="C"></asp:ListItem>
                                    <asp:ListItem Text="Classe D" Value="D"></asp:ListItem>
                                    <asp:ListItem Text="Classe E" Value="E"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>

                        <div class="form-group row">
                            <label class="col-lg-12 control-label ">Dimensões</label>
                            <div class="col-sm-12 col-md-12 col-lg-8">
                                <div class="form-inline">
                                    <div class="form-group ">
                                        <div class="col-sm-1 col-md-1 col-lg-1">
                                            <label class="sronly" for="txt_month">Largura</label>
                                            <asp:TextBox ID="txtLargura" runat="server" class="form-control input-sm" Style="width: 60px" placeholder="L (cm)"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <div class="col-sm-1 col-md-1 col-lg-1">
                                            <label class="sronly" for="txt_day">Altura</label>
                                            <asp:TextBox ID="txtAltura" runat="server" class="form-control input-sm" Style="width: 60px" placeholder="H (cm)"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <div class="col-sm-1 col-md-1 col-lg-1">
                                            <label class="sronly" for="txt_year">Profundidade</label>
                                            <asp:TextBox ID="txtProfundidade" runat="server" class="form-control input-sm" Style="width: 60px" placeholder="P (cm)"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <p class="help-block"></p>
                            </div>
                        </div>

                        <div class="form-group row">
                            <label for="txtPreco" class="col-sm-2 col-form-label">Preço Sugerido</label>
                            <div class="col-sm-8 col-md-6 col-lg-4">
                                <asp:TextBox ID="txtPreco" class="form-control" runat="server" placeholder=""></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-group row">
                            <label for="ddlStatus" class="col-sm-2 col-form-label">Status</label>
                            <div class="col-sm-8 col-md-6 col-lg-4">
                                <asp:DropDownList ID="ddlStatus" runat="server" Enabled="false" CssClass="form-control">
                                    <asp:ListItem Text="Ativo" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="Inativo" Value="0"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>


                        <div class="form-group row">
                            <label for="imgProduto" class="col-sm-2 col-form-label">Imagem</label>
                            <div class="col-sm-8 col-md-6 col-lg-4">
                                <asp:Image ID="imgProduto" runat="server" />
                            </div>
                        </div>

                        <%--<fieldset class="form-group row">
                            <label for="AsyncFileUpload1" class="col-sm-2 col-form-label">Seu Logo</label>
                            <div class="col-sm-10 col-md-10 col-lg-12">
                               
                                <div class="input-group">
                                    <span class="input-group-btn">
                                        <label class="btn btn-default btn-sm btn-file">
                                            Selecione
                                        <asp:AsyncFileUpload runat="server" ID="AsyncFileUpload1" OnUploadedComplete="AsyncFileUpload1_UploadedComplete"
                                            OnUploadedFileError="AsyncFileUpload1_UploadedFileError" ClientIDMode="AutoID" />
                                        </label>
                                    </span>
                                    <asp:Label ID="lblFileName" class="form-control input-sm" runat="server" Text=""></asp:Label>
                                    <span class="input-group-btn">
                                        <asp:Button ID="btnCancel" runat="server" class="btn btn-danger btn-sm" OnClick="btnCancel_Click"
                                            Text="Cancele" Enabled="true" />
                                    </span>
                                </div>
                              
                                <div class="small">
                                    Anexar Arquivo <small>(arquivos .gif .jpeg ou .png de até 100kb):</small>
                                </div>
                            </div>

                        </fieldset>--%>

                        <div class="form-group row">
                        </div>

                        <div class="form-group row">
                            <div class="offset-sm-2 col-sm-10">
                                <asp:Button ID="btnRegistrar" runat="server" Text="Registrar" class="btn btn-success btn-lg"><i class="icon-folder-open"></i></asp:Button>
                                <asp:Panel ID="pnlAdmin" runat="server" Visible="false">
                                    <asp:Button ID="btnEditar" runat="server" Text="Editar" class="btn btn-primary btn-lg" />
                                    <asp:Button ID="btnExcluir" runat="server" Text="Excluir" class="btn btn-danger btn-lg" />
                                </asp:Panel>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="row">
            <asp:Panel ID="pnlError" runat="server" Visible="false">
                <div class="col-sm-12 col-md-10 col-lg-8">
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
                <div class="col-sm-12 col-md-10 col-lg-8">
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
                <div class="col-sm-12 col-md-10 col-lg-8">
                    <div id="divSuccess" class="alert alert-dismissable alert-success">
                        <button type="button" class="close" data-dismiss="alert">&times;</button>
                        <strong>Aviso</strong>
                        <asp:Label ID="lblSuccessMsg" runat="server" Text=""></asp:Label>
                    </div>
                </div>
            </asp:Panel>
        </div>
    </div>
</asp:Content>
