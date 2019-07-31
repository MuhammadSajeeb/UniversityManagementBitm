<%@ Page Title="View Departments" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewDepartments.aspx.cs" Inherits="UniversityManagement.ViewDepartments" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
  <br/>
    <br/>
    <h4> View Departments</h4>
       <div class="form-group">
            <div class="col-md-10">
                  <a class="nav-link" href="DepartmentSetup.aspx">Create New</a>
            </div>
       </div>
    <br/>
    <div class="form-horizontal">
        <hr />
         <div class="form-group">
            <div class="col-md-offset-1 col-md-10">
              <asp:GridView ID="DepartmentGridView" runat="server" Width="100%" CssClass="table table-striped table-bordered table-hover" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="10" ForeColor="Black" GridLines="Horizontal" AllowPaging="True" PageSize="2" CellSpacing="10" OnSelectedIndexChanged="DepartmentGridView_SelectedIndexChanged" OnPageIndexChanging="DepartmentGridView_PageIndexChanging">
                <Columns>
                   <asp:TemplateField HeaderText = "Serial No" ItemStyle-Width="130">
                     <ItemTemplate>
                         <asp:Label ID="lblSerialNo" Text='<%# Container.DataItemIndex + 1 %>' runat="server" />
                     </ItemTemplate>
                         <ItemStyle Width="130px">
                         </ItemStyle>
                   </asp:TemplateField>
                     <asp:BoundField DataField="DeptCode" HeaderText="Department Code" />
                     <asp:BoundField DataField="DeptName" HeaderText="Department Name" />
                     <asp:CommandField HeaderText="Action" SelectText="Details" ShowSelectButton="True" >
                    <ItemStyle ForeColor="#CC0000" />
                    </asp:CommandField>
                </Columns>
                  <PagerStyle Font-Bold="true" Font-Size="Small" ForeColor="#3399FF" />
               </asp:GridView>
            </div>
        </div>
    </div>
    <link href="Content/GridviewStyleSheet.css" rel="stylesheet" />
 
</asp:Content>
