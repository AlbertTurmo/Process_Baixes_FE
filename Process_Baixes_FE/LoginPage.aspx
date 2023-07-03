<%@ Page Title="" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="UnsubscribeR.LoginPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">


    <style type="text/css">
        #progress {
            position: fixed;
            top: 38%;
            left: 41%;
            height: 18%;
            width: 18%;
            z-index: 100001;
            background-color: transparent;
            background-position: center;
        }
        
        .styletable {
            height: 100px;
            width: 100%;
        }

        .labelstyle {
            text-align: right;
            width: 80px;
            height: 20px;
            padding-top: 20px;
            padding-right: 10px;
            /*  background-color: blanchedalmond; */
        }

        .textboxstyle {
            height: 16px;
            padding-top: 10px;
            width: 60%;
            font-size: 0.9em;
        }
    </style>




</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div style="position: relative; margin: auto;">

            <div style="position: relative; margin: auto; top: 18%;">
                <center>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>

                            <asp:Login ID="OcaLogin" runat="server" BackColor="transparent" BorderColor="transparent" BorderPadding="2" BorderStyle="Double" BorderWidth="1px" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#333333" OnAuthenticate="Login1_Authenticate" FailureText="Usuario o Password incorrectos." DisplayRememberMe="False" PasswordLabelText="Password:" UserNameLabelText="Usuario:">
                                <InstructionTextStyle Font-Italic="True" ForeColor="Black" />
                                <LayoutTemplate>
                                    <div class="table-login">

                                        <h1 class="main-title">Solicitud Bajas Empleado</h1>

                                        <asp:TextBox ID="UserName" runat="server" AutoCompleteType="Disabled" placeholder="Usuario" autocomplete="off"></asp:TextBox>

                                        <asp:TextBox ID="Password" runat="server" AutoCompleteType="Disabled" TextMode="Password" autocomplete="off"  placeholder="Contraseña"></asp:TextBox>

                                        <div class="error-msg">
                                            <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName" ErrorMessage="El nombre de usuario es obligatorio." ToolTip="El nombre de usuario es obligatorio." ValidationGroup="OcaLogin">*El nombre de usuario es obligatorio.</asp:RequiredFieldValidator>
                                            <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password" ErrorMessage="La contraseña es obligatoria." ToolTip="La contraseña es obligatoria." ValidationGroup="OcaLogin">*La contraseña es obligatoria.</asp:RequiredFieldValidator>
                                            <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                                        </div>

                                        <div class="text-center" style="margin-top: 1em;">
                                            <asp:Button ID="LoginButton" runat="server" BackColor="#FFFBFF" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" CommandName="Login" Font-Names="Verdana" Font-Size="0.9em" ForeColor="#284775" Text="Iniciar" ValidationGroup="OcaLogin" Width="120px" OnClick="LoginButton_Click" />
                                        </div>

                                    </div>

                                </LayoutTemplate>
                                <FailureTextStyle ForeColor="#FF3300" />
                                <LoginButtonStyle BackColor="#FFFBFF" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#284775" />
                                <TextBoxStyle Font-Size="0.8em" />
                                <TitleTextStyle BackColor="#5D7B9D" Font-Bold="True" Font-Size="0.9em" ForeColor="White" />
                            </asp:Login>
                        </ContentTemplate>
                    </asp:UpdatePanel>

                    <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="20">
                        <ProgressTemplate>
                            <div id="progress">
                                <img alt="image" src="www/img/wait4.gif" style="width: 60px; height: 60px;" />
                            </div>
                        </ProgressTemplate>
                    </asp:UpdateProgress>

                </center>
            </div>
        </div>

      

    </form>
</asp:Content>
