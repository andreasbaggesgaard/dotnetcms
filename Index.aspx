<%@ Page Title="" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="cmsProject.Index" Theme="Theme1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderHeader" runat="server">
    <div id="header">
        
    </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderBody" runat="server">
    <div id="body">
        <div class="container">
            <div class="row">

            <div class="col-md-12">
                       <asp:Repeater ID="RepeaterMainItem" runat="server">
                        <ItemTemplate>
                            <div class="page-item">                                     
                                <h4><%# Eval("headline") %></h4>
                                <img src="pictures/<%# Eval("picture") %>" alt="" class="img-responsive"/>  
                                <h5><%# Eval("category") %></h5>
                                <p><%# Eval("description") %></p>  
                            </div>                                  
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>

                <div class="col-md-6">
                      <asp:Repeater ID="RepeaterItem1" runat="server">
                        <ItemTemplate>
                            <div class="page-item">                                     
                                <h4><%# Eval("headline") %></h4>
                                <img src="pictures/<%# Eval("picture") %>" alt="" width="" class="img-responsive"/>  
                                <h5><%# Eval("category") %></h5>
                                <p><%# Eval("description") %></p>  
                            </div>                                  
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
 
                <div class="col-md-6">
                      <asp:Repeater ID="RepeaterItem2" runat="server">
                        <ItemTemplate>
                            <div class="page-item">                                     
                                <h4><%# Eval("headline") %></h4>
                                <img src="pictures/<%# Eval("picture") %>" alt="" width="" class="img-responsive"/>  
                                <h5><%# Eval("category") %></h5>
                                <p><%# Eval("description") %></p>  
                            </div>                                  
                        </ItemTemplate>
                    </asp:Repeater>
                </div>

             <div class="col-md-12">
                    <asp:Repeater ID="RepeaterJoke" runat="server">
                        <ItemTemplate>
                            <div class="page-item">                                     
                                <h4><%# Eval("caption") %></h4>
                                <img src="jokes/<%# Eval("picture") %>" alt="" width="" class="img-responsive"/>
                                <asp:Image ID="Image1" runat="server" />
                            </div>                                  
                        </ItemTemplate>
                    </asp:Repeater>
            </div>

            </div>
        </div>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolderFooter" runat="server">
 
</asp:Content>
