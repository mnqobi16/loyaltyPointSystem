<%@ Page Title="" EnableEventValidation="false" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddCustomerPointss.aspx.cs" Inherits="LoyatyPointSystem.Views.AddCustomerPoints" %>

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
                //startDate: new Date(),
                format: 'dd-mm-yyyy', 
                buttonImage: '/Images/calender.png',
                autoclose: true,
                orientation: 'auto bottom',

            });

        });
    </script>

    <!-- Example DataTables Card-->
    <div class="card mb-3">
        <div class="card-header">
            <i class="fa fa-table"></i>Add Loyalty Points
        </div>
        <div class="card-body">
            <div class="table-responsive">

                <asp:DetailsView ID="AddPointsCustomerDetailsView" Height="150px" Width="50%"  runat="server" CellPadding="10" CellSpacing="5" BorderStyle="None" CssClass="form-control" AutoGenerateRows="False"
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
            
        </div>
        

    </div>
    <br />
            <br />

            <div class="row">
                <div class="col-md-2">Receipt Date:</div>
                <div class="col-md-4">
                    <asp:TextBox ID="txtReieptDate" runat="server" PlaceHolder="Reiept Date" CssClass="form-control" Height="34px"></asp:TextBox>
                    <%--c --%>
                </div>
            </div>

            <div class="row">
                <div class="col-md-2">Receipt No:</div>
                <div class="col-md-4">
                    <asp:TextBox ID="txtRecieptNo" runat="server" PlaceHolder="Reciept No" CssClass="form-control" Height="34px"></asp:TextBox>
                    <%--                        <asp:TextBox id="" runat="server"  Text="7789839893"  placeholder="Receipt No" cssclass="form-control" width="250px" height="34px"></asp:TextBox>--%>
                </div>
            </div>

            <div class="row">
                <div class="col-md-2">Total Amount:</div>
                <div class="col-md-4">
                    <asp:TextBox ID="txtTotalAmount" runat="server" PlaceHolder="Total Amount" CssClass="form-control" Height="34px"></asp:TextBox>
                    <%--<asp:TextBox ID="txtTotalAmount" runat="server"></asp:TextBox>--%>


                    <%--                        <asp:TextBox id="" runat="server"  placeholder="Total Amount" cssclass="form-control" width="250px" height="34px"></asp:TextBox>--%>
                    <%--<asp:TextBox ID="txtIDNumber" runat="server" PlaceHolder="Enter ID Number" CssClass="form-control" Height="34px"></asp:TextBox>--%>
                </div>
            </div>
            <br />

            <div class="row" runat="server">
                <div class="col-md-2"></div>
                <div class="col-md-2">
                    <button runat="server" id="btnAddCustomerPoints" title="Search" type="button" class="btn btn-success btn-block" width="50px" height="34px" onserverclick="btnAddCustomerPoints_ServerClick">
                        <i class="fa-credit-card"></i>
                        Add Points
                    </button>
                </div>
            </div>

            <br />
    <div class="card-footer small text-muted"></div>


    <!-- confirm ReAllocate Region Modal-->
    <div class="modal fade" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel">ReAssign region?</h5>
                    <button class="close" type="button" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">×</span>
                    </button>
                </div>
                <div class="modal-body">
                    <%--body--%>

                    <asp:Image ID="Image1" runat="server" />


                </div>
                <div class="modal-footer">
                    <button class="btn btn-secondary" runat="server" type="button" data-dismiss="modal">Cancel</button>

                    <button class="btn btn-secondary" runat="server" type="button">ReAssign Region</button>
                    <%--<a class="btn btn-primary" href="login.html">Logout</a>--%>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
