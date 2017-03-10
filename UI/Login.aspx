<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="UI.Login" Async="True" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title></title>

    <link href="bootstrap/css/bootstrap.css" rel="stylesheet" type="text/css" />
    <link href="css/local.css" rel="stylesheet" type="text/css" />

    <script src="js/jquery-1.10.2.min.js" type="text/javascript"></script>
    <script src="bootstrap/js/bootstrap.js" type="text/javascript"></script>
    <style type="text/css">
        .colored {
            /* Permalink - use to edit and share this gradient: http://colorzilla.com/gradient-editor/#6db3f2+0,54a3ee+50,3690f0+51,1e69de+100;Blue+Gloss+%233 */
            background: #0c487d; /* Old browsers */
        }
    </style>

</head>
<body class="container colored">
    <form id="loginForm" runat="server">
        <div>
            <asp:HiddenField ID="hdnUserDetails" runat="server" />
            <div class="container" style="margin-top: 30px">
                <div class="row">
                    <div class="col-md-4"></div>
                    <div class="col-md-4">
                        <div class="login-panel panel panel-default">
                            <div class="panel-heading">
                                <div style="align-content: center; text-align: center; vertical-align: middle;">
                                    <img alt="logo" src="images/BIMHub.PNG" />
                                </div>
                            </div>
                            <div class="panel-heading">
                                <h4>Acesso</h4>
                            </div>
                            <div class="panel-body">

                                <fieldset>
                                    <div class="form-group">
                                        <asp:TextBox ID="txtEmail" runat="server" class="form-control" placeholder="e-mail" required="required" autofocus="autofocus"></asp:TextBox>
                                    </div>
                                    <div class="form-group">
                                        <asp:TextBox ID="txtPassword" runat="server" class="form-control" placeholder="senha" type="password" required="required"></asp:TextBox>
                                    </div>
                                    <div class="checkbox">
                                        <asp:LinkButton ID="lnkForgotPassword" runat="server">Esqueci minha senha</asp:LinkButton>
                                    </div>
                                    <asp:Button ID="btnSignIn" runat="server" Text="Entrar" type="button" class="btn btn-sm btn-success" OnClick="btnSignIn_Click" />

                                </fieldset>

                            </div>
                            <div class="row">
                                <asp:Panel ID="pnlError" runat="server" Visible="false">
                                    <div class="col-lg-10">
                                        <div id="divPnlError" class="alert alert-dismissable alert-danger">
                                            <button type="button" class="close" data-dismiss="alert">&times;</button>
                                            <strong>Atenção</strong> <asp:Label ID="lblErrorMsg" runat="server" Text=""></asp:Label></span>
                                        </div>
                                    </div>
                                </asp:Panel>
                            </div>
                            <div class="row">
                                <asp:Panel ID="pnlInfo" runat="server" Visible="false">
                                    <div class="col-lg-10">
                                        <div id="divPnlInfo" class="alert alert-dismissable alert-info">
                                            <button type="button" class="close" data-dismiss="alert">&times;</button>
                                            <strong>Aviso</strong> <asp:Label ID="lblInfoMsg" runat="server" Text=""></asp:Label></span>
                                        </div>
                                    </div>
                                </asp:Panel>
                            </div>
                            <div class="panel-footer">
                                <p>2017  -  direitos reservados.</p>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-4"></div>
                </div>
            </div>
        </div>
        <div class="col-md-4"></div>

    </form>
</body>

</html>
