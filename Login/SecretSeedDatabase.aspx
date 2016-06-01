<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SecretSeedDatabase.aspx.cs" Inherits="SecretSeedDatabase" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <h1>Welcome, Super User!</h1>
        <asp:Button ID="btnSeed" runat="server" Text="Seed Database" OnClick="btnSeed_Click" />
    </div>
    </form>
</body>
</html>
