<%@ Page Title="" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="UnsubscribeR.Search" EnableEventValidation="False" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link href="https://code.jquery.com/ui/1.12.0/themes/base/jquery-ui.css" rel="stylesheet" />
    <script src="https://code.jquery.com/jquery-1.12.4.js" type="text/javascript"></script>
    <script src="https://code.jquery.com/ui/1.12.0/jquery-ui.js" type="text/javascript"></script>

    <link href="www/css/Style.css" rel="stylesheet" />
    <link href="www/css/FormStyle.css" rel="stylesheet" />
    <link href="www/css/SearchStyle.css" rel="stylesheet" />
    
    <script src="jquery.js" type="text/javascript"></script>
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/3.1.1/jquery.min.js"></script>
    <script type="text/javascript"  lang="js">

    </script> 

    <style type="text/css">

        .focus-border {
            border-color: #FF0000; /* Replace with the desired border color */
        }


        .pager {
            font-size: 18px;
            background-color: aquamarine;
        }

        .container {
            width: 300px;
            height: 300px;
            position: absolute;
            border: 1px solid green;
        }

        .centerTop {
            margin: 0;
            position: absolute;
            width: 80%;
            height: 80%;
            top: 20px;
            left: 50%;
            background-color: rgb(193, 206, 228, 0.8);
            -ms-transform: translate(-50%, -50%);
            transform: translate(-50%, -50%);
        }

        .centerBottom {
            margin: 0;
            position: absolute;
            width: 80%;
            height: 80%;
            bottom: 2px;
            left: 50%;
            background-color: rgb(193, 206, 228, 0.8);
            -ms-transform: translate(-50%, -50%);
            transform: translate(-50%, -50%);
        }


        .ConfirmPanel {
        }

            .ConfirmPanel .InsertButton {
                background-color: transparent;
                border: 1px solid black;
            }

            .ConfirmPanel .CancelButton {
                background-color: red;
                border: 1px solid black;
            }

            .ConfirmPanel .InsertButton:hover {
                background-color: forestgreen;
            }

            .ConfirmPanel .CancelButton:hover {
                background-color: transparent;
            }

           
    </style>



</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="position: absolute; right: 480px; top: 26px;">
        <a id="AdminLink" runat="server" href="http://bajasit.orior.int/Admin/Loginpage.aspx" style="color: white">Administración</a>
    </div>


    <div class="hero row align-items-center">
        <div class="col-md-12">
            <div class="form" style="background-color: rgba(220, 220, 255, 0.03); border: none">
                <form id="form1" runat="server">

                    <asp:ScriptManager ID="ScriptManager1" runat="server" ScriptMode="Auto"></asp:ScriptManager>
                    <asp:Label ID="hiden" runat="server" Enabled="false" Style="background-color: transparent;"> </asp:Label>
                    <asp:Label ID="hidenEP" runat="server" Enabled="false" Style="background-color: transparent;"> </asp:Label>
                    <asp:Label ID="hidenCP" runat="server" Enabled="false" Style="background-color: transparent;"> </asp:Label>
                    <asp:Label ID="hidenCPST" runat="server" Enabled="false" Style="background-color: transparent;"> </asp:Label>

                    <ajaxToolkit:ModalPopupExtender ID="ModalPopupFoundPanel" runat="server" PopupControlID="FoundsPanel" TargetControlID="hiden" PopupDragHandleControlID="headerdiv" X="0" Y="0"></ajaxToolkit:ModalPopupExtender>
                    <ajaxToolkit:ModalPopupExtender ID="ModalPopupEditPanel" runat="server" PopupControlID="EditPanel" TargetControlID="hidenEP" PopupDragHandleControlID="headerdivEP" X="125" Y="0"></ajaxToolkit:ModalPopupExtender>
                    <ajaxToolkit:ModalPopupExtender ID="ModalPopupConfirmPanel" runat="server" PopupControlID="ConfirmPanel" TargetControlID="hidenCP" PopupDragHandleControlID="headerCP" X="700" Y="180"></ajaxToolkit:ModalPopupExtender>
                    <ajaxToolkit:ModalPopupExtender ID="ModalPopupStatePanel" runat="server" PopupControlID="StatePanel" TargetControlID="hidenCPST" PopupDragHandleControlID="headerCPST" X="700" Y="180"></ajaxToolkit:ModalPopupExtender>

                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <div class="TopPanel">

                                <div class="search-box">

                                    <asp:Table ID="Table2" runat="server">

                                        <asp:TableRow style="margin-bottom: 15px" runat="server">
                                            <asp:TableCell runat="server" Width="375px">
                                                <h3>GENERAR BAJA </h3>
                                            </asp:TableCell>
                                            <asp:TableCell runat="server">
                                                <h3>BUSCAR REGISTRO </h3>
                                            </asp:TableCell>
                                        </asp:TableRow>
                                    </asp:Table>
                                    

                                    <div class="input-searchicon">
                                        <asp:TextBox ID="DataTb" runat="server" AutoPostBack="True" class="form-control" OnTextChanged="DataTb_TextChanged" AutoCompleteType="Disabled"
                                             autocomplete="off" Width="350px" Style="float: left"></asp:TextBox>
                                        <asp:ImageButton ID="SearchBtn" runat="server" ImageUrl="~/www/img/search.svg" CssClass="searchicon" class="btn btn-block" OnClick="SearchBtn_Click" Width="15" Height="15" />
                                    
                                    </div>

                                    <div class="input-searchicon" style="margin-left: 25px">
                                        <asp:TextBox ID="SearchRows" runat="server" AutoPostBack="True" class="form-control" AutoCompleteType="Disabled"
                                            autocomplete="off" Width="450px" Style="float: right" OnTextChanged="SearchRows_TextChanged"></asp:TextBox>
                                        <asp:ImageButton ID="SearchRowsBtn" runat="server" ImageUrl="~/www/img/search.svg" CssClass="searchicon" class="btn btn-block" Width="15" Height="15" OnClick="SearchRowsBtn_Click" />
                                    </div>

                                    
                                </div>

                                <ul id="rightbox" class="group-button">
                                     <li>
                                        <asp:Button ID="ErrorsBtn" runat="server" Text="Error" OnClick="StatusButtons_Click" Style="background-color: orangered"/>
                                    </li>
                                    <li>
                                        <asp:Button ID="ProcessingBtn" runat="server" Text="Procesando" OnClick="StatusButtons_Click" />
                                    </li>
                                     <li>
                                        <asp:Button ID="ProessedBtn" runat="server" Text="Procesados" OnClick="StatusButtons_Click" />
                                    </li>
                                    <li>
                                        <asp:Button ID="CanceledBtn" runat="server" Text="Cancelados" OnClick="StatusButtons_Click" />
                                    </li>
                                    <li>
                                        <asp:Button ID="ProgrammedBtn" runat="server" Text="Programados" OnClick="StatusButtons_Click"  Visible="False" />
                                    </li>
                                </ul>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>

                    <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="5">
                        <ProgressTemplate>
                            <div id="progress">
                                <img alt="image" src="www/img/wait4.gif" style="width: 100px; height: 100px;" />
                            </div>
                        </ProgressTemplate>
                    </asp:UpdateProgress>

                    <br />
                    <div class="search-box">
                       
                    </div>

                    <!-- BAJAS PROGRAMADAS -- GESTIONADAS -- CANCELADAS -->

                    <div class="section">
                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                            <ContentTemplate>

                                <div class="grid-style">

                                    <h3 id="CaptionSh" runat="server">Bajas Programadas</h3>
                                    <div class="RightboxScheduled" id="ButtonsBox" runat="server">
                                        <asp:Button ID="EditButton" runat="server" Text="Editar" OnClick="EditButton_Click" Width="100px" Font-Size="12px" />
                                    </div>
                                    

                                    <div class="table-scroll">

<%--                                        <asp:Label ID="LimitProcess" runat="server" Text="DEMASIADOS PROCESOS CONCURRENTES" Font-Bold="True" ForeColor="#FF3300" Visible="False"></asp:Label>--%>
                                        <br />

                                        <asp:GridView ID="ProgrammedGridView" runat="server" AutoGenerateColumns="False" Width="100%"
                                            Font-Size="12px" AllowSorting="True"
                                            EmptyDataText="No hay datos"
                                            ShowHeaderWhenEmpty="True"
                                            AllowPaging="True" CellSpacing="5" CellPadding="5" border="0" GridLines="Vertical"
                                            OnRowCreated="ScheduledGV_RowCreated"
                                            OnSelectedIndexChanged="ScheduledGV_SelectedIndexChanged"
                                            OnSorting="ScheduledGV_Sorting"
                                            OnPageIndexChanging="ScheduledGV_PageIndexChanging"
                                            PageSize="20" OnRowCommand="ProgrammedGridView_RowCommand" RowStyle-Height="20px">
                                            <Columns>

                                                <asp:BoundField DataField="LogBajasId" HeaderText="Id" ReadOnly="True" SortExpression="LogBajasId" Visible="True">
                                                    <HeaderStyle Width="20px" Wrap="False" />
                                                </asp:BoundField>

                                                <asp:BoundField DataField="StartProcess" DataFormatString="{0:d}" HeaderText="Fecha Inicio" SortExpression="StartProcess" ApplyFormatInEditMode="True">
                                                    <HeaderStyle Width="30px" Wrap="False" />
                                                    <ItemStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" Wrap="True" />
                                                </asp:BoundField>

                                                <asp:HyperLinkField DataTextField="Ticket" DataNavigateUrlFields="Ticket" HeaderText="Ticket" SortExpression="Ticket" DataNavigateUrlFormatString="https://ocaglobal.atlassian.net/browse/{0}">
                                                    <HeaderStyle Width="40px" Wrap="False" />
                                                </asp:HyperLinkField>
                                                
                                                <asp:BoundField DataField="Name" HeaderText="Nombre" SortExpression="Name">
                                                    <HeaderStyle Width="180px" Wrap="False" />
                                                    <ItemStyle Wrap="True" />
                                                </asp:BoundField>

                                                 <asp:BoundField DataField="Mail" HeaderText="Mail" ReadOnly="True" SortExpression="Mail">
                                                    <HeaderStyle Width="150px" Wrap="False" />
                                                    <ItemStyle Wrap="True" />
                                                </asp:BoundField>

                                                <asp:BoundField DataField="ResponsableTicket" HeaderText="Responsable" SortExpression="ResponsableTicket">
                                                    <HeaderStyle Width="180px" Wrap="False" />
                                                    <ItemStyle Wrap="True" />
                                                </asp:BoundField>

                                                <asp:ButtonField ButtonType="Button" Text="Procesar" ControlStyle-Width="50px" CommandName="ToProcess" ItemStyle-HorizontalAlign="Center" ControlStyle-Height="30px" ItemStyle-Height="30px" HeaderText="Procesar">
                                                    <ControlStyle BackColor="#9FE8FF" Width="80px" Height="25px" Font-Size="X-Small" Font-Bold="True" />
                                                    <HeaderStyle Width="50px" Wrap="False" />
                                                    <ItemStyle Wrap="True" />
                                                </asp:ButtonField>

                                                 <asp:ButtonField ButtonType="Button" Text="No Procesar" ControlStyle-Width="50px" CommandName="No_Process" ItemStyle-HorizontalAlign="Center" ControlStyle-Height="30px" ItemStyle-Height="30px" HeaderText="No Procesar">
                                                    <ControlStyle BackColor="#FFB3B3" Width="80px" Height="25px" Font-Size="X-Small" Font-Bold="True" />
                                                    <HeaderStyle Width="50px" Wrap="False" />
                                                    <ItemStyle Wrap="True" />
                                                </asp:ButtonField>

                                                <asp:ButtonField ButtonType="Button" Text="Restaurar" ControlStyle-Width="50px" CommandName="Restore" ItemStyle-HorizontalAlign="Center" ControlStyle-Height="30px" ItemStyle-Height="30px"  Visible="False" HeaderText="Restaurar">
                                                    <ControlStyle BackColor="#66FF99" Width="80px" Height="25px" Font-Size="X-Small" Font-Bold="True" />
                                                    <HeaderStyle Width="50px" Wrap="False" />
                                                    <ItemStyle Wrap="True" />
                                                </asp:ButtonField>

                                                <asp:ButtonField ButtonType="Button" Text="Estado" ControlStyle-Width="50px" CommandName="State" ItemStyle-HorizontalAlign="Center" ControlStyle-Height="30px" ItemStyle-Height="30px"  Visible="False" HeaderText="Estado">
                                                    <ControlStyle BackColor="#6699FF" Width="80px" Height="25px" Font-Size="X-Small" Font-Bold="True" />
                                                    <HeaderStyle Width="50px" Wrap="False" />
                                                    <ItemStyle Wrap="True" />
                                                </asp:ButtonField>

                                            </Columns>
                                            <EmptyDataRowStyle BackColor="#E2E2E2" Font-Bold="True" Font-Size="Medium" Font-Underline="False" ForeColor="Red" Height="120px" HorizontalAlign="Center" Width="200px" />
                                            <FooterStyle Font-Bold="True" ForeColor="Black" />
                                            <HeaderStyle Font-Bold="True" ForeColor="Black" Font-Size="X-Small" HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <PagerSettings Mode="NextPrevious" FirstPageText="&amp;lt;  &amp;lt;" LastPageText="&amp;gt;  &amp;gt;" />
                                            <PagerStyle HorizontalAlign="Center" Font-Bold="True" Font-Size="30px" Font-Underline="False" ForeColor="Red" Wrap="True" />
                                            <RowStyle VerticalAlign="Middle" Wrap="True" Height="20px" />
                                            <SelectedRowStyle BackColor="#CCCCCC" Font-Bold="True" Font-Italic="True" />
                                            <SortedAscendingCellStyle BackColor="#F8FAFA" />
                                            <SortedAscendingHeaderStyle BackColor="#246B61" />
                                            <SortedDescendingCellStyle BackColor="#D4DFE1" />
                                            <SortedDescendingHeaderStyle BackColor="#15524A" />
                                        </asp:GridView>
                                    </div>

                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>

                    <br />
                    <br />
                    <br />

                    <br />
                    <br />
                    <br />
                    <br />


                    <!-- EDIT PANEL -->
                    <asp:Panel ID="EditPanel" runat="server" CssClass="EditPanel">

                        <div id="headerdivEP" class="thisheaderEP"></div>

                        <asp:UpdatePanel ID="UpdatePanel_EditPanel" runat="server">
                            <ContentTemplate>
                                <div class="popup-content">

                                    <div id="rightbox3EP">
                                        <asp:ImageButton ID="EditPanelCloseButton" runat="server" ImageUrl="~/www/img/closeWindow.png" Width="18px" Height="18px" OnClick="EditPanelCloseButton_Click" />
                                    </div>

                                    <center>
                                        <h3 id="H1" runat="server" class="popup-heading">Programación Baja</h3>
                                        <br />
                                    </center>

                                    <div>
                                        <div class="row">
                                            <div class="col-sm-12 col-md-6">
                                                <asp:Label ID="Label5" runat="server" Text="Ticket" CssClass="labelEP"></asp:Label>
                                                <asp:TextBox ID="TicketTb" runat="server" Enabled="False" CssClass="tbEP"></asp:TextBox>
                                            </div>
                                            <div class="col-sm-12 col-md-6">
                                                <asp:Label ID="L1" runat="server" Text="Nombre" CssClass="labelEP"></asp:Label>
                                                <asp:TextBox ID="NameTb" runat="server" Enabled="False" CssClass="tbEP"></asp:TextBox>
                                            </div>
                                            <div class="col-sm-12 col-md-6">
                                                <asp:Label ID="L4" runat="server" Text="Empleado Id" CssClass="labelEP"></asp:Label>
                                                <asp:TextBox ID="EmployeeIdTb" runat="server" Enabled="False" CssClass="tbEP" ></asp:TextBox>
                                            </div>
                                            <div class="col-sm-12 col-md-6">
                                                <asp:Label ID="Label1" runat="server" Text="Windows Id" CssClass="labelEP"></asp:Label>
                                                <asp:TextBox ID="WindowsidTb" runat="server" Enabled="True" CssClass="tbEP" OnTextChanged="WindowsidTb_TextChanged"></asp:TextBox>
                                            </div>

                                            <div class="col-sm-12 col-md-6">
                                                <asp:Label ID="L2" runat="server" Text="Mail" CssClass="labelEP"></asp:Label>
                                                <asp:TextBox ID="MailTb" runat="server" Enabled="True" CssClass="tbEP" ></asp:TextBox>
                                            </div>
                                           
                                            <div class="col-sm-12 col-md-6">
                                                <asp:Label ID="L5" runat="server" Text="Responsable Ticket"  CssClass="labelEP"></asp:Label>
                                                <asp:TextBox ID="ResponsableTicketTb" runat="server" Enabled="True" CssClass="tbEP" ></asp:TextBox>
                                            </div>


                                            <div class="col-sm-12 col-md-6">
                                                <asp:Label ID="L6" runat="server" Text="Responsable AD" CssClass="labelEP"></asp:Label>
                                                <asp:TextBox ID="ResponsableADTb" runat="server" Enabled="False" CssClass="tbEP"></asp:TextBox>
                                            </div>
                                           

                                            <div class="col-sm-12 col-md-12">
                                                <hr />
                                                <asp:Label ID="ErrorLabel" runat="server" Visible="False" Font-Bold="True" Font-Size="X-Small"></asp:Label>
                                                <hr />
                                            </div>


                                            <div class="col-sm-12 col-md-4">
                                                <asp:Label ID="Label4" runat="server" Text="Backup Mail" CssClass="labelEP" Style="vertical-align: top; text-align: center;" ForeColor="Blue"></asp:Label>
                                                <asp:CheckBox ID="BackupMailCB" runat="server" />
                                            </div>


                                            <div class="col-sm-12 col-md-4">
                                                <asp:Label ID="Label3" runat="server" Text="Tranfer" CssClass="labelEP" Style="vertical-align: top; text-align: center;" ForeColor="Blue"></asp:Label>
                                                <asp:CheckBox ID="TranferCB" runat="server" />
                                            </div>

                                             <div class="col-sm-12 col-md-4">
                                                <asp:Label ID="Label7" runat="server" Text="Delete AD" CssClass="labelEP" Style="vertical-align: top; text-align: center;" ForeColor="Blue"></asp:Label>
                                                <asp:CheckBox ID="DeleteADCB" runat="server" />
                                            </div>

                                            <div class="col-sm-12 col-md-4">
                                                <asp:Label ID="Label2" runat="server" Text="Backup Drive" CssClass="labelEP" Style="vertical-align: top; text-align: center;" ForeColor="Blue"></asp:Label>
                                                <asp:CheckBox ID="BackupDriveCB" runat="server" />
                                            </div>

                                             <div class="col-sm-12 col-md-4">
                                                <asp:Label ID="Label6" runat="server" Text="Alias" CssClass="labelEP" Style="vertical-align: top; text-align: center;" ForeColor="Blue"></asp:Label>
                                                <asp:CheckBox ID="AliasCB" runat="server" />
                                            </div>
                                            
                                            <div class="col-sm-12">
                                                <asp:Table ID="TableButtons" runat="server" align="center">
                                                    <asp:TableRow>
                                                         <asp:TableCell>
                                                            <asp:Button ID="EditPanelValidateButton" runat="server" CssClass="buttonLP" Text="Validar" OnClick="EditPanelValidateButton_Click" BackColor="#3366CC" />
                                                        </asp:TableCell>
                                                        <asp:TableCell>
                                                            <asp:Button ID="EditPanelAcceptButton" runat="server" CssClass="buttonLP" Text="Aceptar" OnClick="EditPanelAcceptButton_Click" Visible="False" />
                                                        </asp:TableCell>
                                                        <asp:TableCell>
                                                            <asp:Button ID="EditPanelCancelButton" runat="server" CssClass="buttonCancel" Text="Cancelar" OnClick="EditPanelCancelButton_Click" />
                                                        </asp:TableCell>
                                                    </asp:TableRow>
                                                </asp:Table>
                                            </div>
                                        </div>

                                    </div>

                                </div>

                            </ContentTemplate>
                        </asp:UpdatePanel>

                    </asp:Panel>

                     <asp:UpdateProgress ID="UpdateProgress2" runat="server" AssociatedUpdatePanelID="UpdatePanel_EditPanel" DisplayAfter="5">
                        <ProgressTemplate>
                            <div id="progress">
                                <img alt="image" src="www/img/wait4.gif" style="width: 100px; height: 100px;" />
                            </div>
                        </ProgressTemplate>
                    </asp:UpdateProgress>


                    <!-- FOUNDS PANEL (ENCONTRADOS) -->
                    <asp:Panel ID="FoundsPanel" runat="server" CssClass="LocatedPanel">

                        <div id="headerdiv" class="thisheader"></div>

                        <asp:UpdatePanel runat="server">

                            <ContentTemplate>

                                <div class="popup-content-LocatedPanel">

                                    <div id="rightbox3LP" style="position: absolute; right: 30px; top: 38px;">
                                        <asp:ImageButton ID="FoundsPanelCloseButton" runat="server" ImageUrl="~/www/img/closeWindow.png" Width="18px" Height="18px" OnClick="FoundsPanelCloseButton_Click" />
                                    </div>

                                    <center>
                                        <h3 id="H2" runat="server" class="popup-heading">Empleados Encontrados</h3>
                                    </center>

                                    <div class="table-scroll" style="overflow-x: auto; width: 96%; padding-left: 20px;">

                                        <asp:GridView ID="FoundsGridView" runat="server" AutoGenerateColumns="False" DataKeyNames="usuarioWindows"
                                            CellPadding="10" AllowSorting="True" EmptyDataText="No hay datos" ShowHeaderWhenEmpty="True"
                                            AllowPaging="True" CellSpacing="5" GridLines="None" border="0"
                                            BorderStyle="Outset"
                                            OnRowCreated="FoundsGridView_RowCreated"
                                            OnSorting="FoundsGridView_Sorting"
                                            OnPageIndexChanging="FoundsGridView_PageIndexChanging"
                                            PageSize="15" align="center" OnSelectedIndexChanged="FoundsGridView_SelectedIndexChanged">

                                            <Columns>
                                                <asp:BoundField DataField="empleadoId" HeaderText="EMPLEADO" ReadOnly="True" SortExpression="empleadoId">
                                                    <ItemStyle HorizontalAlign="Right" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="nombreCompleto" HeaderText="NOMBRE" ReadOnly="True" SortExpression="nombreCompleto">
                                                    <ItemStyle />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="email" HeaderText="CORREO" ReadOnly="True" SortExpression="email">
                                                    <ItemStyle />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="divisionPersonalDescripcion" HeaderText="COMPAÑIA" ReadOnly="True" SortExpression="divisionPersonalDescripcion">
                                                    <ItemStyle />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="posicionDescripcion" HeaderText="CARGO" ReadOnly="True" SortExpression="posicionDescripcion">
                                                    <ItemStyle />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="usuarioWindows" HeaderText="WINDOWS ID" ReadOnly="True" SortExpression="usuarioWindows">
                                                    <ItemStyle HorizontalAlign="Right" />
                                                </asp:BoundField>
                                            </Columns>

                                            <EditRowStyle />
                                            <EmptyDataRowStyle Font-Bold="True" Font-Size="Medium" Font-Underline="False" ForeColor="Red" Height="120px" HorizontalAlign="Center" Width="200px" />
                                            <FooterStyle Font-Bold="True" />
                                            <HeaderStyle Font-Bold="True" ForeColor="Black" HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <PagerSettings FirstPageText="&amp;lt;  &amp;lt;" LastPageText="&amp;gt;  &amp;gt;" Mode="NextPreviousFirstLast" />
                                            <PagerStyle ForeColor="Black" HorizontalAlign="Center" Font-Bold="True" Font-Size="Medium" Height="20px" />
                                            <RowStyle VerticalAlign="Middle" Wrap="False" />
                                            <SelectedRowStyle BackColor="#999999" Font-Bold="True" Font-Italic="True" />
                                            <SortedAscendingCellStyle BackColor="#F8FAFA" />
                                            <SortedAscendingHeaderStyle BackColor="#246B61" />
                                            <SortedDescendingCellStyle BackColor="#D4DFE1" />
                                            <SortedDescendingHeaderStyle BackColor="#15524A" />
                                        </asp:GridView>

                                    </div>

                                    <asp:Table runat="server" align="center">
                                        <asp:TableRow>
                                            <asp:TableCell>
                                                <asp:Button ID="FoundsPanelCancelButton" runat="server" CssClass="buttonCancel" Text="Cancelar" OnClick="FoundsPanelCancelButton_Click" />
                                            </asp:TableCell>
                                        </asp:TableRow>
                                    </asp:Table>

                                </div>

                            </ContentTemplate>

                        </asp:UpdatePanel>

                        <div id="footerdiv" class="thisfooter"></div>

                    </asp:Panel>
                                        


                    <!-- CONFIRM PANEL (PANEL DE CONFIRMACION) -->
                    <asp:Panel ID="ConfirmPanel" runat="server" CssClass="ConfirmPanel">

                        <div id="headerCP" class="headerCP">
                            <div id="rightbox3CP">
                            </div>
                        </div>
                        <br />

                        <asp:UpdatePanel runat="server">
                            <ContentTemplate>
                                <div id="rightbox7CP">
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>

                        <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                            <ContentTemplate>

                                <div class="popup-content literal-content">
                                    <asp:Literal ID="Literal1" runat="server"></asp:Literal>
                                    <br />
                                    <br />
                                    <asp:Literal ID="Literal2" runat="server"></asp:Literal>
                                    <asp:Literal ID="Literal3" runat="server"></asp:Literal>
                                    <br />
                                    <div class="literal-content-left">
                                        <asp:Label ID="LableResult" runat="server"></asp:Label>
                                    </div>

                                    <asp:Literal ID="Literal4" runat="server"  ></asp:Literal>
                                    <asp:Literal ID="Literal5" runat="server"></asp:Literal>
                                    <br />
                                    <asp:Literal ID="Literal6" runat="server">¿Estás seguro?</asp:Literal>
                                    <div class="literal-content-buttons">
                                        <asp:Button ID="ConfirmPanelAcceptButton" runat="server" Text="Aceptar" CssClass="InsertButton" OnClick="ConfirmPanelAcceptButton_Click" />
                                        <asp:Button ID="CancelPanelAcceptButton" runat="server" Text="Cancelar" CssClass="buttonCancel" OnClick="ConfirmPanelCancelButton_Click" />
                                    </div>

                                </div>

                            </ContentTemplate>
                        </asp:UpdatePanel>

                        <div id="footerdivCP" class="thisfooter"></div>

                    </asp:Panel>


                    
                    <!-- STATE PANEL (PANEL DE ESTADO) -->
                    <asp:Panel ID="StatePanel" runat="server" CssClass="StatePanel">

                        <div id="headerCPState" class="headerCP">
                            <div id="rightbox3CPState"></div>
                        </div>
                        <br />

                        <asp:UpdatePanel runat="server">
                            <ContentTemplate>
                                <div id="rightbox7CPState">
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>


                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                            <ContentTemplate>
                                
                                <div class="popup-content literal-content">
                                    
                                    <center>
                                        <h3 id="H3" runat="server" class="StatePanel-popup-heading">ESTADO</h3>
                                    </center>
                                    <br />

                                    <asp:Table ID="Table1" runat="server" Height="123px" Width="567px" CaptionAlign="Top">
                                        <asp:TableRow runat="server">
                                            <asp:TableCell runat="server">Estado:</asp:TableCell>
                                            <asp:TableCell ID="TableCell1" runat="server" Style="color: blue; font-style: oblique;"></asp:TableCell>
                                        </asp:TableRow>
                                        <asp:TableRow runat="server">
                                            <asp:TableCell runat="server">Export Id:</asp:TableCell>
                                            <asp:TableCell ID="TableCell17" runat="server"></asp:TableCell>
                                        </asp:TableRow>
                                        <asp:TableRow runat="server">
                                            <asp:TableCell runat="server">Inicio de Proceso:</asp:TableCell>
                                            <asp:TableCell ID="TableCell2" runat="server"></asp:TableCell>
                                        </asp:TableRow>
                                        <asp:TableRow runat="server">
                                            <asp:TableCell runat="server">Actualización:</asp:TableCell>
                                            <asp:TableCell ID="TableCell3" runat="server"></asp:TableCell>
                                        </asp:TableRow>
                                       <%-- <asp:TableRow runat="server">
                                            <asp:TableCell runat="server">Ticket:</asp:TableCell>
                                            <asp:TableCell ID="TableCell4" runat="server"></asp:TableCell>
                                        </asp:TableRow>--%>
                                        <asp:TableRow runat="server">
                                            <asp:TableCell runat="server">Usuario Windows:</asp:TableCell>
                                            <asp:TableCell ID="TableCell5" runat="server"></asp:TableCell>
                                        </asp:TableRow>
                                        <asp:TableRow runat="server">
                                            <asp:TableCell runat="server">Estado Ticket:</asp:TableCell>
                                            <asp:TableCell ID="TableCell6" runat="server"></asp:TableCell>
                                        </asp:TableRow>
                                        <asp:TableRow runat="server">
                                            <asp:TableCell runat="server">Id Empleado:</asp:TableCell>
                                            <asp:TableCell ID="TableCell7" runat="server"></asp:TableCell>
                                        </asp:TableRow>
                                         <asp:TableRow runat="server">
                                            <asp:TableCell runat="server">Nombre Export:</asp:TableCell>
                                            <asp:TableCell ID="TableCell8" runat="server"></asp:TableCell>
                                        </asp:TableRow>
                                         <asp:TableRow runat="server">
                                            <asp:TableCell runat="server">Error Export:</asp:TableCell>
                                            <asp:TableCell ID="TableCell9" runat="server"></asp:TableCell>
                                        </asp:TableRow>
                                         <asp:TableRow runat="server">
                                            <asp:TableCell runat="server">Bytes:</asp:TableCell>
                                            <asp:TableCell ID="TableCell10" runat="server"></asp:TableCell>
                                        </asp:TableRow>
                                         <asp:TableRow runat="server">
                                            <asp:TableCell runat="server">Backup Mail:</asp:TableCell>
                                            <asp:TableCell ID="TableCell11" runat="server"></asp:TableCell>
                                        </asp:TableRow>
                                         <asp:TableRow runat="server">
                                            <asp:TableCell runat="server">Backup Drive:</asp:TableCell>
                                            <asp:TableCell ID="TableCell12" runat="server"></asp:TableCell>
                                        </asp:TableRow>
                                         <asp:TableRow runat="server">
                                            <asp:TableCell runat="server">Estado Transfer:</asp:TableCell>
                                            <asp:TableCell ID="TableCell13" runat="server"></asp:TableCell>
                                        </asp:TableRow>
                                         <asp:TableRow runat="server">
                                            <asp:TableCell runat="server">Estado AD:</asp:TableCell>
                                            <asp:TableCell ID="TableCell14" runat="server"></asp:TableCell>
                                        </asp:TableRow>
                                         <asp:TableRow runat="server">
                                            <asp:TableCell runat="server">Estado Alias:</asp:TableCell>
                                            <asp:TableCell ID="TableCell15" runat="server"></asp:TableCell>
                                        </asp:TableRow>
                                         <asp:TableRow runat="server">
                                            <asp:TableCell runat="server">Estado Google:</asp:TableCell>
                                            <asp:TableCell ID="TableCell16" runat="server"></asp:TableCell>
                                        </asp:TableRow>
                                        <asp:TableRow runat="server">
                                            <asp:TableCell runat="server">Password:</asp:TableCell>
                                            <asp:TableCell ID="TableCell18" runat="server"></asp:TableCell>
                                        </asp:TableRow>
                                    </asp:Table>

                                    <div class="literal-content-buttons">
                                        <asp:Button ID="StatePanelAcceptButton" runat="server" Text="Aceptar" CssClass="InsertButton" OnClick="StatePanelAcceptButton_Click" />
                                    </div>

                                </div>

                            </ContentTemplate>
                        </asp:UpdatePanel>

                        <div id="footerdivCPState" class="thisfooter"></div>

                    </asp:Panel>


                </form>

            </div>
        </div>

    </div>
</asp:Content>





