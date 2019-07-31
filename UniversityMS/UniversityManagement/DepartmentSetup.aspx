<%@ Page Title="Department" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DepartmentSetup.aspx.cs" Inherits="UniversityManagement.DepartmentSetup" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br/>
    <br/>
    <h4>Create a new Department</h4>
    <p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>

    <div class="form-horizontal">
        <hr />
        <asp:ValidationSummary runat="server" CssClass="text-danger" />
        <div class="form-group">
            <asp:Label runat="server" CssClass="col-md-2 control-label" Font-Bold="true" Text="Department Code" Font-Size="Medium"></asp:Label>
            
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtDepartmentCode" CssClass="form-control" Font-Bold="true" Font-Size="Medium" style="text-align:center"/>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtDepartmentCode"
                    CssClass="text-danger" ErrorMessage="The Code field is required." />
                <asp:HiddenField ID="IdHiddenField" runat="server" />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" CssClass="col-md-2 control-label" Font-Bold="true" Font-Size="Medium" Text="Department Name"></asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtDepartmentName" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtDepartmentName"
                    CssClass="text-danger" ErrorMessage="The Name field is required." />
            </div>
        </div>
        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <asp:Button runat="server" ID="DepartmentSaveButton" Text="Save" CssClass="btn btn-info" OnClick="DepartmentSaveButton_Click" />
                <asp:Button runat="server" ID="DepartmentDeleteButton" Text="Delete" CssClass="btn btn-info" OnClick="DepartmentDeleteButton_Click" />
            </div>
        </div>
        <div class="form-group">
            <div class="col-md-offset-1 col-md-10">
                  <a class="nav-link" href="ViewDepartments.aspx">Back to List</a>
            </div>
        </div>
    </div>
    

</asp:Content>
