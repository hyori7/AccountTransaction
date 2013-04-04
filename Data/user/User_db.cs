using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace DataAccess
{
    public class User_db
    {
        public bool insert(Data data)
        {
            Data db = new Data();
            db.open();
            int result = db.insert(@"INSERT INTO user(username, password, name, address, phone, licence) VALUES 
                                    (@username, @password, @name, @address, @phone, @licence)", data);
            db.close();
            return true;
        }

        public Data login(Data data)
        {
            Data db = new Data();
            db.open();
            Data result = db.select("SELECT * FROM user WHERE username=@username AND password=@password", data);
            db.close();
            return result;
        }

        public Data getUser(Data data)
        {
            Data db = new Data();
            db.open();
            Data result = db.select("SELECT * FROM user WHERE id=@user_id", data);
            db.close();
            return result;
        }

        public Data luceneSelect(Data data)
        {
            Data db = new Data();
            db.open();
            Data result = db.select("SELECT * FROM user", data);
            db.close();
            return result;
        }
    }
}
