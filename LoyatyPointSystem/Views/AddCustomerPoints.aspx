<%@ Page Title="" EnableEventValidation="false" Language="C#" MasterPageFile="~/Site.Master" EnableViewState="true" AutoEventWireup="true" CodeBehind="AddCustomerPoints.aspx.cs" Inherits="LoyatyPointSystem.Views.AddCustormerPoints" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <script src="https://cdn.datatables.net/1.10.12/js/jquery.dataTables.min.js"></script>
    <script src="https://cdn.datatables.net/1.10.12/js/dataTables.bootstrap.min.js"></script>
    <script src="https://cdn.datatables.net/buttons/1.2.2/js/dataTables.buttons.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jszip/2.5.0/jszip.min.js"></script>
    <script src="https://cdn.rawgit.com/bpampuch/pdfmake/0.1.18/build/pdfmake.min.js"></script>
    <script src="https://cdn.rawgit.com/bpampuch/pdfmake/0.1.18/build/vfs_fonts.js"></script>
    <script src="https://cdn.datatables.net/buttons/1.2.2/js/buttons.html5.min.js"></script>


    <link href="//maxcdn.bootstrapcdn.com/bootstrap/3.3.6/css/bootstrap.min.css" rel="stylesheet" />
    <link href="https://cdn.datatables.net/1.10.12/css/dataTables.bootstrap.min.css" rel="stylesheet" />
    <link href="https://cdn.datatables.net/buttons/1.2.2/css/buttons.dataTables.min.css" rel="stylesheet" />

    <script defer src="../Scripts/bootstrap-datepicker.js"></script>
    <script defer src="../Scripts/bootstrap-datepicker.min.js"></script>

    <link href="Content/bootstrap-datepicker.css" rel="stylesheet" />
    <link href="Content/bootstrap-datepicker.min.css" rel="stylesheet" />

    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <%-- <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js"></script>  --%>

    <script>
        $(function () {
            $("[id$=txtReieptDate]").datepicker({
                showOn: 'button',
                buttonImageOnly: true,
                endDate: new Date(),
                format: 'dd-mm-yyyy',
                //buttonImage: '/Images/calender.png',
                autoclose: true,
                //orientation: 'auto bottom',

            });

        });
    </script>

    <!-- Example DataTables Card-->
    <div class="card mb-3" runat="server">
        <div class="card-header" runat="server">
            <i class="fa fa-table" runat="server"></i>Customer Details
        </div>
        <div class="card-body" runat="server">
            <div class="table-responsive" runat="server">

                <asp:DetailsView ID="AddPointsCustomerDetailsView" Height="150px" Width="50%" runat="server" CellPadding="10" CellSpacing="5" BorderStyle="None" CssClass="form-control" AutoGenerateRows="False"
                    DataKeyNames="ID"
                    EnableViewState="False">
                    <Fields>
                        <asp:BoundField DataField="ID" HeaderText="ID"
                            SortExpression="ID" />

                        <asp:BoundField DataField="Name" HeaderText="Name"
                            ReadOnly="True" SortExpression="Name" />

                        <asp:BoundField DataField="Surname" HeaderText="Surname"
                            ReadOnly="True" SortExpression="Surname" />

                        <asp:BoundField DataField="ID_No"
                            HeaderText="ID Number" SortExpression="ID_No" />

                        <asp:BoundField DataField="GenderName" HeaderText="GenderName"
                            SortExpression="GenderName" />

                        <asp:BoundField DataField="Email"
                            HeaderText="Email" SortExpression="Email" />

                        <asp:BoundField DataField="Cell_No"
                            HeaderText="Cell_No" SortExpression="Cell No" />

                        <asp:BoundField DataField="Loyalty_Points"
                            HeaderText="Loyalty_Points" SortExpression="Loyalty Points" />

                    </Fields>
                    <HeaderStyle BackColor="Navy" ForeColor="White" />

                </asp:DetailsView>

            </div>


            <br />
            <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>

            <div runat="server" id="divAddpoints">
                <div class="row" runat="server">
                    <div class="col-md-2">Receipt Date:</div>
                    <div class="col-md-4">
                        <asp:TextBox ID="txtReieptDate" runat="server" CssClass="form-control" Height="34px"></asp:TextBox>
                    </div>
                </div>

                <div class="row" runat="server" id="divtxtRecieptNo">
                    <div class="col-md-2">Receipt No:</div>
                    <div class="col-md-4">
                        <asp:TextBox ID="txtRecieptNo" runat="server" CssClass="form-control" Height="34px" Text="Reciept No"></asp:TextBox>
                    </div>
                </div>

                <div class="row" runat="server" id="divtxtTotalAmount">
                    <div class="col-md-2">Total Amount:</div>
                    <div class="col-md-4">
                        <asp:TextBox ID="txtTotalAmount" EnableViewState="false" runat="server" CssClass="form-control" Height="34px" Text="100"></asp:TextBox>
                    </div>
                </div>

            </div>


            <div class="row" runat="server" id="divtxtAmountToBeDeducted">
                <div class="col-md-2">Enter Amount To be deducted: </div>
                <div class="col-md-4">
                    <asp:TextBox ID="txtAmountToBeDeducted" runat="server" Height="34px" CssClass="form-control"></asp:TextBox>
                </div>
            </div>

            <div runat="server" id="divPointsRedeemFor" visible="false">

                <div class="row">
                    <div class="col-md-2">
                        Meat
                    </div>
                    <div class="col-md-4">
                        <asp:CheckBox ID="chkMeat" runat="server" />
                    </div>
                    <div class="col-md-2">
                        Alcohol
                    </div>
                    <div class="col-md-4">
                        <asp:CheckBox ID="chkAlcohol" runat="server" />
                    </div>
                </div>

                <div class="row">
                    <div class="col-md-2">
                        Food
                    </div>
                    <div class="col-md-4">
                        <asp:CheckBox ID="chkFood" runat="server" />
                    </div>
                    <div class="col-md-2">
                        Tickets
                    </div>
                    <div class="col-md-4">
                        <asp:CheckBox ID="Tickets" runat="server" />
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-2">
                        PVC
                    </div>
                    <div class="col-md-4">
                        <asp:CheckBox ID="chkPVC" runat="server" />
                    </div>
                </div>

            </div>


            <br />

            <%--<asp:Label Text="mnnhhhhh" runat="server" ID="labbbbb"></asp:Label>--%>
            <div class="row" runat="server">
                <div class="col-md-2"></div>
                <div class="col-md-2">
                    <button runat="server" id="btnAddCustomerPoints" title="Search" type="button" class="btn btn-success" causesvalidation="False" width="50px" height="34px" onserverclick="btnAddCustomerPoints_ServerClick">
                        <i class="fa-credit-card"></i>
                        Save
                    </button>


                    <%--<asp:Button ID="Button1" runat="server" Text="Button" onserverclick="btnAddCustomerPoints_ServerClick" CausesValidation="false"/>--%>
                </div>
            </div>

            <br />


            <div class="card-footer small text-muted"></div>


        </div>


    </div>
    <br />
    <br />

</asp:Content>
