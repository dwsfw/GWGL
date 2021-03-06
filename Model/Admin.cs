﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [Serializable]
    public class Admin : Person
    {
        static int admainID = 1;
        public Admin(string name, string password)
            : base(name, password)
        {
            admainID++;
        }
        public override string GetNewID()
        {
            string s = "A00" + admainID;
            return s;
        }
        public override string GetUserType()
        {
            return "Admin";
        }
        public override string ToString()
        {
            string s = "身份：" + GetUserType() + "\n编号：" + GetNewID() + "\n姓名：" + Name;
            return s;
        }
    }
}
