<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Front Page.aspx.cs" Inherits="Instance_Web.Pages.FrontPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Instance</title>
    <link href="../Content/bootstrap.min.css" rel="stylesheet">
    <link href="../Content/theme.css" rel="stylesheet">
    <style>
        
        </style>
</head>
<div style="text-align: center;">
    <script src="../Scripts/bootstrap.js"></script>
    <form id="form1" runat="server" style="align-content: center">
        <br/>
        <br/>
        <br/>
        Instance - Registration site.<br/>
        <br/>
        Please enter a username and password:<br/>
        <br/>
        <div>Username:</div><asp:TextBox class="" ID="username" runat="server"></asp:TextBox>
        <br/>
        <div style="height: 2px"></div>

        <div>Password:</div> 
        <asp:TextBox ID="password" runat="server" TextMode="Password"></asp:TextBox>
        <br/>
        <br/>
        <asp:Button ID="create_account" OnClick="create_account_Click" runat="server" Text="Create account" BackColor="#BE1707" ForeColor="#FFFFFF"/>
    </form>
</div>
</html>