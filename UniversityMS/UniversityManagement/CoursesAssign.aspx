<%@ Page Title="Courses Assign" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CoursesAssign.aspx.cs" Inherits="UniversityManagement.CoursesAssign" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br/>
 <h4>Courses Assign</h4>
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
            <asp:Label runat="server" CssClass="col-md-2 control-label" Font-Bold="true" Text="Teachers" Font-Size="Medium"></asp:Label>
            <div class="col-md-5">
                <asp:DropDownList ID="TeacherDropDownList" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="TeacherDropDownList_SelectedIndexChanged"></asp:DropDownList>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="TeacherDropDownList"
                    CssClass="text-danger" ErrorMessage="The Teacher field is required." />
            </div>
         </div>
        <div class="form-group">
            <asp:Label runat="server" CssClass="col-md-2 control-label" Font-Bold="true" Text="Credit to be taken" Font-Size="Medium"></asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtCreditTaken" CssClass="form-control" Font-Bold="true" Font-Size="Medium" style="text-align:center" ReadOnly="true"/>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtCreditTaken"
                    CssClass="text-danger" ErrorMessage="The Name field is required." />
                <asp:HiddenField ID="IdHiddenField" runat="server" />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" CssClass="col-md-2 control-label" Font-Bold="true" Font-Size="Medium" Text="Remaining Credit"></asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtRemainingCredit" CssClass="form-control" Font-Bold="true" Font-Size="Medium" style="text-align:center" ReadOnly="true" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtRemainingCredit"
                    CssClass="text-danger" ErrorMessage="The Remaing field is required." />
            </div>
        </div>
         <div class="form-group">
            <asp:Label runat="server" CssClass="col-md-2 control-label" Font-Bold="true" Text="Courses" Font-Size="Medium"></asp:Label>
            <div class="col-md-5">
                <asp:DropDownList ID="CourseDropDownList" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="CourseDropDownList_SelectedIndexChanged"></asp:DropDownList>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="CourseDropDownList"
                    CssClass="text-danger" ErrorMessage="The Courses field is required." />
            </div>
         </div>
        <div class="form-group">
            <asp:Label runat="server" CssClass="col-md-2 control-label" Font-Bold="true" Font-Size="Medium" Text="Course Name"></asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtCourseName" CssClass="form-control" ReadOnly="true" Font-Bold="true" Font-Size="Medium" style="text-align:center" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtCourseName"
                    CssClass="text-danger" ErrorMessage="The Name field is required." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" CssClass="col-md-2 control-label" Font-Bold="true" Font-Size="Medium" Text="Course Credit"></asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtCourseCredit" CssClass="form-control" ReadOnly="true" Font-Bold="true" Font-Size="Medium" style="text-align:center" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtCourseName"
                    CssClass="text-danger" ErrorMessage="The Credit field is required." />
            </div>
        </div>

        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <asp:Button runat="server" ID="CourseAssignButton" Text="Assign" CssClass="btn btn-info" OnClick="CourseAssignButton_Click" />
            </div>
        </div>
    </div>
</asp:Content>
