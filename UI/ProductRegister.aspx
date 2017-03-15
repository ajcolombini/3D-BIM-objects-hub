<%@ Page Title="" Language="C#" MasterPageFile="~/HUB.Master" AutoEventWireup="true" CodeBehind="ProductRegister.aspx.cs" Inherits="UI.Register" %>

<%@ MasterType VirtualPath="~/HUB.Master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

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
                        <asp:Label ID="lblFabricanteNome" runat="server" Text=""></asp:Label>
                    </div>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-sm-12 col-md-10 col-lg-8">
                <div class="panel panel-default">

                    <div class="panel-body">

                        <div class="form-group row">
                            <label for="txtName" class="col-sm-2 col-form-label">Código do Produto</label>
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
                            <label for="txtSite" class="col-sm-2 col-form-label">Descrição</label>
                            <div class="col-sm-10 col-md-10 col-lg-12">
                                <asp:TextBox ID="txtDescricao" class="form-control" runat="server" placeholder=""></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-group row">
                            <label for="txtPhone" class="col-sm-2 col-form-label">Família</label>
                            <div class="col-sm-10 col-md-10 col-lg-12">
                                <asp:DropDownList ID="ddlFamilia" runat="server"></asp:DropDownList>
                            </div>
                        </div>

                        <div class="form-group row">
                            <label for="txtEmail" class="col-sm-2 col-form-label">Categoria</label>
                            <div class="col-sm-10 col-md-10 col-lg-12">
                                <asp:DropDownList ID="ddlCategoria" runat="server"></asp:DropDownList>
                            </div>
                        </div>

                        <div class="form-group row">
                            <label for="inputPassword" class="col-sm-2 col-form-label">Subgrupo</label>
                            <div class="col-sm-10 col-md-10 col-lg-12">
                                <asp:DropDownList ID="ddlSubgrupo" runat="server"></asp:DropDownList>
                            </div>
                        </div>

                        <div class="form-group row">
                            <label class="col-lg-12 control-label ">Dimensões</label>
                            <div class="col-lg-12">
                                <div class="form-inline">
                                    <div class="form-group ">
                                        <div class="col-lg-1">
                                            <label class="sronly" for="txt_month">Largura</label>
                                            <input type="text" id="txt_month" name="txt_month" class="form-control input-sm" style="width: 60px" placeholder="MM" required maxlength="2" data-validation-required-message="Month is required">
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <div class="col-lg-1">
                                            <label class="sronly" for="txt_day">Altura</label>
                                            <input type="text" id="txt_day" name="txt_day" class="form-control input-sm" style="width: 60px" placeholder="DD" required maxlength="2" data-validation-required-message="Day is required">
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <div class="col-lg-1">
                                            <label class="sronly" for="txt_year">Profundidade</label>
                                            <input type="text" id="txt_year" name="txt_year" class="form-control input-sm" style="width: 60px" placeholder="YY" required maxlength="4" data-validation-required-message="Year is required">
                                        </div>
                                    </div>
                                </div>
                                <p class="help-block"></p>
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
                                <asp:Button ID="btnRegistrar" runat="server" Text="Registrar" class="btn btn-success btn-lg" />
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
