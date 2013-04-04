using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;


namespace DataAccess
{
    public class Account_db
    {
        public bool insert(Data data)
        {
            Data db = new Data();
            db.open();
            int result = db.insert("INSERT INTO account(balance, user_id, date) VALUES (1000.00, @user_id, now())", data);
            db.close();
            return true;
        }

        public Data select(Data data)
        {
            Data db = new Data();
            db.open();
            Data result = db.select("SELECT * FROM account WHERE user_id=@user_id", data);
            db.close();
            return result;
        }

        public Data selectUser(Data data, String[] item)
        {
            string items = "";
            Data db = new Data();
            for (int i = 0; i < item.Count(); i++)
            {
                int count = item.Count();
                if (i == count - 1)
                {
                    items = items + item[i];
                }
                else
                {
                    items = items + item[i] + ",";
                }
            }
            string query = "SELECT * FROM user WHERE id IN(<SEARCH>)";
            query = query.Replace("<SEARCH>", items);
            db.open();
            Data result = db.select(query, data);
            db.close();
            return result;
        }

        public void transferTo(Data data)
        {
            Data db = new Data();
            db.open();
            db.insert("UPDATE account SET balance=(balance+@amount) WHERE user_id=@user_id", data);
            db.close();
        }

        public void transferFrom(Data data)
        {
            Data db = new Data();
            db.open();
            db.insert("UPDATE account SET balance=(balance-@amount) WHERE user_id=@user_id", data);
            db.close();
        }

        public void transaction(Data data)
        {
            Data db = new Data();
            db.open();
            db.insert("INSERT INTO transaction (from_id, to_id, amount, time, from_name, to_name) VALUES (@from_id, @to_id, @amount, now(), @from_name, @to_name)", data);
            db.close();
        }

        public Data selectTransaction(Data data)
        {
            Data db = new Data();
            db.open();
            Data result = db.select("SELECT * FROM transaction WHERE from_id=@user_id OR to_id=@user_id", data);
            db.close();
            return result;
        }
    }
}
