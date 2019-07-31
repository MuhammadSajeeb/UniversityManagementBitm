<%@ Page Title="View result" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewResult.aspx.cs" Inherits="UniversityManagement.ViewResult" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
  <br/>
 <h4>Student Result</h4>
    <p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>

    <div class="form-horizontal">
        <hr />
        <asp:ValidationSummary runat="server" CssClass="text-danger" />
          <div class="form-group">
            <asp:Label runat="server" CssClass="col-md-2 control-label" Font-Bold="true" Text="Departments" Font-Size="Medium"></asp:Label>
            <div class="col-md-5">
                <asp:DropDownList ID="DepartmentsDropDownList" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="DepartmentDropDownList_SelectedIndexChanged"></asp:DropDownList>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="DepartmentsDropDownList"
                    CssClass="text-danger" ErrorMessage="The Department field is required." />
            </div>
         </div>
         <div class="form-group">
            <asp:Label runat="server" CssClass="col-md-2 control-label" Font-Bold="true" Text="Student Reg No " Font-Size="Medium"></asp:Label>
            <div class="col-md-5">
                <asp:DropDownList ID="StudentsRegNoDropDownList" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="StudentRegNoDropDownList_SelectedIndexChanged"></asp:DropDownList>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="StudentsRegNoDropDownList"
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
            <div class="col-md-offset-2 col-md-10">
                <asp:Button runat="server" ID="PdfButton" Text="Pdf" CssClass="btn btn-info" OnClick="PdfButton_Click" />
            </div>
        </div>
        <hr />
         <div class="form-group">
            <div class="col-md-offset-1 col-md-10">
              <asp:GridView ID="ResultGridView" runat="server" Width="100%" CssClass="table table-striped table-bordered table-hover" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="10" ForeColor="Black" GridLines="Horizontal" AllowPaging="True" PageSize="2" CellSpacing="10">
                <Columns>
                    <asp:BoundField DataField="StudentRegNo" HeaderText="Registration No" />
                    <asp:BoundField DataField="StudentName" HeaderText="Student Name" />
                     <asp:BoundField DataField="CourseCode" HeaderText="Course Code" />
                     <asp:BoundField DataField="CourseName" HeaderText="Course Name" />
                    <asp:BoundField DataField="GradeName" HeaderText="Grades" />
                </Columns>
                  <PagerStyle Font-Bold="true" Font-Size="Small" ForeColor="#3399FF" />
               </asp:GridView>
            </div>
        </div>
   </div>
    <link href="Content/GridviewStyleSheet.css" rel="stylesheet" />
</asp:Content>
