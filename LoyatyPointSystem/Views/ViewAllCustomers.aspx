<%@ Page Title="" Language="C#" EnableEventValidation="false" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewAllCustomers.aspx.cs" Inherits="LoyatyPointSystem.Views.ViewAllCustomers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <meta name="description" content="">
    <meta name="author" content="">

    <!-- Bootstrap core CSS-->
    <link href="vendor/bootstrap/css/bootstrap.min.css" rel="stylesheet">
    <!-- Custom fonts for this template-->
    <link href="vendor/font-awesome/css/font-awesome.min.css" rel="stylesheet" type="text/css">
    <!-- Page level plugin CSS-->
    <link href="vendor/datatables/dataTables.bootstrap4.css" rel="stylesheet">
    <!-- Custom styles for this template-->
    <link href="css/sb-admin.css" rel="stylesheet">

    <script type="text/javascript">
        function ResetScrollPosition() {
            setTimeout("window.scrollTo(0,0)", 0);
        }
        function openAddModal() {
            $('#AddPointModal').modal('show');

        }
        $(function () {
            $(".OpenAddPointsModal").click(function () {
                openAddModal();
            });
        });

        function showmodalpopup() {
            $("#AddPointModal").dialog({
                //title: "jQuery Popup from Server Side",
                width: 430,
                height: 250,
                modal: true,
                buttons: { Close: function () { $(this).dialog('close'); } }
            });
        };
    </script>



    <script type="text/javascript">
        $(document).ready(function () {
            $('.gvdatatable').dataTable({
                dom: 'Bfrtip',
                "pageLength": 8,
                responsive: true,
                "language": {
                    "search": "Filter records:"
                },
                buttons: [
                    //'excelHtml5',
                    // 'pdfHtml5'
                ],


                columnDefs: [
                    {
                        "targets": [0],
                        "visible": false,
                        "orderable": false,
                        "searchable": false

                    },
                ]

            });
        });
    </script>


    <!-- Example DataTables Card-->
    <div class="card mb-3">
        <div class="card-header">
            <i class="fa fa-table"></i>Customers
        </div>
        <div class="card-body">
            <div class="table-responsive">

                <asp:GridView ID="gvCustomers" CssClass="data gvdatatable table table-striped table-bordered" runat="server" ShowHeaderWhenEmpty="true" AutoGenerateColumns="false" DataKeyNames="ID" OnPreRender="gvCustomers_PreRender" OnRowCommand="gvCustomers_Commands">

                    <Columns>
                        <asp:BoundField DataField="ID" HeaderText="ID" SortExpression="ID" HeaderStyle-CssClass="hidden" ItemStyle-CssClass="hidden" InsertVisible="False" ReadOnly="True"></asp:BoundField>
                        <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                        <asp:BoundField DataField="Surname" HeaderText="Surname" SortExpression="Surname" />
                        <asp:BoundField DataField="ID_No" HeaderText="ID No" SortExpression="ID_No" />
                        <asp:BoundField DataField="GenderName" HeaderText="Gender" SortExpression="GenderName" />
                        <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
                        <asp:BoundField DataField="Cell_No" HeaderText="Cell No" SortExpression="Cell_No" HeaderStyle-CssClass="hidden" ItemStyle-CssClass="hidden" />
                        <asp:BoundField DataField="DateCreated" HeaderText="Join Date" SortExpression="DateCreated" HeaderStyle-CssClass="hidden" ItemStyle-CssClass="hidden" DataFormatString="{0:yyyy-MM-dd}" />

                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="btnAddPoints" runat="server" Visible="true" Width="60" CssClass="OpenAddPointsModal" BorderColor="#0099FF" Text="Add" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" CommandName="Add" />

                            </ItemTemplate>
                            <HeaderTemplate>
                                Add Points
                            </HeaderTemplate>
                            <%--<ItemStyle Width="25px" />--%>
                        </asp:TemplateField>

                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="btnRedeemPoints" runat="server" Visible="true" Width="60" CssClass="OpenAddPointsModal" BorderColor="#0099FF" Text="Redeem" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" CommandName="Redeem" />

                                <%--<asp:Button ID="" runat="server" Visible="true" Width="60" CssClass="btn btn-primary form-control" BorderColor="#0099FF" Text="" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" CommandName="" />--%>
                            </ItemTemplate>
                            <HeaderTemplate>
                                Redeem Points
                            </HeaderTemplate>
                            <%--<ItemStyle Width="25px" />--%>
                        </asp:TemplateField>
                    </Columns>
                    <EmptyDataTemplate>No Record Available</EmptyDataTemplate>
                </asp:GridView>

            </div>
        </div>
        <div class="card-footer small text-muted"></div>
    </div>



    <!-- Add Points Modal-->
    <div class="modal fade" id="AddPointModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="AddPointModalLabel">Add Points</h5>
                    <button class="close" type="button" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">×</span>
                    </button>
                </div>
                <div class="modal-body">

                    <asp:DetailsView ID="AddPointsCustomerDetailsView" runat="server" AutoGenerateRows="False"
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
                                HeaderText="ID_No" SortExpression="ID_No" />

                            <asp:BoundField DataField="GenderName" HeaderText="GenderName"
                                SortExpression="GenderName" />

                            <asp:BoundField DataField="Email"
                                HeaderText="Email" SortExpression="Email" />

                            <asp:BoundField DataField="Cell_No"
                                HeaderText="Cell_No" SortExpression="Cell_No" />

                        </Fields>
                    </asp:DetailsView>


                </div>
                <div class="modal-footer">
                    <button class="btn btn-secondary" type="button" data-dismiss="modal">Cancel</button>
                    <a class="btn btn-primary" href="login.html">Logout</a>
                </div>
            </div>
        </div>
    </div>


    <!-- Redeem Points Modal-->
    <div class="modal fade" id="RedeemPointsModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel">Redeem Points</h5>
                    <button class="close" type="button" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">×</span>
                    </button>
                </div>
                <div class="modal-body">
                </div>
                <div class="modal-footer">
                    <button class="btn btn-secondary" type="button" data-dismiss="modal">Cancel</button>
                    <a class="btn btn-primary" href="login.html">Logout</a>
                </div>
            </div>
        </div>
    </div>
</asp:Content>


