using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logical;
using DataAccess;

public partial class Member : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        User_lg user = new User_lg();
        if (user.isLogin(Session) == true)
        {
            Data data = new Data();
            Lucene_lg lucene = new Lucene_lg();
            Data result = lucene.searchLucene(Param);
            account.DataSource = result.Source;
            account.DataBind();
        }
        else
        {
            go("../Transaction/Login.aspx");
        }
    }
    protected void searchOnClick(object sender, EventArgs e)
    {
        go("../Transaction/Member.aspx?search=" + Param.getString("search"));
    }
}