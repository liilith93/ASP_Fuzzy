<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="History.aspx.cs" Inherits="Fuzzy.History" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    <asp:EntityDataSource ID="EntityDataSource1" runat="server" ConnectionString="name=heartbaseEntities" DefaultContainerName="heartbaseEntities" EnableFlattening="False" EntitySetName="Users_results" AutoPage="False" EnableDelete="True" EnableInsert="True" EnableUpdate="True" Where="" EntityTypeFilter="" Select="">
    </asp:EntityDataSource>
    <asp:GridView ID="GridView1" runat="server"></asp:GridView>
</asp:Content>
