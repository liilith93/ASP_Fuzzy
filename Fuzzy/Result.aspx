<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Result.aspx.cs" Inherits="Fuzzy.Result" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        <b>
            <asp:Label ID="txtName" runat="server" Text=""></asp:Label></b><br /><br />
        Ryzyko zachorowania w Twoim przypadku wynosi:
        <asp:Label ID="resultTxt" runat="server"></asp:Label>
    </h2>
    <br />
    <h3>
        <asp:Label ID="recomendationTxt" runat="server"></asp:Label>
    </h3>
    <h2>
        <asp:Label ID="txtRisks" runat="server"></asp:Label></h2>
    <br />
    <asp:BulletedList ID="riskList" runat="server" BulletStyle="Circle" Font-Bold="True" Font-Size="Large"></asp:BulletedList>
    <br />
    <h3>
        <asp:Label ID="addRisktxt" runat="server"></asp:Label>
    </h3>
   
</asp:Content>
