using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logical;
using DataAccess;

public partial class Register : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

        }
    }

    protected void registerOnClick(object sender, EventArgs e)
    {

        User_lg user = new User_lg();
        Validation_lg validate = new Validation_lg();
        error_Length.Text = validate.registerError(Param).Item1;
        error_Upper.Text = validate.registerError(Param).Item2;
        error_Number.Text = validate.registerError(Param).Item3;
        error_Symbol.Text = validate.registerError(Param).Item4;

        captcha.ValidateCaptcha(captcha_txt.Text.Trim());
        if (captcha.UserValidated)
        {
            if (validate.registerError(Param).Item5 == false)
            {
                user.insert(Param);
                go("../Transaction/Login.aspx");
            }
        }
        else
        {
            lblMessage.ForeColor = System.Drawing.Color.Red;
            lblMessage.Text = "Invalid Captcha";
        }
        

    }
}