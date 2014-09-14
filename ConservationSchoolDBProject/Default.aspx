<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="True" CodeBehind="Default.aspx.cs" Inherits="_Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


   
            <%--<div style="background: url(images/lt.gif) no-repeat 0px 0px;">
                <div style="background: url(images/lb.gif) no-repeat 0px 100%; padding-left: 50px;">
                    <div style="background: url(images/r.gif) repeat-y 100% 0px;">
                        <div style="background: url(images/rt.gif) no-repeat 100% 0px;">
                            <div style="background: url(images/rb.gif) no-repeat 100% 100%; padding-right: 50px;">--%>
                            <%--    <div id="c">
                                    <div style="padding: 30px;">
                                        <h1>
                                            <img src="images/h_well.gif" width="69" height="29" border="0" alt="" /></h1>
                                        <img src="images/pic1.jpg" width="137" height="91" border="0" alt="" align="left"
                                            style="margin-right: 10px;" />--%>
   
                                        <form id="form1" runat="server" defaultfocus="studentID" defaultbutton="Button1">
                                             <div style="float:left">
                                                <asp:Button ID="Button4" runat="server" CausesValidation="false" class="myButton" OnClick="Button4_Click" Text="Sign Out" /></div>
                                             <div style="float:right">
                                                <asp:Button class="myButton" ID="Button2" CausesValidation="false" onclick="Button2_Click" runat="server" Text="New Students-Sign Up" /></div>

                                                <center><h1><span style="font-weight: normal; text-decoration: underline">
                                        Welcome Folks !</span></h1></center>
                                            <h1 style="float:right">&nbsp;</h1>
                                             <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
 
                                          
                                        <p>
                                            Welcome to Illinois Public school! We offer a variety
                                            of energy efficiency classes for home owners and professional contractors. The goal
                                            of our classes is to promote green technologies that will hopefully stop and even
                                            reverse the threat of global warming. To sign up for a course, click the the New
                                            Students button. If you are a current student, enter your student ID number and
                                            click the View/Edit Your Info button to register for new classes or to review your
                                            current schedule.</p>
                                            <asp:Panel ID="Panel1" runat="server">
                                            <h3>Login - Returning Students</h3>
                                        <asp:TextBox class="bla" placeholder= "Student ID" ID="studentID" runat="server" />
                                            <br />
                                            <asp:TextBox class="bla" placeholder= "Password" ID="password" TextMode="Password" runat="server" />
                                            <br />
                                        &nbsp;<asp:Button class="myButton" ID="Button1" runat="server" Text="View/Edit Your Info" OnClick="Button1_Click" />&nbsp;<asp:Literal
                                            ID="validateMessage" runat="server" />&nbsp;<asp:RequiredFieldValidator ID="idValidator"
                                                runat="server" ErrorMessage="**You must enter your student ID**" ControlToValidate="studentID" />
                                             <br />
 
                                          
                                             <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
 
                                          </asp:Panel>
                                            <br />
                                            <br />
                                        </form>
                             <%--       </div>
                                </div>
                        --%>
             <%--           </div>
                    </div>
                </div>
                </div>--%>
            <%--</div>--%>
    
    </asp:Content>
