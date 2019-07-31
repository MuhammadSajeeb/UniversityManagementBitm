<%@ Page Title="Enroll Courses" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EnrollCourses.aspx.cs" Inherits="UniversityManagement.EnrollCourses" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br/>
 <h4>Enroll Courses</h4>
    <p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>

    <div class="form-horizontal">
        <hr />
        <asp:ValidationSummary runat="server" CssClass="text-danger" />
          <div class="form-group">
            <asp:Label runat="server" CssClass="col-md-2 control-label" Font-Bold="true" Text="Departments" Font-Size="Medium"></asp:Label>
            <div class="col-md-5">
                <asp:DropDownList ID="DepartmentDropDownList" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="DepartmentDropDownList_SelectedIndexChanged"></asp:DropDownList>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="DepartmentDropDownList"
                    CssClass="text-danger" ErrorMessage="The Department field is required." />
            </div>
         </div>
         <div class="form-group">
            <asp:Label runat="server" CssClass="col-md-2 control-label" Font-Bold="true" Text="Student Reg No " Font-Size="Medium"></asp:Label>
            <div class="col-md-5">
                <asp:DropDownList ID="StudentRegNoDropDownList" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="StudentRegNoDropDownList_SelectedIndexChanged"></asp:DropDownList>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="StudentRegNoDropDownList"
                    CssClass="text-danger" ErrorMessage="The Department field is required." />
            </div>
         </div>
        <div class="form-group">
            <asp:Label runat="server" CssClass="col-md-2 control-label" Font-Bold="true" Text="Name" Font-Size="Medium"></asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtStudentName" CssClass="form-control" ReadOnly="true" Font-Bold="true" Font-Size="Medium" style="text-align:center"/>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtStudentName"
                    CssClass="text-danger" ErrorMessage="The Name field is required." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" CssClass="col-md-2 control-label" Font-Bold="true" Text="Email" Font-Size="Medium"></asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtStudentEmail" CssClass="form-control" ReadOnly="true" Font-Bold="true" Font-Size="Medium" style="text-align:center"/>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtStudentEmail"
                    CssClass="text-danger" ErrorMessage="The Name field is required." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" CssClass="col-md-2 control-label" Font-Bold="true" Text="Courses" Font-Size="Medium"></asp:Label>
            <div class="col-md-5">
                <asp:DropDownList ID="CoursesDropDownList" runat="server" CssClass="form-control" AutoPostBack="true"></asp:DropDownList>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="CoursesDropDownList"
                    CssClass="text-danger" ErrorMessage="The Courses field is required." />
            </div>
         </div>
        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <asp:Button runat="server" ID="EnrollCoursesButton" Text="Enroll" CssClass="btn btn-info" OnClick="EnrollCoursesButton_Click"/>
            </div>
        </div>
    </div>
</asp:Content>
