using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [Serializable]
    public class Teacher : Person
    {
        static int TID = 1;
        public Teacher(string name, string password)
            : base(name, password)
        {
           TID++;
        }
        public override string GetNewID()
        {
            string s = "T00" + TID;
            return s;
        }
        public override string GetUserType()
        {
            return "Teacher";
        }
        public override string ToString()
        {
            string s = "身份：" + GetUserType() + "\n编号：" + GetNewID() + "\n姓名：" + Name;
            return s;
        }
    }
}
