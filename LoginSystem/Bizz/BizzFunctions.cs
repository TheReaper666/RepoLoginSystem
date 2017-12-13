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
        List<string> ListGroups;
        Logins loggedInUser;
        DBInfo DBinfo;
        public BizzFunctions()
        {
            DBinfo = new DBInfo();
        }
        public bool CheckCredentials(string Username, string Password)
        {
            GetAllLoginsConverted();
            foreach (Logins login in OCLogins)
            {
                if (login.Username == Username && login.Password == Password && login.Status != false)
                {
                    string username = login.Username;
                    string password = login.Password;
                    string groupflag = login.stGroupflag;
                    bool status = login.Status;
                    int userid = login.UserId;
                    loggedInUser = new Logins(username, password, status, groupflag, userid);
                    return true;
                }
            }
            return false;
        }
        public bool CheckForAdminitrator()
        {
            if (loggedInUser.stGroupflag == "Adminitrator")
            {
                return true;
            }
            return false;
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
                int userid = Convert.ToInt32(reader["userid"]);
                bool status = Convert.ToBoolean(reader["Status"]);
                Logins login = new Logins(username, password, status, group, userid);
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
        public List<string> GetAllGroupConverted()
        {
            DataTable dt = DBinfo.DTGetAllGroupsFromDB();
            ListGroups = new List<string>();
            DataTableReader reader = new DataTableReader(dt);
            while (reader.Read())
            {
                string group = reader["GroupFlag"].ToString();
                ListGroups.Add(group);
            }
            return ListGroups;
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
