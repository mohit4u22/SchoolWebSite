<%@ Page Language="C#" AutoEventWireup="True" MasterPageFile="~/Site.Master" CodeBehind="ReviewSchedule2.aspx.cs" Inherits="ReviewSchedule2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

                                <%--<div id="c">
                                    <div style="padding: 30px;">
                                        <div id="col_l">--%>
                                           
                                            <form id="scheduleForm" runat="server">
                                                <div style="float:left; position:relative; top:-20px;">
                                               
                                                   <asp:Button ID="Button1" runat="server" CausesValidation="false" class="myButton" OnClick="Button1_Click" Text="Back" /></div>
                                                <div style="float:right; position:relative; top:-20px;"><asp:Button ID="Button4" runat="server" CausesValidation="false" class="myButton" OnClick="Button4_Click" Text="Sign Out" />
                                                    </div>
                                                <h1><span style="font-weight: normal; text-decoration: underline">Current Schedule</span></h1>
                                            <asp:Literal ID="schedule" runat="server" />
                                                <br />
                                                <br />
                                                <asp:Button ID="Button5" CausesValidation="false" class="myButton" runat="server" OnClick="Button5_Click" Text="Register for More" />
                                                <br />
                                                <br />
                                            </form>
                                   <%--         </div>
                                        </div>
                                    </div>--%>

      
        </div>
</asp:Content>