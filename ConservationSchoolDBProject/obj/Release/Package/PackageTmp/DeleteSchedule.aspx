<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="True" CodeBehind="DeleteSchedule.aspx.cs" Inherits="DeleteSchedule" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


                               <%-- <div id="c">
                                    <div style="padding: 30px;">
                                        <div id="col_l">--%>
                                         
                                            <form id="scheduleForm" runat="server">
                                           
                                                <div style="float:left; position:relative; top:-20px;">
                                               
                                                   <asp:Button ID="ButtonBack" runat="server" CausesValidation="false" class="myButton" OnClick="ButtonBack_Click" Text="Back" /></div>
                                                <div style="float:right; position:relative; top:-20px;">
                                                    <asp:Button ID="Button5" runat="server" CausesValidation="false" class="myButton" OnClick="Button5_Click" Text="Edit Schedule" />
                                                    <asp:Button ID="Button4" runat="server" CausesValidation="false" class="myButton" OnClick="Button4_Click" Text="Sign Out" />
                                                    </div>
                                                <asp:Panel runat="server" ID="Panel2"><h2><span style="font-weight: normal; text-decoration: underline">Are you sure you want to delete the following schedule?</span></h2>
                                                        <asp:Literal ID="schedule" runat="server" />
        <p/>
            <asp:Button class="myButton" ID="yesButton" runat="server" Text="Yes" OnClick="yesButton_Click" />&nbsp;
            <asp:Button class="myButton" ID="noButton" runat="server" Text="No" OnClick="noButton_Click" /></asp:Panel>
                                            </form>
                                                <asp:Literal ID="results" runat="server"></asp:Literal>
                                 <%--           </div>
                                        </div>
                                    </div>--%>

     


</asp:Content>
