<%@ Page Title="" Language="C#" MasterPageFile="~/HUB.Master" AutoEventWireup="true" CodeBehind="ManufacturerRegister.aspx.cs" Inherits="UI.ManufacturerRegister" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="panel panel-primary">
            <div class="panel-heading">
                <h3 class="panel-title">Cadastro de Fabricante</h3>
            </div>
            <div class="panel-body">

                <div class="form-group row">
                    <label for="inputName" class="col-sm-2 col-form-label">Razão Social</label>
                    <div class="col-sm-10 col-md-10">
                        <input type="text" class="form-control" id="inputName" placeholder="Nome registrado no CNPJ" required />
                    </div>
                </div>

                <div class="form-group row">
                    <label for="inputNomeComercial" class="col-sm-2 col-form-label">Nome Comercial</label>
                    <div class="col-sm-10 col-md-10">
                        <input type="text" class="form-control" id="inputNomeComercial" placeholder="Nome Comercial (Como é conhecido pelo público)" required/>
                    </div>
                </div>

                <div class="form-group row">
                    <label for="inputSite" class="col-sm-2 col-form-label">Site</label>
                    <div class="col-sm-10 col-md-10">
                        <input type="text" class="form-control" id="inputSite" placeholder="www.seusite.com" />
                    </div>
                </div>

                <div class="form-group row">
                    <label for="inputEmail" class="col-sm-2 col-form-label">E-mail</label>
                    <div class="col-sm-10">
                        <input type="email" class="form-control" id="inputEmail" placeholder="" required>
                    </div>
                </div>

                <div class="form-group row">
                    <label for="inputPassword" class="col-sm-2 col-form-label">Senha Administrador</label>
                    <div class="col-sm-10 col-md-10">
                        <input type="password" class="form-control" id="inputPassword" placeholder="" required />
                    </div>
                </div>
                <fieldset class="form-group row">
                    <label for="inputLogo" class="col-sm-2 col-form-label">Seu Logo</label>
                    <div class="col-sm-10 col-md-10">
                        <div>
                            Anexar Arquivo <small>(arquivos .gif .jpeg ou .png de até 100kb):</small>
                        </div>
                        <%-- FILE UPLOAD--%>
                        <div class="input-group">
                            <label class="input-group-btn">
                                <span class="btn btn-info">Selecione…
                                    <input type="file" style="display: none;" multiple=""/>
                                </span>
                            </label>
                            <input id="fileUploaded" type="text" class="form-control" readonly=""/>
                        </div>
                        <%--!FILE UPLOAD--%>
                    </div>
                </fieldset>
                <div class="form-group row">
                </div>
                <div class="form-group row">
                    <div class="offset-sm-2 col-sm-10">
                        <asp:Button ID="btnRegistrar" runat="server" Text="Registrar" class="btn btn-primary btn-lg" OnClick="btnRegistrar_Click" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script>

        //Mostra arquivo uploaded
        $(document).on('change', ':file', function () {
            var input = $(this),
                numFiles = input.get(0).files ? input.get(0).files.length : 1,
                label = input.val().replace(/\\/g, '/').replace(/.*\//, '');
            input.trigger('fileselect', [numFiles, label]);
        });
        
        $(document).ready(function () {
            $(':file').on('fileselect', function (event, numFiles, label) {
                $('#fileUploaded').val(label);
            });
        });
    </script>
</asp:Content>
