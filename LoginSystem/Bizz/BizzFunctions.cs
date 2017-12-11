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
        ObservableCollection<Users> fisk;
        List<Users> ListUsers = new List<Users>();
        DBInfo DBinfo;
        public BizzFunctions()
        {
            DBinfo = new DBInfo();
        }
        public bool CheckCredentials(string Username, string Password)
        {
            return true;
        }
        public List<Users> GetUsersConverted()
        {
            DataTable dt = DBinfo.DTGetAllUsersFromDB();
            DataTableReader reader = new DataTableReader(dt);
            while (reader.Read())
            {
                string name = reader["Name"].ToString();
                string address = reader["Address"].ToString();
                string email = reader["Email"].ToString();
                int phone = Convert.ToInt32(reader["Phone"]);
                Users user = new Users(name,address,email,phone);
                ListUsers.Add(user);
            }
            return ListUsers;
        }
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
