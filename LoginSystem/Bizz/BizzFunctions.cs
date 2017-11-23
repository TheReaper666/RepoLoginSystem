using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bizz
{
    public class BizzFunctions
    {
        public ObservableCollection<LoginInfo> CollectionOfLogins = new ObservableCollection<LoginInfo>();
        public ObservableCollection<UserInfo> CollectionOfUsers = new ObservableCollection<UserInfo>();
        public BizzFunctions()
        {

        }
        public bool CheckCredentials(string Username, string Password)
        {
            return true;
        }
    }
}
