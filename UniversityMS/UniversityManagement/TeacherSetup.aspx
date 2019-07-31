<%@ Page Title="Teachers" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TeacherSetup.aspx.cs" Inherits="UniversityManagement.TeacherSetup" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br/>
 <h4>Add a new Teacher</h4>
    <p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>

    <div class="form-horizontal">
        <hr />
        <asp:ValidationSummary runat="server" CssClass="text-danger" />
        <div class="form-group">
            <asp:Label runat="server" CssClass="col-md-2 control-label" Font-Bold="true" Text="Name" Font-Size="Medium"></asp:Label>
            
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtTeacherName" CssClass="form-control" Font-Bold="true" Font-Size="Medium" style="text-align:center"/>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtTeacherName"
                    CssClass="text-danger" ErrorMessage="The Name field is required." />
                <asp:HiddenField ID="IdHiddenField" runat="server" />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" CssClass="col-md-2 control-label" Font-Bold="true" Font-Size="Medium" Text="Address"></asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtTeacherAddress" CssClass="form-control" TextMode="MultiLine" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtTeacherAddress"
                    CssClass="text-danger" ErrorMessage="The Address field is required." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" CssClass="col-md-2 control-label" Font-Bold="true" Font-Size="Medium" Text="Email"></asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtTeacherEmail" CssClass="form-control" TextMode="Email" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtTeacherEmail"
                    CssClass="text-danger" ErrorMessage="The Email field is required." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" CssClass="col-md-2 control-label" Font-Bold="true" Font-Size="Medium" Text="Contact No"></asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtContactNo" CssClass="form-control" TextMode="Phone" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtContactNo"
                    CssClass="text-danger" ErrorMessage="The Contact field is required." />
            </div>
        </div>
         <div class="form-group">
            <asp:Label runat="server" CssClass="col-md-2 control-label" Font-Bold="true" Text="Designations" Font-Size="Medium"></asp:Label>
            <div class="col-md-5">
                <asp:DropDownList ID="DesignationDropDownList" runat="server" CssClass="form-control" AutoPostBack="true"></asp:DropDownList>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="DesignationDropDownList"
                    CssClass="text-danger" ErrorMessage="The Designation field is required." />
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
            <asp:Label runat="server" CssClass="col-md-2 control-label" Font-Bold="true" Font-Size="Medium" Text="Credit to be taken"></asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtCreditTaken" CssClass="form-control" TextMode="Number" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtCreditTaken"
                    CssClass="text-danger" ErrorMessage="The Email field is required." />
            </div>
        </div>
        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <asp:Button runat="server" ID="TeacherSaveButton" Text="Save" CssClass="btn btn-info" OnClick="TeacherSaveButton_Click" />
            </div>
        </div>
        <div class="form-group">
            <div class="col-md-offset-1 col-md-10">
                  <a class="nav-link" href="CoursesAssign.aspx">Course Assign to Teacher</a>
            </div>
        </div>
    </div>
</asp:Content>
