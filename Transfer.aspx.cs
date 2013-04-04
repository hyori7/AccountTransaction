using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logical;
using DataAccess;

public partial class Transfer : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        User_lg user = new User_lg();
        
        if (user.isLogin(Session) == true)
        {
            Data data = new Data();
            target_id.Value = Param.getString("user_id");
            data.add("user_id", user.getUserSession(Session));
            from.Text = user.getUser(data).getString("name");
            to.Text = user.getUser(Param).getString("name");
        }
        else
        {
            go("../Transaction/Login.aspx");
        }
    }
    protected void confirmOnClick(object sender, EventArgs e)
    {
        User_lg user = new User_lg();
        Data data = new Data();
        Account_lg account = new Account_lg();
        Data targetUser = new Data();
        targetUser.add("user_id", Param.getString("target_id"));
        data.add("user_id", user.getUserSession(Session));
        Data userAccount = account.select(data);
        Data targetAccount = account.select(targetUser);
        account.transfer(userAccount, targetAccount, Param);
        Data tData = new Data();
        tData.add("from_id", user.getUserSession(Session));
        tData.add("to_id", Param.getString("target_id"));
        tData.add("amount", Param.getString("balance"));
        tData.add("from_name", user.getUser(data).getString("name"));
        tData.add("to_name", user.getUser(targetUser).getString("name"));
        account.transaction(tData);
        go("../Transaction/Account.aspx"); 
    }
}