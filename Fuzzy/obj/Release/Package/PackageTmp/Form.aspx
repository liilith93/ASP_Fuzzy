<%@ Page Title="Formularz" EnableEventValidation="false" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Form.aspx.cs" Inherits="MGR_site.Form" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <body>
        <div class="container">
            <h2><%: Title %>.</h2>
            <h3>Sprawdź ryzyko zachorowania na zawał serca.</h3>
            <br />
            <h3>Wprowadź swoje dane</h3>
            <br />
            <form>
                <div class="form-group">
                    <label class="control-label col-sm-2" for="Name">Imię (opcjonalnie):</label>
                    <div class="col-sm-6">
                        <input type="text" class="form-control" id="Name" name="Name">
                    </div>
                </div>
                <br />
                <br />
                <div class="form-group">
                    <label class="control-label col-sm-2" for="Surname">Nazwisko (opcjonalnie):</label>
                    <div class="col-sm-6">
                        <input type="text" class="form-control" id="Surname" name="Surname">
                    </div>
                </div>
                <br />
                <br />
                <div class="form-group">
                    <label class="control-label col-sm-2" for="Sex">Płeć:</label>
                    <label class="Form-label--tick">
                        <input type="radio" value="0" name="Sex" class="Form-label-radio" checked>
                        <span class="Form-label-text">Kobieta</span>
                    </label>
                    <label class="Form-label--tick">
                        <input type="radio" value="1" name="Sex" class="Form-label-radio">
                        <span class="Form-label-text">Mężczyzna</span>
                    </label>
                </div>
                <br />
                <div class="form-group">
                    <label class="control-label col-sm-2" for="Age">Wiek:</label>
                    <div class="col-sm-6">
                        <input type="number" class="form-control" id="Age" name="Age" onkeypress="return isNumber(event)" min="0">
                    </div>
                </div>
                <br />
                <br />
                <div class="form-group">
                    <label class="control-label col-sm-2" for="Pain">Opisz odczuwany ból:</label>
                    <div class="btn-group">
                        <label class="Form-label--tick">
                            <input type="checkbox" value="0" name="Pain" class="Form-label-checkbox" checked>
                            <span class="Form-label-text">Nie czuję bólu</span>
                        </label>
                        <br />
                        <label class="Form-label--tick">
                            <input type="checkbox" value="1" name="Pain" class="Form-label-checkbox">
                            <span class="Form-label-text">Ból jest zlokalizowany za mostkiem i promieniuje do szyi oraz żuchwy</span>
                        </label>
                        <br />
                        <label class="Form-label--tick">
                            <input type="checkbox" value="1" name="Pain" class="Form-label-checkbox">
                            <span class="Form-label-text">Ból wywołany jest wysiłkiem fizycznym lub stresem</span>
                        </label>
                        <br />
                        <label class="Form-label--tick">
                            <input type="checkbox" value="1" name="Pain" class="Form-label-checkbox">
                            <span class="Form-label-text">Ból ustepuje po odpoczynku</span>
                        </label>
                    </div>
                </div>
                <br />
                <div class="form-group">
                    <label class="control-label col-sm-2" for="BPress">Wartość ciśnienia skurczowego:</label>
                    <div class="col-sm-6">
                        <input type="number" class="form-control" id="BPress" name="BPress" onkeypress="return isNumber(event)" min="90">
                    </div>
                </div>
                <br />
                <br />
                <div class="form-group">
                    <label class="control-label col-sm-2" for="Cholesterol">Całkowita wartość cholesterolu [w mg/dl]:</label>
                    <div class="col-sm-6">
                        <input type="number" class="form-control" id="Cholesterol" name="Cholesterol" onkeypress="return isNumber(event)" min="0">
                    </div>
                </div>
                <br />
                <br />
                <br />
                <br />
                <div class="form-group">
                    <label class="control-label col-sm-2" for="Smoker">Czy jesteś palaczem:</label>
                    <label class="Form-label--tick">
                        <input type="radio" value="0" name="Smoker" class="Form-label-radio" onclick="changeState('CigPerWeek', false)" checked>
                        <span class="Form-label-text">Tak</span>
                    </label>
                    <label class="Form-label--tick">
                        <input type="radio" value="1" name="Smoker" class="Form-label-radio" onclick="changeState('CigPerWeek', true)">
                        <span class="Form-label-text">Nie</span>
                    </label>
                </div>
                <br />
                <div class="form-group">
                    <label class="control-label col-sm-2" for="CigPerWeek">Ile średnio papierosów wypalasz w tygodniu:</label>
                    <div class="col-sm-6">
                        <input type="number" class="form-control" id="CigPerWeek" min="0" name="CigPerWeek" onkeypress="return isNumber(event)">
                    </div>
                </div>
                <br />
                <br />
                <br />
                <br />
                <div class="form-group">
                    <label class="control-label col-sm-2" for="Sugar">Wartość cukru we krwi [w mg/dl]:</label>
                    <div class="col-sm-6">
                        <input type="number" class="form-control" id="Sugar" min="0" name="Sugar" onkeypress="return isNumber(event)">
                    </div>
                </div>
                <br />
                <br />
                <div class="form-group">
                    <label class="control-label col-sm-2" for="SugarFam">Czy w Twojej najbliższej rodzinie występowała cukrzyca:</label>
                    <label class="Form-label--tick">
                        <input type="radio" value="1" name="SugarFam" class="Form-label-radio">
                        <span class="Form-label-text">Tak</span>
                    </label>
                    <label class="Form-label--tick">
                        <input type="radio" value="0" name="SugarFam" class="Form-label-radio" checked>
                        <span class="Form-label-text">Nie</span>
                    </label>
                </div>
                <br />
                <br />
                <br />
                <div class="form-group">
                    <label class="control-label col-sm-2" for="restEKG">Wynik EKG spoczynkowego:</label>
                    <label class="Form-label--tick">
                        <input type="radio" value="0" name="restEKG" class="Form-label-radio" checked> 
                        <span class="Form-label-text">Wynik prawidłowy/Brak danych</span>
                    </label>
                    <br />
                    <label class="Form-label--tick">
                        <input type="radio" value="1" name="restEKG" class="Form-label-radio">
                        <span class="Form-label-text">Obecność ujemnego załamka T</span>
                    </label>
                    <label class="Form-label--tick">
                        <input type="radio" value="2" name="restEKG" class="Form-label-radio">
                        <span class="Form-label-text">Kadiomiopatia przerostowa</span>
                    </label>
                </div>
                <%--<br />
                <br />
                <div class="form-group">
                    <label class="control-label col-sm-2" for="MaxHR">Wartość tętna po wysiłku:</label>
                    <div class="col-sm-6">
                        <input type="number" class="form-control" min="100" id="MaxHR" name="MaxHR" onkeypress="return isNumber(event)">
                    </div>
                </div>--%>
                <br />
                <br />
                <div class="form-group">
                    <label class="control-label col-sm-2" for="RestHR">Wartość tętna w spoczynku:</label>
                    <div class="col-sm-6">
                        <input type="number" class="form-control" id="RestHR" min="40" name="RestHR" onkeypress="return isNumber(event)">
                    </div>
                </div>
                <br />
                <br />
                <div class="form-group">
                    <label class="control-label col-sm-2" for="Fat">Objętość w pasie [w cm]:</label>
                    <div class="col-sm-6">
                        <input type="number" class="form-control" id="Fat" min="0" name="Fat" onkeypress="return isNumber(event)">
                    </div>
                </div>
                <br />
                <br />
                <div class="form-group">
                    <label class="control-label col-sm-2" for="Kidney">Czy chorujesz na przewlekłą chorobę nerek:</label>
                    <label class="Form-label--tick">
                        <input type="radio" value="1" name="Kidney" class="Form-label-radio">
                        <span class="Form-label-text">Tak</span>
                    </label>
                    <label class="Form-label--tick">
                        <input type="radio" value="0" name="Kidney" class="Form-label-radio" checked>
                        <span class="Form-label-text">Nie</span>
                    </label>
                </div>
                <br />
                <br />
                <div>
                    <asp:Button ID="Accept" runat="server" Text="Zatwierdź" CssClass="btn btn-default" OnClick="Accept_Click" />
                    <asp:Button ID="auto" runat="server" Text="Autouzupełnianie" CssClass="btn btn-default" OnClick="Autofill_Click" />
                </div>
            </form>
        </div>
    </body>
</asp:Content>
