<%@ Page Title="" Language="C#" MasterPageFile="~/HUB.Master" AutoEventWireup="true" CodeBehind="Produto.aspx.cs" Inherits="UI.Register" %>

<%@ MasterType VirtualPath="~/HUB.Master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- FILEUPLOAD: load the JS files in the right order -->
    <script src="bootstrap/js/plugins/fileinput.js"></script>
    <script src="bootstrap/js/plugins/locales/pt-BR.js"></script>
    <link href="css/fileinput.min.css" rel="stylesheet" />
    <%--Tema--%>
    <link href="bootstrap/js/themes/explorer/theme.css" rel="stylesheet" />
    <script src="bootstrap/js/themes/explorer/theme.js"></script>
    <!-- /FILEUPLOAD: load the JS files in the right order -->

    <script>
        ////Generate new guid
        //function S4() {
        //    return (((1 + Math.random()) * 0x10000) | 0).toString(16).substring(1);
        //}
        //function newGuid() {
        //    // then to call it, plus stitch in '4' in the third group
        //    guid = (S4() + S4() + "-" + S4() + "-4" + S4().substr(0, 3) + "-" + S4() + "-" + S4() + S4() + S4()).toLowerCase();
        //    return guid;
        //}
    </script>

    <div class="float-container">
        <div class="row">
            <div class="col-lg-12">
                <h3>Produtos </h3>

            </div>
        </div>
        <asp:HiddenField ID="hdnProdutoId" runat="server" OnValueChanged="hdnProdutoId_ValueChanged" />
        <div class="row">
            <div class="col-sm-12 col-md-10 col-lg-8">
                <div class="panel panel-default">
                    <div class="panel-body">
                        <div class="form-group row">
                            <label for="lblFabricanteNome" class="col-sm-2 col-form-label">Fabricante</label>
                            <div class="col-sm-10 col-md-10 col-lg-12">
                                <asp:Label ID="lblFabricanteNome" runat="server" Text=""></asp:Label>
                                <asp:HiddenField ID="hdnFabricanteId" runat="server" />

                                <asp:Panel ID="pnlDDLFabricante" runat="server" Visible="true">
                                    <div class="form-group row">
                                        <label for="txtPhone" class="col-sm-2 col-form-label">Fabricante</label>
                                        <div class="col-sm-8 col-md-6 col-lg-6">
                                            <asp:DropDownList ID="ddlFabricante" runat="server" CssClass="form-control"></asp:DropDownList>
                                        </div>
                                    </div>
                                </asp:Panel>
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

                        <%--<div class="form-group row">
                            <label for="ddlCategoria" class="col-sm-2 col-form-label">Categoria</label>
                            <div class="col-sm-8 col-md-6 col-lg-6">
                                <asp:DropDownList ID="ddlCategoria" runat="server" CssClass="form-control"></asp:DropDownList>
                            </div>
                        </div>--%>

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
                                        <asp:ListItem Text="N/A" Value="0"></asp:ListItem>
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
                                    <asp:ListItem Text="N/A" Value=""></asp:ListItem>
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
                                <div class="input-group">
                                    <span class="input-group-addon" id="basic-addon1">R$</span>
                                    <asp:TextBox ID="txtPreco" class="form-control" runat="server" placeholder=""></asp:TextBox>
                                </div>
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

                            <label for="imgProdUpload" class="col-form-label">Imagem do Produto</label>
                             <div><small>Extensões aceitas: jpg", "png", "jpeg", "bmp"</small></div>
                            <input id="imgProdUpload" type="file" class="file-loading" accept="image/*" />
                            <script>
                                
                                var newImageId = $('#<%=hdnProdutoId.ClientID%>').val();
                                //lert('newImageId:  ' + newImageId);

                                $(document).on('ready', function () {

                                    //Get file input object
                                    var $inputCtrl = $("#imgProdUpload");

                                    $("#imgProdUpload").fileinput({
                                        language: "pt-BR",
                                        theme: "explorer",
                                        previewFileType: "image",
                                        browseOnZoneClick: true,
                                        uploadAsync: true,
                                        //uploadAsync: false,
                                        //showUpload: false, // hide upload button
                                        //showRemove: true,
                                        uploadUrl: "ImageUploadReceiver.ashx",
                                        showUploadedThumbs: false,
                                        allowedFileExtensions: ["jpg", "png", "jpeg", "bmp"],
                                        uploadExtraData: { id: newImageId }
                                    });
                                    //.on("filebatchselected", function (event, files) {
                                    //    // trigger upload method immediately after files are selected
                                    //    $inputCtrl.fileinput("upload");
                                    //});
                                });
                            </script>
                        </div>
                        <br />
                        <div class="form-group row">
                            <!-- PORTUGESE (BRAZILIAN) FILE INPUT -->
                            <label class="control-label">Selecione o(s) Arquivo(s)</label>
                            <div><small>Máximo 7 arquivos por vez. Extensões aceitas: "rvt", "rfa", "pla", "skp", "pln", "gsm", "dwg"</small></div>
                            <input id="docsFileUpload" name="docsFileUpload[]" multiple type="file" class="file-loading" />
                            <!-- PORTUGESE (BRAZILIAN) FILE INPUT -->
                            <script>
                                $(document).on('ready', function () {

                                    //Get file input object
                                    var $inputCtrl = $("#docsFileUpload");

                                    $("#docsFileUpload").fileinput({
                                        language: "pt-BR",
                                        theme: "explorer",
                                        fileTypeSettings: ["object"],
                                        allowedPreviewTypes: false,
                                        browseOnZoneClick: true,
                                        uploadAsync: true,
                                        //uploadAsync: false,
                                        //showUpload: false, // hide upload button
                                        //showRemove: true,
                                        previewFileIconSettings: {
                                            'rvt': '<i class="fa fa-cubes text-primary"></i>',
                                            'rfa': '<i class="fa fa-cubes text-success"></i>',
                                            'skp': '<i class="fa fa-cubes text-danger"></i>',
                                            'pla': '<i class="fa fa-cubes text-warning"></i>',
                                            'gsm': '<i class="fa fa-cubes text-info"></i>',
                                            'dwg': '<i class="fa fa-cubes text-default"></i>',
                                            'pla': '<i class="fa fa-cubes"></i>'
                                        },
                                        minFileCount: 1,
                                        maxFileCount: 7,
                                        uploadUrl: "FileUploadReceiver.ashx",
                                        allowedFileExtensions: ["rvt", "rfa", "pla", "skp", "pln", "gsm", "dwg"],
                                        uploadExtraData: { id: newImageId }

                                    })//.on("filebatchselected", function (event, files) {
                                        //// trigger upload method immediately after files are selected
                                        //$inputCtrl.fileinput("upload");

                                    .on('filedeleted', function (event, key) {
                                       alert('Key = ' + key);
                                    });
                                        
                                });
                            </script>
                        </div>

                    </div>
                </div>
            </div>

            <div class="row">
                <div class="col-sm-12 col-md-10 col-lg-8">
                    <div class="panel panel-default">
                        <div class="panel-body">
                            <div class="form-group row">
                                <div class="col-sm-4 col-md-4 col-lg-2">
                                    <asp:LinkButton ID="lnkRegistrar" runat="server" class="btn btn-success btn-lg" OnClick="lnkRegistrar_Click"><i class="fa fa-check">&nbsp;</i>Registrar</asp:LinkButton>
                                </div>
                                <div class="col-sm-4 col-md-4 col-lg-2">
                                    <asp:LinkButton ID="lnkEditar" runat="server" class="btn btn-primary btn-lg"><i class="fa fa-pencil-square-o">&nbsp;</i>Editar</asp:LinkButton>
                                </div>
                                <div class="col-sm-4 col-md-4 col-lg-2">
                                    <asp:LinkButton ID="lnkExcluir" runat="server" class="btn btn-danger btn-lg"><i class="fa fa-trash-o">&nbsp;</i>Excluir</asp:LinkButton>
                                </div>
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
</asp:Content>
