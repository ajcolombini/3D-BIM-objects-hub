<%@ Page Title="" Language="C#" MasterPageFile="~/HUB.Master" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="UI.Portfolio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" href="cdn.datatables.net/1.10.13/css/jquery.dataTables.min.css" />
    <script src="cdn.datatables.net/1.10.13/js/jquery.dataTables.min.js"></script>

     <div class="row">
        <div class="col-lg-12">
            <h1>Portfolio <small>Busque o que quiser!</small></h1>
            <%--<div class="alert alert-success alert-dismissable">
                <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
                Welcome to the admin dashboard! Feel free to review all pages and modify the layout to your needs. 
                        <br />
                This theme uses the <a href="https://www.shieldui.com">ShieldUI</a> JavaScript library for the 
                        additional data visualization and presentation functionality illustrated here.
            </div>--%>
        </div>
    </div>
    <div class="row">
        <div class="col-md-10 col-lg-10 col-sm10">
            <asp:GridView ID="gvwPortfolio" runat="server"></asp:GridView>
        </div>
    </div>
    <script>
        $(document).ready(function () {
            $('#<%=gvwPortfolio.ClientID%>').DataTable();
        });
    </script>
</asp:Content>
