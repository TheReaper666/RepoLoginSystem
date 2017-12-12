using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IO;
using Entities;
using System.Net.NetworkInformation;

namespace Bizz
{
    public class BizzFunctions
    {
        ObservableCollection<Users> OCUsers;
        ObservableCollection<Logins> OCLogins;
        ObservableCollection<UsernamesAndNames> OCNamesAndUsernames;
        DBInfo DBinfo;
        public BizzFunctions()
        {
            DBinfo = new DBInfo();
        }
        public bool CheckCredentials(string Username, string Password)
        {
            return true;
        }
        public ObservableCollection<Users> GetAllUsersConverted()
        {
            DataTable dt = DBinfo.DTGetAllUsersFromDB();
            OCUsers = new ObservableCollection<Users>();
            DataTableReader reader = new DataTableReader(dt);
            while (reader.Read())
            {
                string name = reader["Name"].ToString();
                string address = reader["Address"].ToString();
                string email = reader["Email"].ToString();
                int phone = Convert.ToInt32(reader["Phone"]);
                Users user = new Users(name,address,email,phone);
                OCUsers.Add(user);
            }
            return OCUsers;
        }
        public ObservableCollection<Users> GetAllLoginsConverted()
        {
            DataTable dt = DBinfo.DTGetAllLoginsFromDB();
            OCLogins = new ObservableCollection<Logins>();
            DataTableReader reader = new DataTableReader(dt);
            while (reader.Read())
            {
                string username = reader["Username"].ToString();
                string password = reader["Password"].ToString();
                string group = reader["GroupFlag"].ToString();
                int phone = Convert.ToInt32(reader["Phone"]);
                Logins login = new Logins(username, password, group);
                OCLogins.Add(login);
            }
            return OCUsers;
        }
        public ObservableCollection<UsernamesAndNames> GetAllUsernamesAndNamesConverted()
        {
            DataTable dt = DBinfo.DTGetAllUsernamesAndNames();
            OCNamesAndUsernames = new ObservableCollection<UsernamesAndNames>();
            DataTableReader reader = new DataTableReader(dt);
            while (reader.Read())
            {
                string username = reader["Username"].ToString();
                string name = reader["Name"].ToString();
                bool status = Convert.ToBoolean(reader["status"]);
                UsernamesAndNames Person = new UsernamesAndNames(username, name, status);
                OCNamesAndUsernames.Add(Person);
            }
            return OCNamesAndUsernames;
        }

        // SELECT LoginInfo.Username,UserInfo.Name FROM LoginInfo INNER JOIN UserInfo ON LoginInfo.id = UserInfo.id
        // Metoder der kalder andrer metoder i DBInfo

        // Metoder der Convertere DataTable og sender data'en til Entities
        public string GetMacAddress()
        {
            NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
            String sMacAddress = string.Empty;
            foreach (NetworkInterface adapter in nics)
            {
                if (sMacAddress == String.Empty)// only return MAC Address from first card  
                {
                    //IPInterfaceProperties properties = adapter.GetIPProperties(); Line is not required
                    sMacAddress = adapter.GetPhysicalAddress().ToString();
                }
            }
            return sMacAddress;
        }
    }
}
