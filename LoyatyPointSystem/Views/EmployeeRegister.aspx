<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmployeeRegister.aspx.cs" Inherits="LoyatyPointSystem.Views.EmployeeRegister" %>

<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <meta name="description" content="">
    <meta name="author" content="">
    <title>Loyalty Point System</title>
    <!-- Bootstrap core CSS-->
    <link href="../vendor/bootstrap/css/bootstrap.min.css" rel="stylesheet">
    <!-- Custom fonts for this template-->
    <link href="../vendor/font-awesome/css/font-awesome.min.css" rel="stylesheet" type="text/css">
    <!-- Custom styles for this template-->
    <link href="../css/sb-admin.css" rel="stylesheet">
</head>

<body class="bg-dark">
    <div class="container">
        <div class="card card-register mx-auto mt-5">
            <div class="card-header">Employee Register an Account</div>
            <div class="card-body">
                <form runat="server">
                    <div class="form-group">
                        <div class="form-row">
                            <div class="col-md-6">
                                <label for="exampleInputName">First name</label>
                                <asp:TextBox ID="txtName" runat="server" PlaceHolder="Enter Name" CssClass="form-control" Height="34px"></asp:TextBox>
                            </div>
                            <div class="col-md-6">
                                <label for="exampleInputLastName">Last name</label>
                                <asp:TextBox ID="txtSurname" runat="server" PlaceHolder="Enter Surname" CssClass="form-control" Height="34px"></asp:TextBox>
                            </div>
                        </div>
                    </div>

                    <div class="form-group">
                        <div class="form-row">
                            <div class="col-md-6">
                                <label for="InputIDNumber">ID Number</label>
                                <asp:TextBox ID="txtIDNumber" runat="server" PlaceHolder="Enter ID Number" CssClass="form-control" Height="34px"></asp:TextBox>
                            </div>
                            <div class="col-md-6">
                                <label for="ddlGender">Gender<span style="color: red">*</span></label>
                                <asp:DropDownList ID="ddlGender" runat="server" CssClass="form-control" Height="34px" AppendDataBoundItems="True">
                                    <asp:ListItem Selected="True" Value="0">--Select Gender--</asp:ListItem>
                                </asp:DropDownList>

                            </div>
                        </div>
                    </div>

                    <div class="form-group">
                        <div class="form-row">
                            <div class="col-md-6">
                                <label for="exampleInputEmail1">Cell Number</label>
                                <asp:TextBox ID="txtCellPhoneNO" runat="server" PlaceHolder="Enter Cell Number" CssClass="form-control" Height="34px"></asp:TextBox>
                            </div>
                            <div class="col-md-6">
                                <label for="ddlGender">Employee Role<span style="color: red">*</span></label>
                                <asp:DropDownList ID="ddlEmployeeRole" runat="server" CssClass="form-control" Height="34px" AppendDataBoundItems="True">
                                    <asp:ListItem Selected="True" Value="0">--Select Role--</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>

                    <div class="form-group">
                        <label for="exampleInputEmail1">Lounge Name</label>
                        <asp:DropDownList ID="ddlLoungeName" runat="server" CssClass="form-control" Height="34px" AppendDataBoundItems="True">
                            <asp:ListItem Selected="True" Value="0">--Select Lounge Name--</asp:ListItem>
                        </asp:DropDownList>
                    </div>

                    <div class="form-group">
                        <label for="exampleInputEmail1">Email address</label>
                        <asp:TextBox ID="txtEmail" runat="server" PlaceHolder="Enter Email Address" CssClass="form-control" Height="34px"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <div class="form-row">
                            <div class="col-md-6">
                                <label for="exampleInputPassword1">Password<span style="color: red">*</span></label>
                                <asp:TextBox ID="txtPassword" runat="server" PlaceHolder="Password(8 characters)" CssClass="form-control" Height="34px" TextMode="Password" onfocusout="ValidatePassword(this);" MaxLength="8"></asp:TextBox>

                            </div>
                            <div class="col-md-6">
                                <label for="exampleConfirmPassword">Confirm password<span style="color: red">*</span></label>
                                <asp:TextBox ID="txtConfirmPassword" runat="server" PlaceHolder="Confirm Password" CssClass="form-control" TextMode="Password" Height="34px" onfocusout="ValidatePassword(this);" MaxLength="8"></asp:TextBox>

                                <asp:CompareValidator ID="CompareValidator1" runat="server"
                                    ControlToValidate="txtConfirmPassword"
                                    CssClass="ValidationError"
                                    ControlToCompare="txtPassword"
                                    ErrorMessage="Password Must Match"
                                    ToolTip="Password must be the same" ForeColor="Red" />
                            </div>
                        </div>
                    </div>
                    <asp:Button ID="btnEmployeeRegister" runat="server" Text="Register" class="btn btn-primary btn-block" OnClick="btnRegisterEmployee_ServerClick" />
                    <%--<a class="btn btn-primary btn-block" href="login.html">Register</a>--%>

                    <a href="Home.aspx">Home Page</a>
                </form>
                <div class="text-center">
                    <%--<a class="d-block small mt-3" href="login.html">Login Page</a>
                    <a class="d-block small" href="forgot-password.html">Forgot Password?</a>--%>
                </div>
            </div>
        </div>
    </div>

    <!-- Bootstrap core JavaScript-->
    <script src="../vendor/jquery/jquery.min.js"></script>
    <script src="../vendor/bootstrap/js/bootstrap.bundle.min.js"></script>
    <!-- Core plugin JavaScript-->
    <script src="../vendor/jquery-easing/jquery.easing.min.js"></script>
</body>

</html>
