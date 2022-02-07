<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomerForm.aspx.cs" Inherits="MyProject.WebForm.Customer" UnobtrusiveValidationMode="None" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<link href="../../Content/bootstrap.css" rel="stylesheet" />
<head runat="server">
    <title>Customers form</title>
    <style>
        .btnspremi{
            float:right;
        }
    </style>
</head>
<body>
    <h1 style="text-align:center;">Edit customer</h1>
    <form id="form1" runat="server">
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

            <div class="container" style="width:50%;">
                <div class="form-group" style="margin-top:25px;">
                    <asp:Label ID="lblIme" Text="Ime" runat="server"></asp:Label>
                    <asp:TextBox ID="txtIme" CssClass="form-control" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ControlToValidate="txtIme" ID="rfvIme" runat="server" ErrorMessage="Ime je obavezno!" SetFocusOnError="True" ForeColor="Red"></asp:RequiredFieldValidator>
                </div>
                <div class="form-group">
                    <asp:Label ID="lblPrezime" Text="Prezime" runat="server"></asp:Label>
                    <asp:TextBox ID="txtPrezime" CssClass="form-control" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ControlToValidate="txtPrezime" ID="rfvPrezime" runat="server" ErrorMessage="Prezime je obavezno!" SetFocusOnError="True" ForeColor="Red"></asp:RequiredFieldValidator>
                </div>
                <div class="form-group">
                    <asp:Label ID="lblEmail" Text="E-mail" runat="server"></asp:Label>
                    <asp:TextBox ID="txtEmail" CssClass="form-control" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ControlToValidate="txtEmail" ID="rfvEmail" runat="server" ErrorMessage="E-mail je obavezan podatak!" SetFocusOnError="True" ForeColor="Red"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="revEmail" runat="server" ErrorMessage="Unesite ispravnu e-mail adresu!" ControlToValidate="txtEmail" SetFocusOnError="True" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ForeColor="Red"></asp:RegularExpressionValidator>
                </div>
                <div class="form-group">
                    <asp:Label ID="lblTelefon" Text="Broj telefona" runat="server"></asp:Label>
                    <asp:TextBox ID="txtTelefon" CssClass="form-control" runat="server"></asp:TextBox>
                </div><asp:RequiredFieldValidator ControlToValidate="txtTelefon" ID="rfvTelefon" runat="server" ErrorMessage="Broj telefona je obavezan podatak!" SetFocusOnError="True" ForeColor="Red"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="revTelefon" runat="server" ControlToValidate="txtTelefon" ErrorMessage="format broja telefona: 000-000-0000" ValidationExpression="^\d{3}-\d{3}-\d{4}$" ForeColor="Red"></asp:RegularExpressionValidator>
                <asp:UpdatePanel ID="upSetSession" runat="server">
                    <ContentTemplate>
                    
                        <div class="form-group">
                            <asp:Label ID="lblDrzava" Text="Drzava" runat="server"></asp:Label>
                            <asp:DropDownList ID="ddlDrzave" AutoPostBack="true"  OnSelectedIndexChanged="ddlDrzave_SelectedIndexChanged" CssClass="form-control" runat="server"></asp:DropDownList>
                            <asp:RequiredFieldValidator ControlToValidate="ddlDrzave" ID="rfvDrzava" runat="server" ErrorMessage="Država je obavezan podatak!" SetFocusOnError="True" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                    

                        <div class="form-group">
                            <asp:Label ID="lblGrad" Text="Grad" runat="server"></asp:Label>
                            <asp:DropDownList ID="ddlGradovi" CssClass="form-control" runat="server"></asp:DropDownList>
                            <asp:RequiredFieldValidator ControlToValidate="ddlGradovi" ID="rfvGradovi" runat="server" ErrorMessage="Grad je obavezan podatak!" SetFocusOnError="True" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="ddlDrzave" 
                        EventName="SelectedIndexChanged" />
                    </Triggers>
                </asp:UpdatePanel>
                
                <asp:button id="backButton" CssClass="btn btn-danger" runat="server" text="Cancel" OnClientClick="JavaScript:window.history.back(1);return false;"></asp:button>
                <asp:Button ID="btnSpremi" CssClass="btn btn-primary btnspremi" runat="server" Text="Save" OnClick="btrnSpremi_Click"/>
            </div>
    </form>
</body>
</html>