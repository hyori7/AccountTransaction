using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Text;
using DataAccess;

namespace Logical
{
	public class BasePage : Page
	{
        private Data param = null;
        private Data paramUrl = null;

        protected Data Param
        {
            get
            {
                param = RequestPage.Form(Request);
                if (param.Count == 0)
                {
                    param = RequestPage.Query(Request);
                }
                if (param.Count == 0)
                {
                    param = RequestPage.Param(Request);
                }
                return param;
            }
        }

        protected void go(string url)
        {
            Response.Redirect(url);
        }
	}
}
