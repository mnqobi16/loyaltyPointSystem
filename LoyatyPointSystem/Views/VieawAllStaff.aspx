<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="VieawAllStaff.aspx.cs" Inherits="LoyatyPointSystem.Views.VieawAllStaff" %>
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
          <i class="fa fa-table"></i> Staff</div>
        <div class="card-body">
          <div class="table-responsive">
          
              <asp:GridView ID="gvStaff" CssClass="gvdatatable table table-striped table-bordered" runat="server" ShowHeaderWhenEmpty="true" OnPreRender="gvStaff_PreRender"  AutoGenerateColumns="false" DataKeyNames="ID">
                               
                                <Columns>
                                    <asp:BoundField DataField="ID" HeaderText="ID" SortExpression="ID" HeaderStyle-CssClass="hidden" ItemStyle-CssClass="hidden" InsertVisible="False" ReadOnly="True"></asp:BoundField>
                                    
                                    <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                                    <asp:BoundField DataField="Surname" HeaderText="Surname" SortExpression="Surname" />
                                    <asp:BoundField DataField="ID_No" HeaderText="ID No" SortExpression="ID_No" />
                                    <asp:BoundField DataField="GenderName" HeaderText="Gender" SortExpression="GenderName"/>
                                    <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email"/>
                                    <asp:BoundField DataField="CellPhone" HeaderText="CellPhone" SortExpression="CellPhone" />
                                    <asp:BoundField DataField="RoleName" HeaderText="RoleName" SortExpression="RoleName"/>
                                    <asp:BoundField DataField="Employee_No" HeaderText="Employee_No" SortExpression="CellPhone" />
                                    <asp:BoundField DataField="Username" HeaderText="Username" SortExpression="Username"/>
                                    <%--<asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:Button ID="btnSelect" runat="server" Visible="true" Width="60" CssClass="btn btn-primary form-control" BorderColor="#0099FF" Text="Select" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" CommandName="Select" />
                                        </ItemTemplate>
                                        <ItemStyle Width="25px" />
                                    </asp:TemplateField>--%>
                                </Columns>
                                <EmptyDataTemplate>No Record Available</EmptyDataTemplate>
                            </asp:GridView>

          </div>
        </div>
        <div class="card-footer small text-muted">Updated yesterday at 11:59 PM</div>
      </div>

</asp:Content>
