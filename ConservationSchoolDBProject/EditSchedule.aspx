<%@ Page Language="C#" AutoEventWireup="True" MasterPageFile="~/Site.Master" CodeBehind="EditSchedule.aspx.cs" Inherits="EditSchedule" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


                               <%-- <div id="c">
                                    <div style="padding: 30px;">
                                        <div id="col_l">--%>
                                           
                                            <form id="editscheduleForm" runat="server">
                                                 <h1 style="float:right; position:relative; top:-20px;">
                                                <asp:Button ID="Button4" runat="server" CausesValidation="false" class="myButton" OnClick="Button4_Click" Text="Sign Out" /></h1>
                                                <h1><span style="font-weight: normal; text-decoration: underline">Update the Schedule and hit Save!</span></h1>
                                                        <asp:Literal ID="schedule" runat="server" />
                                                        <br />
        <p/>
           <strong>Select the class you would like to take:</strong><br />
                                                <p>
                                                    <asp:RadioButtonList ID="className" runat="server">
                                                        <asp:ListItem Value="Solar Power Basics" Selected="True">Solar Power Basics</asp:ListItem>
                                                        <asp:ListItem Value="Green Construction Techniques">Green Construction Techniques</asp:ListItem>
                                                        <asp:ListItem Value="Commercial Energy Management">Commercial Energy Management</asp:ListItem>
                                                        <asp:ListItem Value="Creating a Green Office">Creating a Green Office</asp:ListItem>
                                                        <asp:ListItem Value="Residential Energy Management">Residential Energy Management</asp:ListItem>
                                                    </asp:RadioButtonList>
                                                </p>
                                                <p>
                                                    <strong>Available Days and Times:</strong><br />
                                                    <asp:ListBox ID="days" runat="server" Rows="1">
                                                        <asp:ListItem Selected="True">Mondays and Wednesdays</asp:ListItem>
                                                        <asp:ListItem>Tuesdays and Thursdays</asp:ListItem>
                                                        <asp:ListItem>Wednesdays and Fridays</asp:ListItem>
                                                    </asp:ListBox>
                                                    <asp:ListBox ID="time" runat="server" Rows="1">
                                                        <asp:ListItem Selected="True">9 a.m. - 11 a.m.</asp:ListItem>
                                                        <asp:ListItem>1 p.m. - 3 p.m.</asp:ListItem>
                                                        <asp:ListItem>6 p.m. - 8 p.m.</asp:ListItem>
                                                    </asp:ListBox>
                                                    <p>
                                                        <asp:Button class="myButton" ID="register" runat="server" Text="Save" OnClick="register_Click" /></p>
                                            </form>
                                                <asp:Literal ID="results" runat="server"></asp:Literal>
                              <%--              </div>
                                        </div>
                                    </div>--%>

    

    </asp:Content>
