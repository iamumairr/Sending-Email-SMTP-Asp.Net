<%@ Page Title="Sending Email" Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Lab_5_Sending_Email.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="background-color: #33CCFF">
    <form id="form1" runat="server">
        <div>
            <h1>Customer Care Centre</h1>
            <br />
            <asp:Panel runat="server" ID="Panel1">
                <table>
                    <tr>
                        <td>
                            <asp:Label runat="server" Text="Subject" Width="200px"></asp:Label>

                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="TxtSubject"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label runat="server" Text="Name" Width="200px"></asp:Label>

                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="TxtName"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label runat="server" Text="National ID" Width="200px"></asp:Label>

                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="TxtNationalID"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label runat="server" Text="Email" Width="200px"></asp:Label>

                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="TxtEmail"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label runat="server" Text="Phone" Width="200px"></asp:Label>

                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="TxtPhone"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label runat="server" Text="Description" Width="200px"></asp:Label>

                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="TxtDescription" TextMode="MultiLine"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label runat="server" Text="Contents" Width="200px"></asp:Label>

                        </td>
                        <td>
                            <asp:FileUpload ID="FileUpload1" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td></td>
                        <td>
                            <asp:Button runat="server" ID="BtnSendInformation" Text="Send Information" OnClick="BtnSendInformation_Click"/>
                        <asp:Label runat="server" ID="TxtMessage"></asp:Label>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </div>
    </form>
</body>
</html>