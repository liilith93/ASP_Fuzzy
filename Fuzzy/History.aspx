<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="History.aspx.cs" Inherits="Fuzzy.History" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    
    <asp:EntityDataSource ID="EntityDataSource1" runat="server" 
         
        ConnectionString="name=heartbaseEntities"
        DefaultContainerName="heartbaseEntities" 
        EnableFlattening="False"
        AutoPage="False" 
        >
    </asp:EntityDataSource>
    <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4">
        <FooterStyle BackColor="#99CCCC" ForeColor="#003399" BorderColor="Black" />
        <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" BorderColor="Black" />
        <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" BorderColor="Black" />
        <RowStyle BackColor="White" ForeColor="#003399" BorderColor="Black" />
        <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
        <SortedAscendingCellStyle BackColor="#EDF6F6" />
        <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
        <SortedDescendingCellStyle BackColor="#D6DFDF" />
        <SortedDescendingHeaderStyle BackColor="#002876" />
    </asp:GridView>
</asp:Content>
