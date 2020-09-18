using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using MySchoolBLL;
using MySchool;

namespace MySchoolUI
{
    public class loginUI
    {
        public static void Login()
        {
            Console.WriteLine(@"
╔════════════════════════════╗
║╔══════════════════════════╗║
║║              简易教务管理系统 V0.1                 ║║
║║                                                    ║║
║╚══════════════════════════╝║
╚════════════════════════════╝


");
            Console.Write("请输入用户名:");
            string id = Console.ReadLine();
            Console.Write("请输入密码:");
            string password = Console.ReadLine();
            bool falg = false;
            while (true)
            {
            /*    if(falg==true)break;*/
                string err="";

                falg = LoginBLL.Login(id, password, out err);
                if (falg == true)
                {
                    Welcome();
                    switch (id.ToLower()[0])
                    {
                        case 'a':
                            AdminUI.Show();
                            break;
                        case 's':
                            StudentUI.StudentMenu();
                            break;
                        case 't':
                            TeacherUI.TeacherMenu();
                            break;
                        default:
                            break;
                    }
                }
                else Console.WriteLine("   {0}", err);
                Console.WriteLine("bye~bye~");
                break;
            }
            Console.Read();
            
        }
        public static void Welcome()
        {
            Console.WriteLine("Welcome   " + BaseBLL.User.Name + " ," + BaseBLL.User.GetUserType());
        }
    }
}
