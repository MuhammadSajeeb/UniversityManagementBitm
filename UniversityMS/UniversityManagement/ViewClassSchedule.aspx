<%@ Page Title="Class Shedule" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewClassSchedule.aspx.cs" Inherits="UniversityManagement.ViewClassSchedule" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br/>
    <h4> View Class Shedule</h4>
    <div class="form-horizontal">
        <hr />
        <div class="form-group">
            <asp:Label runat="server" CssClass="col-md-offset-1 col-md-3 control-label" Font-Bold="true" Text="Departments" Font-Size="Medium"></asp:Label>
            <div class="col-md-5">
                <asp:DropDownList ID="DepartmentDropDownList" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="DepartmentDropDownList_SelectedIndexChanged"></asp:DropDownList>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="DepartmentDropDownList"
                    CssClass="text-danger" ErrorMessage="The Category field is required." />
            </div>
         </div>
        <hr />
         <div class="form-group">
            <div class="col-md-offset-1 col-md-10">
              <asp:GridView ID="ClassSheduleGridView" runat="server" Width="100%" CssClass="table table-striped table-bordered table-hover" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="10" ForeColor="Black" GridLines="Horizontal" AllowPaging="True" PageSize="2" CellSpacing="10" OnPageIndexChanging="ClassSheduleGridView_PageIndexChanging">
                <Columns>
                   <asp:TemplateField HeaderText = "Serial No" ItemStyle-Width="130">
                     <ItemTemplate>
                         <asp:Label ID="lblSerialNo" Text='<%# Container.DataItemIndex + 1 %>' runat="server" />
                     </ItemTemplate>
                         <ItemStyle Width="130px">
                         </ItemStyle>
                   </asp:TemplateField>
                     <asp:BoundField DataField="CourseCode" HeaderText="Course Code" />
                     <asp:BoundField DataField="CourseName" HeaderText="Course Name/Title" />
                    <asp:BoundField DataField="ScheduleInfo" HeaderText="Class Shedule Informations" />
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
