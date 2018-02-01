<%@ Page Title="JonnyRock" Language="C#" MasterPageFile="~/FunctionPage.Master"  AutoEventWireup="true" CodeFile="JonnyRock.aspx.cs"  Inherits="_JonnyRock" enableEventValidation="false"%>


<asp:Content ID="BodyContent" ContentPlaceHolderID="FunctionContent" runat="server">
   
    <h4 class="page-title"><%: Page.Title %></h4>
                            <!-- Shortcuts -->
                <div class="block-area shortcut-area">
                    <asp:Literal ID="ll_shortcuts" runat="server"></asp:Literal>                        
                </div>
                
                <hr class="whiter" />

    <div>
        <asp:Label ID="lb_url" runat="server" Text="目標網址:"></asp:Label>
        <asp:TextBox  CssClass="form-control" ID="tb_url" runat="server">http://127.0.0.1/default.aspx</asp:TextBox>
        <asp:Label ID="Label1" runat="server" Text="回報網址:"></asp:Label>
        <asp:TextBox  CssClass="form-control" ID="tb_report" runat="server">http://127.0.0.1/default.aspx?uid=1&type=1</asp:TextBox>
        <asp:Label ID="lb_timeot" runat="server" Text="Timeout(毫秒):"></asp:Label>
        <asp:TextBox  CssClass="form-control" ID="tb_timeout" runat="server">0</asp:TextBox>
        <asp:Label ID="lb_time" runat="server" Text="發送間隔(毫秒):"></asp:Label>
        <asp:TextBox  CssClass="form-control" ID="tb_time" runat="server">500</asp:TextBox>
        <asp:Button CssClass="btn btn-primary" ID="btn_submit" runat="server" Text="產生" OnClick="btn_submit_Click" />
    </div>
       
        <a>加密原始碼:</a>
    <div class="row">
    <div class="col-md-6">
        <asp:TextBox  CssClass="form-control" ID="tb_multline" TextMode ="MultiLine" runat="server" Height="300px" Width="50%"></asp:TextBox>
      
    </div>
       
    <div class="col-md-6">
     <a>封包發送監控</a>
    <textarea class="form-control" style="height:300px; width:50%;" rows="1000" cols="1000" value="" id="text_show">  </textarea>
      
      </div>
        </div>
    <div class="row">
          <asp:HyperLink ID="HyperLink1" Visible ="false" runat="server">(右鍵另存指令碼)下載指令碼</asp:HyperLink>
        <asp:Button CssClass="btn btn-primary" ID="btn_stop" runat="server" Text="停止攻擊" OnClick="btn_stop_Click" />
       <asp:Button CssClass="btn btn-primary" ID="bt_write" runat="server" Text="開始攻擊"  OnClick="bt_write_Click" />
      
          
            
    </div>
    </asp:Content>