using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logical;
using DataAccess;

public partial class Login : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void loginOnClick(object sender, EventArgs e)
    {
        User_lg user = new User_lg();
        Data list = user.login(Param);
        if (list.Count > 0)
        {
            user.setUserSession(Session, list);
            go("../Transaction/Account.aspx");
        }
        
    }

    protected void registerOnClick(object sender, EventArgs e)
    {
        go("../Transaction/Register.aspx");
    }
}