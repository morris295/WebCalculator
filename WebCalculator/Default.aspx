<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebCalculator.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:HiddenField ID="firstOperationField" runat="server" Value="true" />
        <asp:HiddenField ID="pendingValueField" runat="server" Value="" />
        <asp:HiddenField ID="pendingActionField" runat="server" Value="" />
        <table style="width: 100px;">
            <tr>
                <td colspan="4"><asp:TextBox ID="resultTextBox" runat="server" ReadOnly="true" Style="text-align: right" Width="200px" ></asp:TextBox></td>
            </tr>
            <tr>
                <td><asp:Button ID="clearErrorButton" runat="server" Text="CE" Width="40" /></td>
                <td><asp:Button ID="clearButton" runat="server" Text="C" Width="40" /></td>
                <td><asp:Button ID="backspaceButton" runat="server" Text="<-" Width="40" /></td>
                <td><asp:Button ID="divideButton" runat="server" Text="/" Width="40" /></td>
            </tr>
            <tr>
                <td><asp:Button ID="oneButton" runat="server" Text="1" Width="40" /></td>
                <td><asp:Button ID="twoButton" runat="server" Text="2" Width="40" /></td>
                <td><asp:Button ID="threeButton" runat="server" Text="3" Width="40" /></td>
                <td><asp:Button ID="multiplyButton" runat="server" Text="*" Width="40" /></td>
            </tr>
            <tr>
                <td><asp:Button ID="fourButton" runat="server" Text="4" Width="40" /></td>
                <td><asp:Button ID="fiveButton" runat="server" Text="5" Width="40" /></td>
                <td><asp:Button ID="sixButton" runat="server" Text="6" Width="40" /></td>
                <td><asp:Button ID="subtractButton" runat="server" Text="-" Width="40" /></td>
            </tr>
            <tr>
                <td><asp:Button ID="sevenButton" runat="server" Text="7" Width="40" /></td>
                <td><asp:Button ID="eightButton" runat="server" Text="8" Width="40" /></td>
                <td><asp:Button ID="nineButton" runat="server" Text="9" Width="40" /></td>
                <td><asp:Button ID="addButton" runat="server" Text="+" Width="40" /></td>
            </tr>
            <tr>
                <td><asp:Button ID="signButton" runat="server" Text="+/-" Width="40" /></td>
                <td><asp:Button ID="zeroButton" runat="server" Text="0" Width="40" /></td>
                <td><asp:Button ID="pointButton" runat="server" Text="." Width="40" /></td>
                <td><asp:Button ID="equalButton" runat="server" Text="=" Width="40" /></td>
            </tr>
        </table>
    </form>
</body>
</html>
