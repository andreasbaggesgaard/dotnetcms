<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/Template.Master" CodeBehind="Editor.aspx.cs" Inherits="cmsProject.Editor" Theme="Theme1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
    

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderBody" runat="server">
    <style>
        .nav--page, .footer {
            display: none;
        }
        .nav-tabs > li > a {
            color: black;
        }
        .active a {
            color: grey;
        }
    </style>
     <nav class="navbar navbar-default">
          <div class="container-fluid">
            <div class="navbar-header pull-right">
              <a class="navbar-brand" href="Index.aspx" style="font-weight:bolder; text-decoration:underline;">
                Go to page
              </a>
                
            </div>
         
          </div>
        </nav>

   <div class="container">
       <br />
        <ul class="nav nav-tabs">
          <li class="active" id="one"><a href="#test" data-toggle="tab" >Items</a></li>
          <li id="two"><a href="2" data-toggle="tab" >Jokes</a></li>
          <li id="three"><a href="3" data-toggle="tab" >Company</a></li>
          <%--<li id="four"><a href="" data-toggle="tab" >Choose</a></li>--%>
        </ul>

        <br />
       

            <div id="1" class="col-md-12">

                <div class="row">
                    <div class="col-md-8">

                     <asp:GridView ID="GridViewItems" runat="server" CssClass="mdl-data-table mdl-js-data-table mdl-data-table--selectable mdl-shadow--2dp" OnSelectedIndexChanged="GridViewItems_SelectedIndexChanged">
                         <Columns>
                             <asp:CommandField ShowSelectButton="True" ControlStyle-CssClass="btn btn-default" />
                         </Columns>
        </asp:GridView>
                      
                        
                    </div>

                    <div class="col-md-4" style="box-shadow: 0 2px 2px 0 rgba(0,0,0,.14), 0 3px 1px -2px rgba(0,0,0,.2), 0 1px 5px 0 rgba(0,0,0,.12); padding: 2%;">

                <asp:TextBox ID="TextBoxId" CssClass="form-control" placeholder="id" runat="server" Width="200px" ForeColor="#CCCCCC" ReadOnly="True"></asp:TextBox>
                <br />
                <asp:TextBox ID="TextBoxHeadline" CssClass="form-control" placeholder="Headline" runat="server" Width="200px"></asp:TextBox>
                <br />
                <asp:TextBox ID="TextBoxDescription" CssClass="form-control" placeholder="Description" runat="server" Width="200px"></asp:TextBox>
                <br />
                <asp:TextBox ID="TextBoxCategory" CssClass="form-control" placeholder="Category" runat="server" Width="200px"></asp:TextBox>
                <br />
                <asp:FileUpload ID="fileUploadItem" runat="server" />
                <br />
                <br />


                <asp:Button ID="ButtonCreate" runat="server" Text="Create" CssClass="btn btn-success" OnClick="ButtonCreate_Click"  />
&nbsp;&nbsp;
                <asp:Button ID="ButtonUpdate" runat="server" Text="Update" CssClass="btn btn-warning" OnClick="ButtonUpdate_Click"  />
&nbsp;&nbsp;
                <asp:Button ID="ButtonDelete" runat="server" Text="Delete" CssClass="btn btn-danger" OnClick="ButtonDelete_Click"  />
&nbsp;&nbsp;
                <asp:Button ID="ButtonCancel" runat="server" Text="Cancel" CssClass="btn btn-default" OnClick="ButtonCancel_Click"  />

                        <br />
                        <br />
                        <asp:Label ID="LabelSelected" runat="server" Font-Bold="True" Text="Insert selected item into:"></asp:Label>
                        <br />
                        <br />
                        <asp:Button ID="ButtonMainItem" runat="server" CssClass="btn btn-primary" OnClick="ButtonMainItem_Click" Text="Main Item" />
&nbsp;&nbsp;
                        <asp:Button ID="ButtonItemOne" runat="server" CssClass="btn btn-primary" OnClick="ButtonItemOne_Click" Text="Item One" />
&nbsp;&nbsp;
                        <asp:Button ID="ButtonItemTwo" runat="server" CssClass="btn btn-primary" OnClick="ButtonItemTwo_Click" Text="Item Two" />

                        <br />
                        <br />
                        <asp:Label ID="LabelMessage" runat="server" Font-Bold="True"></asp:Label>
                    </div>
                </div>
                
                <br />
                <hr />
                <h4>Preview page</h4>
               <iframe src ="http://localhost:60768/index.aspx" frameborder="0" scrolling="no" height="2100px" style=""></iframe>
            </div>

       <!-- Joke -->
            <div id="2" class="col-md-12">

                <div class="row">
                    <div class="col-md-8">

                     <asp:GridView ID="GridViewJokes" runat="server" CssClass="mdl-data-table mdl-js-data-table mdl-data-table--selectable mdl-shadow--2dp" OnSelectedIndexChanged="GridViewJokes_SelectedIndexChanged">
                         <Columns>
                             <asp:CommandField ShowSelectButton="True" ControlStyle-CssClass="btn btn-default" />
                         </Columns>
        </asp:GridView>
                      
                        
                    </div>

                    <div class="col-md-4" style="box-shadow: 0 2px 2px 0 rgba(0,0,0,.14), 0 3px 1px -2px rgba(0,0,0,.2), 0 1px 5px 0 rgba(0,0,0,.12); padding: 2%;">

                <asp:TextBox ID="TextBoxJokeId" CssClass="form-control" placeholder="id" runat="server" Width="200px" ForeColor="#CCCCCC" ReadOnly="True"></asp:TextBox>
                <br />
                <asp:TextBox ID="TextBoxCaption" CssClass="form-control" placeholder="caption" runat="server" Width="200px"></asp:TextBox>
                <br />
                <asp:FileUpload ID="fileUploadJoke" runat="server" />
                <br />
                <br />

                <asp:Button ID="ButtonCreateJoke" runat="server" Text="Create" CssClass="btn btn-success" OnClick="ButtonCreateJoke_Click"  />
&nbsp;&nbsp;
                <asp:Button ID="ButtonUpdateJoke" runat="server" Text="Update" CssClass="btn btn-warning" OnClick="ButtonUpdateJoke_Click"  />
&nbsp;&nbsp;
                <asp:Button ID="ButtonDeleteJoke" runat="server" Text="Delete" CssClass="btn btn-danger" OnClick="ButtonDeleteJoke_Click"  />
&nbsp;&nbsp;
                <asp:Button ID="ButtonCancelJoke" runat="server" Text="Cancel" CssClass="btn btn-default" OnClick="ButtonCancelJoke_Click"  />

                        <br />
                        <br />
                        <asp:Label ID="LabelJokeMessage" runat="server" Font-Bold="True" Text="Insert selected Joke into:"></asp:Label>
                        <br />
                        <br />
                        <asp:Button ID="ButtonInsertJoke" runat="server" CssClass="btn btn-primary" Text="Insert Joke" OnClick="ButtonInsertJoke_Click" />

                        <br />
                        <br />
                        <asp:Label ID="LabelJokeMessageBottom" runat="server" Font-Bold="True"></asp:Label>
                    </div>
                </div>
                
                <br />
                <hr />
                <h4>Preview page</h4>
               <iframe src ="http://localhost:60768/index.aspx" frameborder="0" scrolling="no" height="2100px" style=""></iframe>

            </div>


       <!-- Company -->
            <div id="3" class="col-md-12">

                <div class="row">
                    <div class="col-md-8">

                     <asp:GridView ID="GridViewCompany" runat="server" CssClass="mdl-data-table mdl-js-data-table mdl-data-table--selectable mdl-shadow--2dp" OnSelectedIndexChanged="GridViewCompany_SelectedIndexChanged">
                         <Columns>
                             <asp:CommandField ShowSelectButton="True" ControlStyle-CssClass="btn btn-default" />
                         </Columns>
        </asp:GridView>
                      
                        
                    </div>

                    <div class="col-md-4" style="box-shadow: 0 2px 2px 0 rgba(0,0,0,.14), 0 3px 1px -2px rgba(0,0,0,.2), 0 1px 5px 0 rgba(0,0,0,.12); padding: 2%;">

                <asp:TextBox ID="TextBoxCompanyId" CssClass="form-control" placeholder="id" runat="server" Width="200px" ForeColor="#CCCCCC" ReadOnly="True"></asp:TextBox>
                <br />
                <asp:TextBox ID="TextBoxCompanyName" CssClass="form-control" placeholder="Company name" runat="server" Width="200px"></asp:TextBox>
                <br />
                <asp:TextBox ID="TextBoxCompanyTelephone" CssClass="form-control" placeholder="Telephone" runat="server" Width="200px"></asp:TextBox>
                <br />
                <asp:FileUpload ID="fileUploadLogo" runat="server" />
                <br />
                <br />

                <asp:Button ID="ButtonCompanyCreate" runat="server" Text="Create" CssClass="btn btn-success" OnClick="ButtonCompanyCreate_Click"  />
&nbsp;&nbsp;
                <asp:Button ID="ButtonCompanyUpdate" runat="server" Text="Update" CssClass="btn btn-warning" OnClick="ButtonCompanyUpdate_Click"  />
&nbsp;&nbsp;
                <asp:Button ID="ButtonCompanyDelete" runat="server" Text="Delete" CssClass="btn btn-danger" OnClick="ButtonCompanyDelete_Click"  />
&nbsp;&nbsp;
                <asp:Button ID="ButtonCompanyCancel" runat="server" Text="Cancel" CssClass="btn btn-default" OnClick="ButtonCompanyCancel_Click"  />

                        <br />
                        <br />
                        <asp:Label ID="LabelCompanyMessage" runat="server" Font-Bold="True"></asp:Label>
                    </div>
                </div>
                
                <br />
                <hr />
                <h4>Preview page</h4>
               <iframe src ="http://localhost:60768/index.aspx" frameborder="0" scrolling="no" height="2100px" style=""></iframe>

            </div>

            <div id="4" class="col-md-12">test4

            </div>
   </div>

    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.4/jquery.min.js"></script>

    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js" integrity="sha384-Tc5IQib027qvyjSMfHjOMaLkfuWVxZxUPnCJA7l2mCWNIpG9mGCD8wGNIcPD7Txa" crossorigin="anonymous"></script>
    <script>
        jQuery(document).ready(function () {

            var $1 = jQuery("#one");
            var $2 = jQuery("#two");
            var $3 = jQuery("#three");
            var $4 = jQuery("#four");

            var $one = jQuery("#1");
            var $two = jQuery("#2");
            var $three = jQuery("#3");
            var $four = jQuery("#4");

            // page load
            jQuery($two).fadeOut(1);
            jQuery($three).fadeOut(1);
            jQuery($four).fadeOut(1);
            jQuery($one).fadeIn();

            jQuery("ul li").click(function () {
                var id = jQuery(this).attr('id');
                //console.log(id)
                tabClicked(id);
            });

            function tabClicked(value) {
                switch (value) {
                    case "one":
                        jQuery($two).fadeOut(1);
                        jQuery($three).fadeOut(1);
                        jQuery($four).fadeOut(1);
                        jQuery($one).fadeIn();
                        break;
                    case "two":
                        jQuery($one).fadeOut(1);
                        jQuery($three).fadeOut(1);
                        jQuery($four).fadeOut(1);
                        jQuery($two).fadeIn();
                        break;
                    case "three":
                        jQuery($four).fadeOut(1);
                        jQuery($one).fadeOut(1);
                        jQuery($two).fadeOut(1);
                        jQuery($three).fadeIn();
                        break;
                    case "four":
                        jQuery($one).fadeOut(1);
                        jQuery($two).fadeOut(1);
                        jQuery($three).fadeOut(1);
                        jQuery($four).fadeIn();
                        break;
                }
            }

        jQuery(".nav-tabs li").click(function (e) {
            var saveUrl = window.location.hash = jQuery(this).attr("id");
            localStorage.setItem('saveUrl', saveUrl)

            if (window.location == "http://localhost:60768/Editor.aspx#one") {
                jQuery(".nav-tabs li.active").removeClass("active");
                jQuery("#one").addClass("active");
            } else if (window.location == "http://localhost:60768/Editor.aspx#two") {
                jQuery(".nav-tabs li.active").removeClass("active");
                jQuery("#two").addClass("active");
            } else if (window.location == "http://localhost:60768/Editor.aspx#three") {
                jQuery(".nav-tabs li.active").removeClass("active");
                jQuery("#three").addClass("active");
            }

            if (window.location.hash) {
                setTimeout(function () {
                    window.scrollTo(0, 0);
                }, 1);
            }
            e.preventDefault();
        });

        var GetSavedUrl = localStorage.getItem('saveUrl');

        function GetTab(url) {
            jQuery("#" + url).click();          
        }
        GetTab(GetSavedUrl);

});
        
    </script>

</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolderFooter" runat="server">
 
</asp:Content>
