using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bizz
{
    public class UserInfo
    {
        private int id;
        private string name;
        private string addresse;
        private string email;
        private int phone;
        private Groupflags groupflag;
        public UserInfo(string name, string addresse, string email, int phone, Groupflags groupflag)
        {
            Name = name;
            Addresse = addresse;
            Email = email;
            Phone = phone;
            Groupflag = groupflag;
        }
        public UserInfo(int id, string name, string addresse, string email, int phone, Groupflags groupflag)
        {
            this.id = id;
            Name = name;
            Addresse = addresse;
            Email = email;
            Phone = phone;
            Groupflag = groupflag;
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        public string Addresse
        {
            get
            {
                return addresse;
            }
            set
            {
                addresse = value;
            }
        }
        public string Email
        {
            get
            {
                return email;
            }
            set
            {
                email = value;
            }
        }
        public int Phone
        {
            get
            {
                return Phone;
            }
            set
            {
                Phone = value;
            }
        }
        public Groupflags Groupflag
        {
            get
            {
                return groupflag;
            }
            set
            {
                groupflag = value;
            }
        }
        public enum Groupflags { Administrator, Staff, User, Guest }
    }
}
