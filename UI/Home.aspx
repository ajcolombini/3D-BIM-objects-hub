<%@ Page Title="" Language="C#" MasterPageFile="~/HUB.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="UI.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row">
        <div class="col-lg-12">
            <h3>Buscar </h3>
            <div class="alert alert-success alert-dismissable">
                <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
                Bem-vindo ao BIM Hubb. 
                 <br />
                Faça sua busca por código de modelo, nome do modelo ou fabricante...
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-lg-12">
            <div class="input-group input-group-lg">
                <asp:TextBox ID="txtBusca" cssClass="form-control" type="text" placeholder="Fabricante, Modelo, Código ..." runat="server"></asp:TextBox>
                <span class="input-group-btn">
                    <asp:Button ID="btnBuscar" cssClass="btn btn-primary" runat="server"  Text="Buscar" />
                </span>
            </div>
            <!-- /input-group -->
        </div>
    </div>
    <br/>
    <!-- /.row -->
    <div class="row">
        <div class="col-lg-12">
            <div class="panel panel-primary">
                <div class="panel-heading">
                    <h3 class="panel-title"><i class="fa fa-bar-chart-o"></i>Resultados</h3>
                </div>
                <div class="panel-body">
                    <!-- Table -->
                    <asp:GridView ID="gvwResults" runat="server" class="table table-responsive"></asp:GridView>
                </div>
            </div>
        </div>
    </div>
    <!-- /.row -->

</asp:Content>
