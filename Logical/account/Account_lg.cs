using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess;

namespace Logical
{
    public class Account_lg
    {
        public bool insert(Data data)
        {
            Account_db account = new Account_db();
            return account.insert(data);
        }

        public Data select(Data data)
        {
            Account_db account = new Account_db();
            return account.select(data);
        }

        public Data selectUser(Data data, String[] item)
        {
            Account_db account = new Account_db();
            return account.selectUser(data, item);
        }

        public void transfer(Data userAccount, Data targetAccount, Data data)
        {
            double enterAmount = Convert.ToDouble(data.getString("balance"));  
            Account_db account = new Account_db();
            targetAccount.add("amount", enterAmount);
            userAccount.add("amount", enterAmount);
            account.transferTo(targetAccount);
            account.transferFrom(userAccount);
        }

        public void transaction(Data data)
        {
            Account_db account = new Account_db();
            account.transaction(data);
        }

        public Data selectTransaction(Data data)
        {
            Account_db account = new Account_db();
            return account.selectTransaction(data);
        }
    }
}
