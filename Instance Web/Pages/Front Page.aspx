<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Front Page.aspx.cs" Inherits="Instance_Web.Pages.FrontPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Instance</title>
</head>
<center>
    <form id="form1" runat="server">
        <br />
        <br />
        <br />
        Instance - Registration site.<br />
        <br />
        Please enter a username and password:<br />
        <br />
        <div style="height: 481px; width: 1058px">
    
            Username:<asp:TextBox ID="username" runat="server"></asp:TextBox>
            <br/>
            Password: <asp:TextBox ID="password" runat="server" TextMode="Password"></asp:TextBox>
            <br />
            <br />
            <asp:Button runat="server" Text="Create account" ID="create_account" Height="26px" OnClick="create_account_Click"></asp:Button>
    </div>
    </form>
</center>
</html>