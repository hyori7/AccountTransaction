using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logical;
using DataAccess;

public partial class Account : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            User_lg user = new User_lg();
            Account_lg account = new Account_lg();
            Data data = new Data();
            if (user.isLogin(Session) == true)
            {
                data.add("user_id", user.getUserSession(Session));
                name.Text = user.getUser(data).getString("name");
                Data accountList = account.select(data);
                if (accountList.Count > 0)
                {
                    hidden_account.Value = "1";
                }
                else
                {
                    hidden_account.Value = "0";
                }
                balance.Text = account.select(data).getString("balance");
                Data result = account.selectTransaction(data);
                transaction.DataSource = result.Source;
                transaction.DataBind();
            }
            else
            {
                go("../Transaction/Login.aspx");
            }
        }
    }

    protected void createOnClick(object sender, EventArgs e)
    {
        Data data = new Data();
        Account_lg account = new Account_lg();
        Lucene_lg lucene = new Lucene_lg();
        User_lg user = new User_lg();
        data.add("user_id", user.getUserSession(Session));
        account.insert(data);
        lucene.addLucene(data);
        go("../Transaction/Account.aspx");

    }

    protected void searchOnClick(object sender, EventArgs e)
    {
        go("../Transaction/Member.aspx?search=" + Param.getString("search"));
    }
}