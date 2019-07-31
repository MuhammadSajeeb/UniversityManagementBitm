<%@ Page Title="Student registration" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="StudentSetup.aspx.cs" Inherits="UniversityManagement.StudentSetup" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
   <br/>
 <h4>Students Registration</h4>
    <p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>

    <div class="form-horizontal">
        <hr />
        <asp:ValidationSummary runat="server" CssClass="text-danger" />
        <div class="form-group">
            <asp:Label runat="server" CssClass="col-md-2 control-label" Font-Bold="true" Text="Name" Font-Size="Medium"></asp:Label>
            
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtStudentName" CssClass="form-control" Font-Bold="true" Font-Size="Medium" style="text-align:center"/>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtStudentName"
                    CssClass="text-danger" ErrorMessage="The Name field is required." />
                <asp:HiddenField ID="IdHiddenField" runat="server" />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" CssClass="col-md-2 control-label" Font-Bold="true" Font-Size="Medium" Text="Email"></asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtStudentEmail" CssClass="form-control" TextMode="Email" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtStudentEmail"
                    CssClass="text-danger" ErrorMessage="The Email field is required." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" CssClass="col-md-2 control-label" Font-Bold="true" Font-Size="Medium" Text="Contact No"></asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtContactNo" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtContactNo"
                    CssClass="text-danger" ErrorMessage="The Contact field is required." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" CssClass="col-md-2 control-label" Font-Bold="true" Font-Size="Medium" Text="Address"></asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtAddress" CssClass="form-control" TextMode="MultiLine" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtAddress"
                    CssClass="text-danger" ErrorMessage="The Address field is required." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" CssClass="col-md-2 control-label" Font-Bold="true" Text="Departments" Font-Size="Medium"></asp:Label>
            <div class="col-md-5">
                <asp:DropDownList ID="DepartmentDropDownList" runat="server" CssClass="form-control" AutoPostBack="true"></asp:DropDownList>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="DepartmentDropDownList"
                    CssClass="text-danger" ErrorMessage="The Department field is required." />
            </div>
         </div>
        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <asp:Button runat="server" ID="StudentRegisterButton" Text="Register" CssClass="btn btn-info" OnClick="StudentRegisterButton_Click" />
            </div>
        </div>
        <div class="form-group">
            <div class="col-md-offset-1 col-md-10">
                  <a class="nav-link" href="ViewCourses.aspx">Enroll Courses</a>
            </div>
        </div>
    </div>
</asp:Content>
