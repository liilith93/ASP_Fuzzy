<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="Fuzzy.About" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <hgroup class="title">
        <h1><%: Title %></h1>
        <h2>Trochę o projekcie.</h2>
    </hgroup>

    <article>
        <p>        
            Aplikacja ta została zrealizowana w ramach pracy magisterskiej studentki Politechniki Śląskiej.<br /> 
            Tematyka pracy obejmowała ocenę ryzyka zachorowania na choroby serca, w tym celu został wykorzystany system rozmyty, 
            którego wejścia oraz reguły zostały dobrane po dokładnej analizie literatury.<br />
<%--            Dodatkową funkcjonalnością udostępnioną użytkownikowi jest możliwość prowadzenia historii, dzięki czemu możliwe jest 
            śledzenie istotnych czynników ryzykahhhhhhhh.--%>
        </p>

<%--        <p>        
            Aplikacja osiągnęła % dokładności na testowej bazie danych. Zainteresowany?<br />
            <a class="btn btn-lg btn-link" href="~/Register" role="button">Zarejestruj się &raquo;</a>
        </p>

        <p>
            Masz już konto?<br />
            <a class="btn btn-lg btn-link" href="~/Login" role="button">Zaloguj się &raquo;</a>
        </p>--%>
    </article>

    <aside>
        <ul>
            <li><a runat="server" href="~/">Strona główna</a></li>
            <li><a runat="server" href="~/Form">Formularz</a></li>
            <li><a runat="server" href="~/Contact">Skontaktuj się z nami</a></li>
        </ul>
    </aside>
</asp:Content>