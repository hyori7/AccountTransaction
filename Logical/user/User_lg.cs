using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.SessionState;
using DataAccess;

namespace Logical
{
    public class User_lg
    {
        public bool insert(Data data)
        {
            User_db user = new User_db();
            return user.insert(data);
        }

        public Data login(Data data)
        {
            User_db user = new User_db();
            return user.login(data);
        }

        public void setUserSession(HttpSessionState session, Data data)
        {
            session["user_id"] = data.getString("id");
        }

        public String getUserSession(HttpSessionState session)
        {
            return session["user_id"].ToString();
        }

        public bool isLogin(HttpSessionState session)
        {
            if (getUserSession(session) != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Data getUser(Data data)
        {
            User_db user = new User_db();
            return user.getUser(data);
        }

        public Data luceneSelect(Data data)
        {
            User_db account = new User_db();
            return account.luceneSelect(data);
        }
    }
}
