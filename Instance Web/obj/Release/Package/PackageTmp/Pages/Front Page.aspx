<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Front Page.aspx.cs" Inherits="Instance_Web.Pages.FrontPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Instance</title>
</head>
<div style="text-align: center;">
    <form id="form1" runat="server" style="align-content: center">
        <br/>
        <br/>
        <br/>
        Instance - Registration site.<br/>
        <br/>
        Please enter a username and password:<br/>
        <br/>
        Username:<asp:TextBox ID="username" runat="server"></asp:TextBox>
        <br/>
        <div style="height: 2px"></div>

        Password: <asp:TextBox ID="password" runat="server" TextMode="Password"></asp:TextBox>
        <br/>
        <br/>
        <asp:Button runat="server" Text="Create account" ID="create_account" Height="26px" OnClick="create_account_Click"/>

    </form>
</div>
</html>