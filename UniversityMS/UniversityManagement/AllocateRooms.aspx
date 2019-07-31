<%@ Page Title="Allocate Rooms" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AllocateRooms.aspx.cs" Inherits="UniversityManagement.AllocateRooms" %>
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
            <asp:Label runat="server" CssClass="col-md-2 control-label" Font-Bold="true" Text="Courses" Font-Size="Medium"></asp:Label>
            <div class="col-md-5">
                <asp:DropDownList ID="CoursesDropDownList" runat="server" CssClass="form-control" AutoPostBack="true"></asp:DropDownList>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="CoursesDropDownList"
                    CssClass="text-danger" ErrorMessage="The Course field is required." />
            </div>
         </div>
         <div class="form-group">
            <asp:Label runat="server" CssClass="col-md-2 control-label" Font-Bold="true" Text="Rooms" Font-Size="Medium"></asp:Label>
            <div class="col-md-5">
                <asp:DropDownList ID="RoomsDropDownList" runat="server" CssClass="form-control" AutoPostBack="true"></asp:DropDownList>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="RoomsDropDownList"
                    CssClass="text-danger" ErrorMessage="The Rooms field is required." />
            </div>
         </div>
         <div class="form-group">
            <asp:Label runat="server" CssClass="col-md-2 control-label" Font-Bold="true" Text="Day" Font-Size="Medium"></asp:Label>
            <div class="col-md-5">
                <asp:DropDownList ID="DayDropDownList" runat="server" CssClass="form-control" AutoPostBack="true"></asp:DropDownList>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="DayDropDownList"
                    CssClass="text-danger" ErrorMessage="The Day field is required." />
            </div>
         </div>
        <div class="form-group">
            <asp:Label runat="server" CssClass="col-md-2 control-label" Font-Bold="true" Font-Size="Medium" Text="From"></asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtDateFrom" CssClass="form-control" Font-Bold="true" Font-Size="Medium" style="text-align:center" TextMode="Time" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtDateFrom"
                    CssClass="text-danger" ErrorMessage="The FromDate field is required." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" CssClass="col-md-2 control-label" Font-Bold="true" Font-Size="Medium" Text="To"></asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtDateTo" CssClass="form-control" Font-Bold="true" Font-Size="Medium" style="text-align:center" TextMode="Time" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtDateTo"
                    CssClass="text-danger" ErrorMessage="The EndDate field is required." />
            </div>
        </div>

        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <asp:Button runat="server" ID="AllocateRoomsButton" Text="Allocate" CssClass="btn btn-info" OnClick="AllocateRoomsButton_Click" />
            </div>
        </div>
    </div>
</asp:Content>
