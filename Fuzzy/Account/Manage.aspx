<%@ Page Title="Manage Account" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="Fuzzy.Account.Manage" %>
 <%@ Register Src="~/Account/OpenAuthProviders.ascx" TagPrefix="uc" TagName="OpenAuthProviders" %> 

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <hgroup class="title">
        <h1><%: Title %>.</h1>
    </hgroup>
  
    <section id="passwordForm">
        <asp:PlaceHolder runat="server" ID="successMessage" Visible="false" ViewStateMode="Disabled">
            <p class="message-success"><%: SuccessMessage %></p>
        </asp:PlaceHolder>

        <p>Zalogowano jako <strong><%: User.Identity.Name %></strong>.</p>

       
      
        <asp:PlaceHolder runat="server" ID="changePassword" Visible="false">
            <h3>Zmień hasło </h3>
            <asp:ChangePassword runat="server" CancelDestinationPageUrl="~/" ViewStateMode="Disabled" RenderOuterTable="false" SuccessPageUrl="Manage?m=ChangePwdSuccess">
                <ChangePasswordTemplate>
                    <p class="validation-summary-errors">
                        <asp:Literal runat="server" ID="FailureText" />
                    </p>
                    <fieldset class="changePassword">
                        <legend>Zmień hasło</legend>
                        <ol>
                            <li>
                                <asp:Label runat="server" ID="CurrentPasswordLabel" AssociatedControlID="CurrentPassword">Obecne hasło</asp:Label>
                                <asp:TextBox runat="server" ID="CurrentPassword" CssClass="passwordEntry" TextMode="Password" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="CurrentPassword"
                                    CssClass="field-validation-error" ErrorMessage="Obecne hasło jest wymagane."
                                    ValidationGroup="ChangePassword" />
                            </li>
                            <li>
                                <asp:Label runat="server" ID="NewPasswordLabel" AssociatedControlID="NewPassword">Nowe hasło</asp:Label>
                                <asp:TextBox runat="server" ID="NewPassword" CssClass="passwordEntry" TextMode="Password" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="NewPassword"
                                    CssClass="field-validation-error" ErrorMessage="Nowe hasło jest wymagane."
                                    ValidationGroup="ChangePassword" />
                            </li>
                            <li>
                                <asp:Label runat="server" ID="ConfirmNewPasswordLabel" AssociatedControlID="ConfirmNewPassword">Potwierdź nowe hasło</asp:Label>
                                <asp:TextBox runat="server" ID="ConfirmNewPassword" CssClass="passwordEntry" TextMode="Password" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="ConfirmNewPassword"
                                    CssClass="field-validation-error" Display="Dynamic" ErrorMessage="Nowe hasło jest wymagane."
                                    ValidationGroup="ChangePassword" />
                                <asp:CompareValidator runat="server" ControlToCompare="NewPassword" ControlToValidate="ConfirmNewPassword"
                                    CssClass="field-validation-error" Display="Dynamic" ErrorMessage="Nowe hasło i potwierdzone nie są zgodne"
                                    ValidationGroup="ChangePassword" />
                            </li>
                        </ol>
                        <asp:Button runat="server" CommandName="ChangePassword" Text="Change password" ValidationGroup="ChangePassword" />
                    </fieldset>
                </ChangePasswordTemplate>
            </asp:ChangePassword>
        </asp:PlaceHolder>
    </section>

     <p>Twoje wyniki:</p>

     <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" CellPadding="4" CellSpacing="5" Height="20px">
        <FooterStyle BackColor="#99CCCC" ForeColor="#003399" BorderColor="Black" BorderWidth="1" BorderStyle="Solid"/>
        <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" BorderColor="Black" BorderWidth="1" BorderStyle="Solid"/>
        <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" BorderColor="Black" BorderStyle="Solid" />
        <RowStyle BackColor="White" ForeColor="#003399" BorderColor="Black" BorderWidth="1" BorderStyle="Solid" />
        <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" BorderWidth="1" BorderStyle="Solid" />
        <SortedAscendingCellStyle BackColor="#EDF6F6" BorderWidth="1" BorderColor="Black" BorderStyle="Solid" />
        <SortedAscendingHeaderStyle BackColor="#0D4AC4"  BorderColor="Black" BorderStyle="Solid" />
        <SortedDescendingCellStyle BackColor="#D6DFDF"  BorderColor="Black" BorderStyle="Solid" />
        <SortedDescendingHeaderStyle BackColor="#002876"  BorderColor="Black" BorderStyle="Solid" />
    </asp:GridView>

   <%-- <asp:LinqDataSource 
    ContextTypeName="heartbaseEntities" 
    TableName="Users" 
    EnableUpdate="true"
    EnableInsert="true"
    EnableDelete="true"
    ID="EntityDataSource" 
    runat="server">
</asp:LinqDataSource>
<asp:DetailsView 
    DataKeyNames="ID"
    AutoGenerateEditButton="true"
    AutoGenerateDeleteButton="true"
    AutoGenerateInsertButton="true"
    AllowPaging="true"
    DataSourceID="EntityDataSource"
    ID="GridView1" 
    runat="server">
</asp:DetailsView>--%>

    <!--
    <section id="externalLoginsForm">
        
        <asp:ListView runat="server"
            ItemType="Microsoft.AspNet.Membership.OpenAuth.OpenAuthAccountData"
            SelectMethod="GetExternalLogins" DeleteMethod="RemoveExternalLogin" DataKeyNames="ProviderName,ProviderUserId">
        
            <LayoutTemplate>
                <h3>Registered external logins</h3>
                <table>
                    <thead><tr><th>Service</th><th>User Name</th><th>Last Used</th><th>&nbsp;</th></tr></thead>
                    <tbody>
                        <tr runat="server" id="itemPlaceholder"></tr>
                    </tbody>
                </table>
            </LayoutTemplate>
            <ItemTemplate>
                <tr>
                    
                    <td><%#: Item.ProviderDisplayName %></td>
                    <td><%#: Item.ProviderUserName %></td>
                    <td><%#: ConvertToDisplayDateTime(Item.LastUsedUtc) %></td>
                    <td>
                        <asp:Button runat="server" Text="Remove" CommandName="Delete" CausesValidation="false" 
                            ToolTip='<%# "Remove this " + Item.ProviderDisplayName + " login from your account" %>'
                            Visible="<%# CanRemoveExternalLogins %>" />
                    </td>
                    
                </tr>
            </ItemTemplate>
        </asp:ListView>

        <h3>Add an external login</h3>
        <uc:OpenAuthProviders runat="server" ReturnUrl="~/Account/Manage" />
    </section>
    -->
    
</asp:Content>
