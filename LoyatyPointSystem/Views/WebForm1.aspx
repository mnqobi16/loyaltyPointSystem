<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="LoyatyPointSystem.Views.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

        <!-- Example DataTables Card-->
    <div class="card mb-3">
        <div class="card-header">
            <i class="fa fa-table"></i>Add Loyalty Points
        </div>
        <div class="card-body">
            <div class="table-responsive">

                <asp:detailsview id="AddPointsCustomerDetailsView" runat="server" cellpadding="10" cellspacing="5" borderstyle="None" cssclass="form-control" autogeneraterows="False"
                    datakeynames="ID"
                    enableviewstate="False">
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

                </asp:detailsview>
                <br />
                <br />

                <div class="row">
                    <div class="col-md-2">Receipt Date:</div>
                    <div class="col-md-4">
                        <asp:textbox id="txtReieptDate" runat="server" onfocusout="SetButtonSearch()" placeholder="Receipt Date" cssclass="form-control date-picker glyphicon-time" width="250px" height="34px"></asp:textbox>
                    </div>
                </div>

                <div class="row">
                    <div class="col-md-2">Receipt No:</div>
                    <div class="col-md-4">
                        <asp:textbox id="txtRecieptNo" onfocusout="SetButtonSearch()" runat="server" onkeypress="allowAlphaNumericUnit(event)" placeholder="Receipt No" cssclass="form-control" width="250px" height="34px"></asp:textbox>
                    </div>
                </div>

                <div class="row">
                    <div class="col-md-2">Total Amount:</div>
                    <div class="col-md-4">
                        <asp:textbox id="txtTotalAmount" runat="server" onfocusout="SetButtonSearch()" placeholder="Total Amount" cssclass="form-control" width="250px" height="34px"></asp:textbox>
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
            </div>
        </div>
        <div class="card-footer small text-muted"></div>
    </div>

</asp:Content>
