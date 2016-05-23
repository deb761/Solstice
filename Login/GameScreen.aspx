<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GameScreen.aspx.cs" Inherits="Solstice.GameScreen" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Solstice Math Game</title>
    <style>
        #form1 {
            border: thick black solid;
            margin-left: 5%;
            padding-left: 5%;
            width: 55%;
        }
        #txtStudentInput {
            border: thick black solid;
            color: #E52B14;
            font-size: 100pt;
            font-family: "Gill Sans", "Gill Sans MT", Calibri, "Trebuchet MS", sans-serif;
            width: 150px;
            height: 200px;
            text-align: center;
            margin-bottom: 50px;
        }
        .btnPopups {
            border: thick #2F407F solid;
            background: #1793BF;
            color: #2F407F;
            font-family: "Gill Sans", "Gill Sans MT", Calibri, "Trebuchet MS", sans-serif;
            font-size: xx-large;
            font-style: normal;
            font-weight: bold;
        }
        #lblOpSign {
            color: #1793BF;
            font-size: 88pt;
            font-weight: bold;
            padding-bottom: 25px;
        }
        #lblScreenTitle {
            color: #2F407F;
            font-size: 88pt;
            text-align: center;
        }
        .lblNums {
            color: #9BFF3A;
            font-size: 100pt;
        }
        #btnSubmit {
            border: thick #431929 solid;
            background: #E52B14;
            color: #431929;
            font-family: "Gill Sans", "Gill Sans MT", Calibri, "Trebuchet MS", sans-serif;
            font-size: xx-large;
            font-style: normal;
            font-weight: bold;
            margin-left: 25%;
        }
        #imgCookie {
            width: 60%;
            height: 60%;
        }
        #expression {
            margin-left: 10%;
        }
        #btnLogoff {
            margin-left: 22%;
        }
        .pnlPopups {
            margin-left: 10%;
        }
        #lblAnswerResult {
            font-size: 64pt;
        }
        .correct {
            color: #9BFF3A;
        }
        .incorrect {
            color: #E52B14;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div id="pageTitle">
        <h2><asp:Label runat="server" ID="lblScreenTitle" Text="Addition"/></h2> 
        <asp:Label runat="server" ID="lblProbIdx" Visible="false" />  
        <asp:Label runat="server" ID="lblGameOver" Visible="false" />
    </div>
    <div id="main">
        <asp:Panel CssClass="pnlPopups" runat="server" ID="pnlWelcome" Visible="true" Height="50%" Width="75%">
            <asp:Label runat="server" ID="lblWelcomeName" /><br />
            <asp:Label runat="server" ID="lblLastTime" /><br />
            <asp:Label runat="server" ID="lblThisTime" /><br />
            <asp:Button runat="server" CssClass="btnPopups" ID="btnReady" Text="Ready!" OnClick="btnReady_Click" />
        </asp:Panel>
        <asp:Panel CssClass="pnlPopups" runat="server" ID="pnlResults" Visible="false" Height="50%" Width="75%">
            <asp:Label runat="server" ID="lblAnswerResult" /><br />
            <asp:Image runat="server" ID="imgCookie" /><br />
            <asp:Button runat="server" CssClass="btnPopups" ID="btnContinue" Text="Continue" OnClick="btnContinue_Click" />
        </asp:Panel>
        <asp:Panel runat="server" ID="pnlGame" Visible="false" Height="50%" Width="75%">
        <span id="expression">
            <asp:Label runat="server" CssClass="lblNums" ID="lblOrd1" Text="2" />
            <asp:Label runat="server" ID="lblOpSign" Text="+"/>
            <asp:Label runat="server" CssClass="lblNums" ID="lblOrd2" Text="2" />
        </span>
        <asp:TextBox runat="server" ID="txtStudentInput" MaxLength="3" /><br />
        <asp:Button runat="server" ID="btnSubmit" Text="Submit" OnClick="btnSubmit_Click" />
        </asp:Panel>
        <asp:Panel runat="server" ID="pnlFinal" Visible="false" Height="50%" Width="75%">
            <asp:Label runat="server" ID="lblRight" /><br />
            <asp:Label runat="server" ID="lblWrong" />
        </asp:Panel>
    </div>
    <asp:Button runat="server" ID="btnLogoff" Text="Logoff" OnClick="btnLogoff_Click" />
    </form>
</body>
</html>
