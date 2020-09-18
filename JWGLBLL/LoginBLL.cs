using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using MySchoolDAL;
namespace MySchoolBLL
{
    public class LoginBLL:BaseBLL
    {
        public LoginBLL() { }
        public static bool Login(string id,string password, out string err)
        {
            err = null;
            switch ((id.ToUpper())[0])
            {
                case 'A': user = (Admin)admins.Retrieve(id); break;
                case 'T': user = (Teacher)teachers.Retrieve(id); break;
                case 'S': user = (Student)students.Retrieve(id); break;
                default:
                    err="编号不规范";return false;
            }
            if (user == null)
            {
                err = "用户不存在"; return false;
            }
            else
            {
                if (user.Password == password)
                {
                    return true;
                }
                else
                {
                    err="密码不正确";
                    return false;
                }
            }
        }
    }
}
