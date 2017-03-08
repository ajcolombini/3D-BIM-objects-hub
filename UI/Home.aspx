<%@ Page Title="" Language="C#" MasterPageFile="~/HUB.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="UI.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row">
        <div class="col-lg-12">
            <h1>Painel Controle <small>Administração</small></h1>
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
        <div class="col-lg-3">
            <div class="panel panel-primary">
                <div class="panel-heading">
                    <h3 class="panel-title"><i class="fa fa-clock-o"></i>Alerts</h3>
                </div>
                <div class="panel-body">
                    <div class="row alert-success">
                        <div class="col-xs-5">
                            <i class="fa fa-thumbs-o-up fa-5x"></i>
                        </div>
                        <div class="col-xs-5 text-right">
                            <p class="alerts-heading">343</p>
                            <p class="alerts-text">New Orders</p>
                        </div>
                    </div>
                    <div class="row alert-success">
                        <div class="col-xs-5">
                            <i class="fa fa-thumbs-o-up fa-5x"></i>
                        </div>
                        <div class="col-xs-5 text-right">
                            <p class="alerts-heading">1256</p>
                            <p class="alerts-text">Registrations</p>
                        </div>
                    </div>
                    <div class="row alert-danger">
                        <div class="col-xs-5">
                            <i class="fa fa-thumbs-o-down fa-5x"></i>
                        </div>
                        <div class="col-xs-5 text-right">
                            <p class="alerts-heading">4</p>
                            <p class="alerts-text">Errors</p>
                        </div>
                    </div>
                    <div class="row alert-success">
                        <div class="col-xs-5">
                            <i class="fa fa-thumbs-o-up fa-5x"></i>
                        </div>
                        <div class="col-xs-5 text-right">
                            <p class="alerts-heading">11</p>
                            <p class="alerts-text">Mentions</p>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="col-lg-9">
            <div class="panel panel-primary">
                <div class="panel-heading">
                    <h3 class="panel-title"><i class="fa fa-bar-chart-o"></i>Traffic Estimations for last 30 days</h3>
                </div>
                <div class="panel-body">
                    <div id="shieldui-chart1"></div>
                </div>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-lg-4">
            <div class="panel panel-primary">
                <div class="panel-heading">
                    <h3 class="panel-title"><i class="fa fa-bar-chart-o"></i>Logins per week</h3>
                </div>
                <div class="panel-body">
                    <div id="shieldui-chart2"></div>
                </div>
            </div>
        </div>
        <div class="col-lg-4">
            <div class="panel panel-primary">
                <div class="panel-heading">
                    <h3 class="panel-title"><i class="fa fa-bar-chart-o"></i>Budget</h3>
                </div>
                <div class="panel-body">
                    <div id="shieldui-chart3"></div>
                </div>
            </div>
        </div>
        <div class="col-lg-4">
            <div class="panel panel-primary">
                <div class="panel-heading">
                    <h3 class="panel-title"><i class="fa fa-bar-chart-o"></i>Purchases</h3>
                </div>
                <div class="panel-body">
                    <div id="shieldui-chart4"></div>
                </div>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-lg-12">
            <div class="panel panel-primary">
                <div class="panel-heading">
                    <h3 class="panel-title"><i class="fa fa-bar-chart-o"></i>Sales personnel Data</h3>
                </div>
                <div class="panel-body">
                    <div id="shieldui-grid1"></div>
                </div>
            </div>
        </div>
    </div>
    <!-- /.row -->

</asp:Content>
