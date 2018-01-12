<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="Fuzzy.Contact" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <hgroup class="title">
        <h1><%: Title %></h1>
        <h2>Skontaktuj się z nami.</h2>
    </hgroup>

    <section class="contact">
        <header>
            <h3>Telefon:</h3>
        </header>
        <p>
            <span class="label">Komórkowy:</span>
            <span>555-666-777</span>
        </p>
    </section>

    <section class="contact">
        <header>
            <h3>Email:</h3>
        </header>
        <p>
            <span class="label">Wsparcie techniczne:</span>
            <span><a href="mailto:umoldysz.ib@gmail.com">umoldysz.ib@gmail.com</a></span>
        </p>
    </section>

    <section class="contact">
        <header>
            <h3>Adres:</h3>
        </header>
        <p>
            Politechnika Śląska<br />
            ul. Akademicka 2A<br />
            44-100 Gliwice
        </p>
    </section>
</asp:Content>