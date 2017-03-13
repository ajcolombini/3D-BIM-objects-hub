<%@ Page Title="" Language="C#" MasterPageFile="~/HUB.Master" AutoEventWireup="true" CodeBehind="ManufacturerRegister.aspx.cs" Inherits="UI.ManufacturerRegister" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="float-container">
        <div class="row">
            <div class="col-sm-12 col-md-10 col-lg-8">
                <div class="panel panel-primary">
                    <div class="panel-heading">
                        <h3 class="panel-title">Cadastro de Fabricante</h3>
                    </div>
                    <div class="panel-body">

                        <div class="form-group row">
                            <label for="txtName" class="col-sm-2 col-form-label">Razão Social</label>
                            <div class="col-sm-10 col-md-10 col-lg-12">
                                <%--<input type="text" class="form-control" id="inputName" placeholder="Nome registrado no CNPJ" required />--%>
                                <asp:TextBox ID="txtName" class="form-control" runat="server" placeholder="Nome registrado no CNPJ" required></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-group row">
                            <label for="inputNomeComercial" class="col-sm-2 col-form-label">Nome Comercial</label>
                            <div class="col-sm-10 col-md-10 col-lg-12">
                                <%--<input type="text" class="form-control" id="inputNomeComercial" placeholder="Nome Comercial (Como é conhecido pelo público)" required/>--%>
                                <asp:TextBox ID="txtFormalName" class="form-control" runat="server" placeholder="Nome Comercial (Como é conhecido pelo público)" required></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-group row">
                            <label for="inputSite" class="col-sm-2 col-form-label">Site</label>
                            <div class="col-sm-8 col-md-10 col-lg-12">
                                <%--<input type="text" class="form-control" id="inputSite" placeholder="www.seusite.com" />--%>
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
                                <%--<input type="email" class="form-control" id="inputEmail" placeholder="" required>--%>
                                <asp:TextBox ID="txtEmail" class="form-control" TextMode="Email" runat="server" required></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-group row">
                            <label for="inputPassword" class="col-sm-2 col-form-label">Senha Administrador</label>
                            <div class="col-sm-8 col-md-10 col-lg-12">
                                <%--<input type="password" class="form-control" id="inputPassword" placeholder="" required />--%>
                                <asp:TextBox ID="txtPassword" class="form-control" TextMode="Password" runat="server" required></asp:TextBox>
                            </div>
                        </div>
                        <fieldset class="form-group row">
                            <label for="inputLogo" class="col-sm-2 col-form-label">Seu Logo</label>
                            <div class="col-sm-8 col-md-10 col-lg-12">
                                <div>
                                    Anexar Arquivo <small>(arquivos .gif .jpeg ou .png de até 100kb):</small>
                                </div>
                                <%-- FILE UPLOAD--%>
                                <div class="input-group">
                                    <span class="input-group-btn">
                                        <label class="btn btn-default btn-sm btn-file">
                                            Selecione
                                    <asp:FileUpload ID="fileUploadLogo" runat="server" Style="display: none;" />
                                        </label>
                                    </span>
                                    <asp:TextBox ID="txtFileName" class="form-control input-sm" Enabled="true" runat="server"></asp:TextBox>
                                    <span class="input-group-btn">
                                        <asp:Button ID="btnSaveFile" runat="server" class="btn btn-primary btn-sm" Text="Confirme" Enabled="true" OnClick="btnSaveFile_Click" Style="display: none" />
                                        <asp:Button ID="btnDelFile" runat="server" class="btn btn-danger btn-sm" Text="Cancele" Enabled="true" OnClick="btnDelFile_Click" CausesValidation="False" />
                                    </span>
                                </div>
                                <%--!FILE UPLOAD--%>
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

        //Mostra arquivo uploaded
        $(document).on('change', ":file", function () {
            var input = $(this),
                numFiles = input.get(0).files ? input.get(0).files.length : 1,
                label = input.val().replace(/\\/g, '/').replace(/.*\//, '');
            input.trigger('fileselect', [numFiles, label]);
        });

        $(document).ready(function () {
            $('#<%=fileUploadLogo.ClientID%>').on('fileselect', function (event, numFiles, label) {
                $('#<%=txtFileName.ClientID%>').val(label);

                //PostBack clickEvent for btnSaveFile
                <%= ClientScript.GetPostBackEventReference(btnSaveFile, string.Empty) %>;
            });
        });
    </script>
</asp:Content>
