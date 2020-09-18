using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using MySchoolBLL;

namespace MySchool
{
    public class StudentUI
    {
        public static void StudentMenu()
        {
            ShowMenu();
            while (true)
            {
                Console.Write("请选择要进行的操作(0-4)：");
                string s = Console.ReadLine();
                switch (s.ToLower())
                {
                    case "1":
                        ChooseCourse();
                        break;
                    case "2":
                        QuitCourse();
                        break;
                    case "3":
                        QueryMarks();
                        break;
                    case "4":
                        QueryPersonalInfo();
                        break;
                    case "5":
                        countmark();
                        break;
                    case "0":
                        BaseBLL.SaveAll();
                        return;
                    case "help":
                        ShowMenu();
                        break;
                    default:
                        Console.WriteLine("  无效的操作！！！");
                        break;
                }
            }
        }

        private static void countmark()
        {
            Console.WriteLine("******** 学生总分 ********\n");
            StudentBLL.countmark();
            Console.WriteLine("****************************");
        }

        private static void QueryPersonalInfo()
        {
            Console.WriteLine("******** 个人信息 ********\n");
            StudentBLL.GetInfo();
            Console.WriteLine("****************************");
        }

        private static void QueryMarks()
        {
            Console.WriteLine("******** 成绩查询 ********\n");
            StudentBLL.Retrieveall();
        }

        private static void QuitCourse()
        {
            Console.WriteLine("******** 课程退选 ********\n");
            while (true)
            {
                Console.Write("请输入要退选的课程ID（输入all查询课程信息）：");
                string id = Console.ReadLine();
                if (id == "all")
                {
                    StudentBLL.Querycourse();
                    continue;
                }
                else
                {
                    StudentBLL.Quitcourse(id);
                    break;
                }
            }
        }

        private static void ChooseCourse()
        {
            Console.WriteLine("******** 课程选修 ********\n");
            while (true)
            {
                Console.Write("请输入要选修的课程ID（输入all显示所有学期课程信息）：");
                string id = Console.ReadLine();
                if (id == "all")
                {
                    AdminUI.QueryTermCourse();
                    continue;
                }
                else
                {
                    if (StudentBLL.ChooseCourse(id) == 3)
                    {
                        Console.WriteLine(">>>>成功选修此课程！");
                        break;
                    }
                    else if (StudentBLL.ChooseCourse(id) == 2)
                    {
                        Console.WriteLine("不能重复选课！！");
                        break;
                    }
                    else if (StudentBLL.ChooseCourse(id) == 4)
                    {
                        Console.WriteLine("该课程选课人数已达上限，无法继续选课");
                    }
                    else
                    {
                        Console.WriteLine(">>>>错误提示：未开设学期课程ID为 {0}的课程", id);
                        break;
                    }
                }
            }

        }

        private static void ShowMenu()
        {
            Console.WriteLine(@"
╔══════════════════════════════════════════════════════╗
║                 学生操作菜单                         ║
║             ====================                     ║
║     1——课程选修           2——课程退选            ║
║     3——成绩查询           4——个人信息            ║
║     5——学生总分                                    ║   
║     0——退出               help——显示本菜单       ║
╚══════════════════════════════════════════════════════╝

");
        }
    }
}
