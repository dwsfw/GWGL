using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [Serializable]
    abstract public class Person
    {
        string id;
        string name;
        string password;
        public Person(string name, string password)
        {
            this.id = GetNewID();
            this.name = name;
            this.password = password;
        }
        public string ID
        {
            get { return id; }
        }
        public string Name
        {
            get { return name; }
        }
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        public abstract string GetNewID();
        public abstract string GetUserType();
    }
}
