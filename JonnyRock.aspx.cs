using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using System.Threading;


public partial class _JonnyRock : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Proc.MemberDetail md = (Proc.MemberDetail)Session[Proc.SESSION_DATA];
            if (!md.priv_attack && !md.priv_admin)
            {
                Control cl = new Control();
                Session.Clear();
                Response.Redirect(cl.ResolveUrl("~/Login/Login.aspx"));
            }
        }
        catch (Exception ex)
        {
            Control cl = new Control();
            Session.Clear();
            Response.Redirect(cl.ResolveUrl("~/Login/Login.aspx"));
        }
        if (!IsPostBack)
        {
            Control cl = new Control();

           ll_shortcuts.Text = InterfaceHelper.ItemlistHelper.shortcuts();

        }
    }
    private string Encoding64(string str)
    {
        return Convert.ToBase64String(Encoding.UTF8.GetBytes(str));
    }

    private string Decodind64(string str)
    {
        return Encoding.UTF8.GetString(Convert.FromBase64String(str));
    }

    protected  void  btn_submit_Click(object sender, EventArgs e)
    {
        createTmp();
    }


    public string createTmp()
    {
        try
        {
            string s = "";
            //   string result = rdb_a.Checked == true ? "" : rdb_b.Checked == true ? rdb_b.Text : rdb_c.Checked == true ? rdb_c.Text : rdb_d.Checked == true ? rdb_d.Text : rdb_e.Checked == true ? rdb_e.Text : "";
            string path = Server.MapPath(@"temp\");
            string template_path = Server.MapPath(@"temp\");
            using (StreamReader sr = new StreamReader(string.Format("{0}{1}", template_path, "temp.js")))
            {
                //MessageBox.Show();
                s = sr.ReadToEnd();
                s = s.Replace("{0}", tb_url.Text)
                      .Replace("{1}", tb_timeout.Text)
                      .Replace("{2}", tb_time.Text);
                      //.Replace("{3}", tb_report.Text);
            }
            string enc = Encoding64(s);  //加密

            string temp =
             "function decodeBase(str){" +
             "return decodeURIComponent(Array.prototype.map.call(atob(str), function(c){" +
                    "return '%' + ('00' + c.charCodeAt(0).toString(16)).slice(-2);" +
                "}).join(''));}" +
            "eval(decodeBase('{0}'));  ";  //解密
            tb_multline.Text = temp.Replace("{0}", enc);

            // label8.Text = temp.Replace("{0}", enc);
            using (StreamWriter sw = new StreamWriter(string.Format("{0}{1}", path, "rocktest.js")))
            {
                sw.Write(temp.Replace("{0}", enc));
            }
            Response.Write("<script>"+"產生成功" + path + "rocktest.js"+"</script>");
            HyperLink1.Visible = true;
            HyperLink1.NavigateUrl = @"temp\rocktest.js";
            // label13.Text = path + text_name.Text + ".html";
            // readFile(cb_filename);
            return temp.Replace("{0}", enc);
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
        return "";
    }
    protected void bt_write_Click(object sender, EventArgs e)
    {
        Response.Write(string.Format("<script>{0}</script>", tb_multline.Text));
    }

    protected void btn_stop_Click(object sender, EventArgs e)
    {
        Response.Redirect("JonnyRock.aspx");
    }
}