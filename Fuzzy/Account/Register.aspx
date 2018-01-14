<%@ Page Title="Zarejestruj się" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Fuzzy.Account.Register" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <hgroup class="title">
        <h1><%: Title %>.</h1>
        <h2>Wprowadź poniżej dane, aby się zarejestrować.</h2>
    </hgroup>

    <asp:CreateUserWizard runat="server" ID="RegisterUser" ViewStateMode="Disabled" OnCreatedUser="RegisterUser_CreatedUser">
        <LayoutTemplate>
            <asp:PlaceHolder runat="server" ID="wizardStepPlaceholder" />
            <asp:PlaceHolder runat="server" ID="navigationPlaceholder" />
        </LayoutTemplate>
        <WizardSteps>
            <asp:CreateUserWizardStep runat="server" ID="RegisterUserWizardStep">
                <ContentTemplate>
                    <p class="message-info">
                        Hasło musi być złożone z <%: Membership.MinRequiredPasswordLength %> znaków.
                    </p>

                    <p class="validation-summary-errors">
                        <asp:Literal runat="server" ID="ErrorMessage" />
                    </p>

                    <fieldset>
                        <legend>Registration Form</legend>
                        <ol>
                            <li>
                                <asp:Label runat="server" AssociatedControlID="UserName">Login</asp:Label>
                                <asp:TextBox runat="server" ID="UserName" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="UserName"
                                    CssClass="field-validation-error" ErrorMessage="Pole jest wymagane." />
                            </li>
                            <li>
                                <asp:Label runat="server" AssociatedControlID="Name">Imię</asp:Label>
                                <asp:TextBox runat="server" ID="Name" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="Name"
                                    CssClass="field-validation-error" ErrorMessage="Pole jest wymagane." />
                            </li>
                            <li>
                                <asp:Label runat="server" AssociatedControlID="Surname">Nazwisko</asp:Label>
                                <asp:TextBox runat="server" ID="Surname" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="Name"
                                    CssClass="field-validation-error" ErrorMessage="Pole jest wymagane." />
                            </li>
                            <li>
                                <asp:Label runat="server" AssociatedControlID="Email">Email </asp:Label>
                                <asp:TextBox runat="server" ID="Email" TextMode="Email" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="Email"
                                    CssClass="field-validation-error" ErrorMessage="Pole jest wymagane." />
                            </li>
                            <li>
                                <asp:Label runat="server" AssociatedControlID="Password">Hasło</asp:Label>
                                <asp:TextBox runat="server" ID="Password" TextMode="Password" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="Password"
                                    CssClass="field-validation-error" ErrorMessage="Pole jest wymagane." />
                            </li>
                            <li>
                                <asp:Label runat="server" AssociatedControlID="ConfirmPassword">Potwierdź hasło</asp:Label>
                                <asp:TextBox runat="server" ID="ConfirmPassword" TextMode="Password" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="ConfirmPassword"
                                     CssClass="field-validation-error" Display="Dynamic" ErrorMessage="Pole jest wymagane." />
                                <asp:CompareValidator runat="server" ControlToCompare="Password" ControlToValidate="ConfirmPassword"
                                     CssClass="field-validation-error" Display="Dynamic" ErrorMessage="Hasła nie zgadzają się." />
                            </li>
                        </ol>
                        <asp:Button runat="server" CommandName="MoveNext" Text="Zarejestruj" />
                    </fieldset>
                </ContentTemplate>
                <CustomNavigationTemplate />
            </asp:CreateUserWizardStep>
        </WizardSteps>
    </asp:CreateUserWizard>
</asp:Content>