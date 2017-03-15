<%@ Page Title="" Language="C#" MasterPageFile="~/HUB.Master" AutoEventWireup="true" CodeBehind="ManufacturerRegister.aspx.cs" Inherits="UI.ManufacturerRegister" %>

<%@ MasterType VirtualPath="~/HUB.Master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .btn-file {
            position: relative;
            overflow: hidden;
        }

            .btn-file input[type=file] {
                position: absolute;
                top: 0;
                right: 0;
                min-width: 100%;
                min-height: 100%;
                font-size: 100px;
                text-align: right;
                filter: alpha(opacity=0);
                opacity: 0;
                outline: none;
                background: white;
                cursor: inherit;
                display: block;
            }
    </style>
    <div class="float-container">
        <div class="row">
            <div class="col-lg-12">
                <h3>Fabricantes </h3>
            </div>
        </div>
        <div class="row">
            <div class="col-sm-12 col-md-10 col-lg-8">
                <div class="panel panel-default">

                    <div class="panel-body">

                        <div class="form-group row">
                            <label for="txtName" class="col-sm-2 col-form-label">Razão Social</label>
                            <div class="col-sm-10 col-md-10 col-lg-12">

                                <asp:TextBox ID="txtName" class="form-control" runat="server" placeholder="Nome registrado no CNPJ"></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-group row">
                            <label for="inputNomeComercial" class="col-sm-2 col-form-label">Nome Comercial</label>
                            <div class="col-sm-10 col-md-10 col-lg-12">

                                <asp:TextBox ID="txtFormalName" class="form-control" runat="server" placeholder="Nome Comercial (Como é conhecido pelo público)"></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-group row">
                            <label for="inputSite" class="col-sm-2 col-form-label">Site</label>
                            <div class="col-sm-8 col-md-10 col-lg-12">

                                <asp:TextBox ID="txtSite" class="form-control" runat="server" placeholder="www.seusite.com"></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-group row">
                            <label for="inputSite" class="col-sm-2 col-form-label">Telefone</label>
                            <div class="col-sm-8 col-md-10 col-lg-12">
                                <asp:TextBox ID="txtPhone" class="form-control" TextMode="Phone" runat="server" placeholder=""></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-group row">
                            <label for="inputEmail" class="col-sm-2 col-form-label">E-mail</label>
                            <div class="col-sm-8 col-md-10 col-lg-12">

                                <asp:TextBox ID="txtEmail" class="form-control" TextMode="Email" runat="server"></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-group row">
                            <label for="inputPassword" class="col-sm-2 col-form-label">Senha Administrador</label>
                            <div class="col-sm-8 col-md-10 col-lg-12">

                                <asp:TextBox ID="txtPassword" class="form-control" TextMode="Password" runat="server"></asp:TextBox>
                            </div>
                        </div>

                        <fieldset class="form-group row">
                            <label for="inputLogo" class="col-sm-2 col-form-label">Seu Logo</label>
                            <div class="col-sm-8 col-md-10 col-lg-12">
                                <%-- FILE UPLOAD--%>
                                <div class="input-group">
                                    <span class="input-group-btn">
                                        <label class="btn btn-default btn-sm btn-file">
                                            Selecione
                                        <asp:AsyncFileUpload runat="server" ID="AsyncFileUpload1" OnUploadedComplete="AsyncFileUpload1_UploadedComplete"
                                            OnUploadedFileError="AsyncFileUpload1_UploadedFileError" ClientIDMode="AutoID" />
                                        </label>
                                    </span>
                                    <asp:TextBox ID="lblFileName" class="form-control input-sm" Enabled="true" runat="server"></asp:TextBox>
                                    <span class="input-group-btn">
                                        <asp:Button ID="btnCancel" runat="server" class="btn btn-danger btn-sm" OnClick="btnDelFile_Click"
                                            Text="Cancele" Enabled="true" />
                                    </span>
                                </div>
                                <%-- FILE UPLOAD--%>
                                <div class="small">
                                    Anexar Arquivo <small>(arquivos .gif .jpeg ou .png de até 100kb):</small>
                                </div>
                            </div>

                        </fieldset>

                        <div class="form-group row">
                        </div>

                        <div class="form-group row">
                            <div class="offset-sm-2 col-sm-10">
                                <asp:Button ID="btnRegistrar" runat="server" Text="Registrar" class="btn btn-success btn-lg" OnClick="btnRegistrar_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="row">
            <asp:Panel ID="pnlError" runat="server" Visible="false">
                <div class="col-sm-8 col-md-10 col-lg-12">
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
                <div class="col-sm-8 col-md-10 col-lg-12">
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
                <div class="col-sm-8 col-md-10 col-lg-12">
                    <div id="divSuccess" class="alert alert-dismissable alert-success">
                        <button type="button" class="close" data-dismiss="alert">&times;</button>
                        <strong>Aviso</strong>
                        <asp:Label ID="lblSuccessMsg" runat="server" Text=""></asp:Label>
                    </div>
                </div>
            </asp:Panel>
        </div>
    </div>
    <script>

        <%-- //Mostra arquivo uploaded--%>
        $(document).on('change', ":file", function () {
            var input = $(this),
                numFiles = input.get(0).files ? input.get(0).files.length : 1,
                label = input.val().replace(/\\/g, '/').replace(/.*\//, '');
            input.trigger('fileselect', [numFiles, label]);
        });

        $(document).ready(function () {
            $('#<%=AsyncFileUpload1.ClientID%>').on('fileselect', function (event, numFiles, label) {
                $('#<%=lblFileName.ClientID%>').val(label);

                //PostBack clickEvent for btnSaveFile
                __doPostBack('ctl00$ContentPlaceHolder1$btnSaveFile', '');

            });
        });
    </script>

</asp:Content>
