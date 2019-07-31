<%@ Page Title="Courses" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CourseSetup.aspx.cs" Inherits="UniversityManagement.CourseSetup" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br/>
 <h4>Add a new Course</h4>
    <p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>

    <div class="form-horizontal">
        <hr />
        <asp:ValidationSummary runat="server" CssClass="text-danger" />
        <div class="form-group">
            <asp:Label runat="server" CssClass="col-md-2 control-label" Font-Bold="true" Text="Course Code" Font-Size="Medium"></asp:Label>
            
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtCourseCode" CssClass="form-control" Font-Bold="true" Font-Size="Medium" style="text-align:center"/>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtCourseCode"
                    CssClass="text-danger" ErrorMessage="The Code field is required." />
                <asp:HiddenField ID="IdHiddenField" runat="server" />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" CssClass="col-md-2 control-label" Font-Bold="true" Font-Size="Medium" Text="Course Name"></asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtCourseName" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtCourseName"
                    CssClass="text-danger" ErrorMessage="The Name field is required." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" CssClass="col-md-2 control-label" Font-Bold="true" Font-Size="Medium" Text="Credit"></asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtCredit" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtCredit"
                    CssClass="text-danger" ErrorMessage="The Credit field is required." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" CssClass="col-md-2 control-label" Font-Bold="true" Font-Size="Medium" Text="Discription"></asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtDescription" CssClass="form-control" TextMode="MultiLine" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtDescription"
                    CssClass="text-danger" ErrorMessage="The Description field is required." />
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
            <asp:Label runat="server" CssClass="col-md-2 control-label" Font-Bold="true" Text="Semesters" Font-Size="Medium"></asp:Label>
            <div class="col-md-5">
                <asp:DropDownList ID="SemestersDropDownList" runat="server" CssClass="form-control" AutoPostBack="true"></asp:DropDownList>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="SemestersDropDownList"
                    CssClass="text-danger" ErrorMessage="The Semester field is required." />
            </div>
         </div>
        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <asp:Button runat="server" ID="CourseSaveButton" Text="Save" CssClass="btn btn-info" OnClick="CourseSaveButton_Click" />
            </div>
        </div>
        <div class="form-group">
            <div class="col-md-offset-1 col-md-10">
                  <a class="nav-link" href="ViewCourses.aspx">Back to List</a>
            </div>
        </div>
    </div>
</asp:Content>
