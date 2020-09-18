using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using MySchoolBLL;

namespace MySchool
{
    public class TeacherUI
    {
        public static void TeacherMenu()
        {
            ShowMenu();
            while (true)
            {
                Console.Write("请选择要进行的操作(0-4)：");
                string s = Console.ReadLine();
                switch (s.ToLower())
                {
                    case "1":
                        CheckInMark();
                        break;
                    case "2":
                        QueryCourse();
                        break;
                    case "3":
                        PersonalInformtion();
                        break;
                    case "0":
                        BaseBLL.SaveAll();
                        return;
                    case "help":
                        ShowMenu();
                        break;
                }
            }
        }
        public static void PersonalInformtion()
        {
            Console.WriteLine("******** 个人信息 ********\n");
            TeacherBLL.GetInfo();
            Console.WriteLine("****************************");
        }
        public static void QueryCourse()
        {
            TeacherBLL.Retrievetall();
        }
        public static void CheckInMark()
        {
            Console.WriteLine("******** 课程成绩登记 ********\n");
            while (true)
            {
                Console.Write("请输入要登记成绩的学期课程ID（输入all显示所授课程信息）：");
                string id = Console.ReadLine();
                if (id == "all")
                {
                    QueryCourse();
                    continue;
                }
                Console.Write("输入所有选修此课程的学生的成绩（是/否/取消）？（Y/N/Q）：");
                string s = Console.ReadLine();
                if (s == "Y")
                {
                    TeacherBLL.Retrievetinall(id);
                    break;
                }
                else if (s == "N")
                {
                    while (true)
                    {
                        Console.Write("请输入要登记成绩的学生学号：");
                        string h = Console.ReadLine();
                        Console.Write("请输入学生{0}的成绩", h);
                        double a = Convert.ToDouble(Console.ReadLine());
                        TeacherBLL.Retrieveobyocourses(id, h, a);
                        Console.Write("是否继续登记");
                        string w = Console.ReadLine();
                        if (w == "N")
                            break;
                    }
                }
                else
                {
                    return;
                }
            }
        }
        public static void ShowMenu()
        {
            Console.WriteLine(@"
╔══════════════════════════════════════════════════════╗
║                 教师操作菜单                         ║
║             ====================                     ║
║     1——课程成绩登记       2——所授课程查询        ║
║     3——个人信息                                    ║
║     0——退出               help——显示本菜单       ║
╚══════════════════════════════════════════════════════╝

");
        }
    }
}
