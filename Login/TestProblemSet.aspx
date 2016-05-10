﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TestProblemSet.aspx.cs" Inherits="TestProblemSet" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Label ID="Label1" runat="server" Text="AddSubProblem"></asp:Label>
    <div>
    
    </div>
        <asp:ListBox ID="ListBox1" runat="server" DataSourceID="SqlDataSource1" DataTextField="AddSubProblemID" DataValueField="AddSubProblemID"></asp:ListBox>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:SolsticeAPI_dbConnectionString %>" SelectCommand="SELECT * FROM [AddSubProblems]"></asp:SqlDataSource>
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Test Problem Set" />
        <p>
            <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Button" />
            <asp:Label ID="Label2" runat="server" Text="Results"></asp:Label>
        </p>
        <asp:ListBox ID="ListBox2" runat="server" DataSourceID="SqlDataSource2" DataTextField="ResultID" DataValueField="ResultID"></asp:ListBox>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:SolsticeAPI_dbConnectionString %>" DeleteCommand="DELETE FROM [Results] WHERE [ResultID] = @ResultID" InsertCommand="INSERT INTO [Results] ([StudentID], [ProblemID], [Answer], [Level], [Round]) VALUES (@StudentID, @ProblemID, @Answer, @Level, @Round)" SelectCommand="SELECT * FROM [Results]" UpdateCommand="UPDATE [Results] SET [StudentID] = @StudentID, [ProblemID] = @ProblemID, [Answer] = @Answer, [Level] = @Level, [Round] = @Round WHERE [ResultID] = @ResultID">
            <DeleteParameters>
                <asp:Parameter Name="ResultID" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="StudentID" Type="Int32" />
                <asp:Parameter Name="ProblemID" Type="Int32" />
                <asp:Parameter Name="Answer" Type="Int32" />
                <asp:Parameter Name="Level" Type="Int32" />
                <asp:Parameter Name="Round" Type="Int32" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="StudentID" Type="Int32" />
                <asp:Parameter Name="ProblemID" Type="Int32" />
                <asp:Parameter Name="Answer" Type="Int32" />
                <asp:Parameter Name="Level" Type="Int32" />
                <asp:Parameter Name="Round" Type="Int32" />
                <asp:Parameter Name="ResultID" Type="Int32" />
            </UpdateParameters>
        </asp:SqlDataSource>
    </form>
</body>
</html>
