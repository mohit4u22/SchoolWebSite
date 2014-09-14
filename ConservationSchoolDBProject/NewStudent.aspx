<%@ Page Language="C#" AutoEventWireup="True" MasterPageFile="~/Site.Master" CodeBehind="NewStudent.aspx.cs"
    Inherits="ConservationSchoolDBProject.NewStudent" Debug="true" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">



                               <%-- <div id="c">
                                    <div style="padding: 30px;">
                                        <div id="col_l">--%>
                                            <h1>
                                                <span style="font-weight: normal; text-decoration: underline">New Student Registration</span></h1>
                                            <form id="registrationForm" runat="server">
                                            <p>
                                                Last name&nbsp;<asp:RequiredFieldValidator ID="lastNameValidate" runat="server" ControlToValidate="lastName"
                                                    Text="**Required field**" /><br />
                                                <asp:TextBox class="bla" placeholder="Last Name" ID="lastName" runat="server" Width="265" /><br />
                                                First name&nbsp;<asp:RequiredFieldValidator ID="firstNameValidate" runat="server"
                                                    ControlToValidate="firstName" Text="**Required field**" /><br />
                                                <asp:TextBox class="bla" placeholder="First Name" ID="firstName" runat="server" Width="265" /><br />
                                                Telephone&nbsp;<asp:RequiredFieldValidator ID="telephoneValidate" runat="server"
                                                    ControlToValidate="telephone" Text="**Required field**" Display="Dynamic" /><asp:RegularExpressionValidator
                                                        ID="RegularExpressionValidator3" runat="server" ErrorMessage="**Invalid phone number**"                                                        
                                                        ValidationExpression="^(1 )?(\([0-9]{3}\) )?([1-9]{3}(\-[1-9]{4})$)" ControlToValidate="telephone" /><br />
                                                <asp:TextBox class="bla" placeholder="Phone Number" ID="telephone" runat="server" Width="265" /><br />
                                                E-mail&nbsp;<asp:RequiredFieldValidator ID="emailValidate" runat="server" ControlToValidate="email"
                                                    Text="**Required field**" Display="Dynamic" /><asp:RegularExpressionValidator ID="RegularExpressionValidator1"
                                                        runat="server" ErrorMessage="**Invalid e-mail address**" ControlToValidate="email"
                                                        ValidationExpression="^[_\w\-]+(\.[_\w\-]+)*@[\w\-]+(\.[\w\-]+)*(\.[\D]{2,3})$" /><br />
                                                <asp:TextBox class="bla" placeholder="Email ID" ID="email" runat="server" Width="265" /><br />
                                                Confirm e-mail&nbsp;<asp:RequiredFieldValidator ID="confirmEmailValidate" runat="server"
                                                    ControlToValidate="confirmEmail" Text="**Required field**" Display="Dynamic" /><asp:RegularExpressionValidator
                                                        ID="RegularExpressionValidator2" runat="server" ErrorMessage="**Invalid e-mail address**"
                                                        ControlToValidate="confirmEmail" ValidationExpression="^[_\w\-]+(\.[_\w\-]+)*@[\w\-]+(\.[\w\-]+)*(\.[\D]{2,3})$" /><br />
                                                <asp:TextBox class="bla" placeholder="Enter Email ID Again--" ID="confirmEmail" runat="server" Width="265" /><br />
                                                <asp:CompareValidator ID="compareEmail" runat="server" ControlToValidate="confirmEmail"
                                                    Operator="Equal" Display="Dynamic" ControlToCompare="email">**You did not enter the same value in the e-mail and e-mail confirmation fields**<br /></asp:CompareValidator>
                                           Password&nbsp;<asp:RequiredFieldValidator ControlToValidate="passbox" ID="RequiredFieldValidator2" runat="server" ErrorMessage="**Password is mandatory" SetFocusOnError="true" ForeColor="Red"></asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ControlToValidate="passbox" ID="RegularExpressionValidator4" runat="server" ErrorMessage="**Atleast 6 character long" ValidationExpression="^.{6,}$"></asp:RegularExpressionValidator><br/>
                                                <asp:TextBox class="bla" placeholder="Password" ID="passbox" runat="server" Width="265" /><br />
                                                    
                                                <asp:Button class="myButton" ID="getStudentID" runat="server" Text="Get Student ID" /></p>
                                            </form>
                                            <asp:Literal ID="regMessage" runat="server" Visible="False" /><div>
                                            </div>
                          <%--          </div>
                                </div>
                            </div>--%>



    </asp:Content>
