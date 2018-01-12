<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Fuzzy._Default" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <!-- Main component for a primary marketing message or call to action -->
    <div class="jumbotron">
        <h1>Witaj w HeartHelp!</h1>
        <p>
            Celem niniejszej aplikacji internetowej jest wspomaganie oceny ryzyka zachorowania na choroby serca.<br />
            Nie czekaj! Wypełnij krótką ankietę i sprawdź czy jesteś w grupie ryzyka!

        </p>
        <p>
            <a class="btn btn-lg btn-primary" href="/Form" role="button">Wypełnij formularz &raquo;</a>
        </p>
    </div>
</asp:Content>
