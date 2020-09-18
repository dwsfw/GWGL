using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using MySchoolBLL;

namespace MySchool
{
    public class AdminUI
    {
        public static void Show()
        {
            ShowTitle();
            while (true)
            {
                Console.Write("请选择要进行的操作(0-4)：");
                string s = Console.ReadLine();
                switch (s.ToLower())
                {
                    case "1":
                        TeacherAdmin();
                        ShowTitle();
                        break;
                    case "2":
                        StudentAdmin();
                        ShowTitle();
                        break;
                    case "3":
                        CourseAdmin();
                        ShowTitle();
                        break;
                    case "4":
                        TermCourseAdmin();
                        ShowTitle();
                        break;
                    case "0":
                        BaseBLL.SaveAll();
                        return;
                    case "help":
                        ShowTitle();
                        break;
                    default:
                        Console.WriteLine(">>>>无效的选择！请重试！\n");
                        break;
                }
            }
        }
        private static void ShowTitle()
        {
            Console.WriteLine(@"
╔══════════════════════════════════════════════════════╗
║                 系统管理菜单                         ║
║             ====================                     ║
║     1——教师管理         2——学生管理              ║
║     3——课程管理         4——学期课程管理          ║
║     0——退出             help——显示本菜单         ║
╚══════════════════════════════════════════════════════╝

");
        }
        #region 学期课程管理
        private static void TermCourseAdmin()
        {
            ShowTermCourseAdminUI();
            while (true)
            {
                Console.Write("请选择要进行的操作(0-4)：");
                string s = Console.ReadLine();
                switch (s.ToLower())
                {
                    case "help":
                        ShowTermCourseAdminUI();
                        break;
                    case "0":
                        return;
                    case "1":
                        AddTermCourse();
                        break;
                    case "2":
                        DeleteTermCourse();
                        break;
                    case "3":
                        ModifyTermCourse();
                        break;
                    case "4":
                        QueryTermCourse();
                        break;
                    default:
                        Console.WriteLine(">>>>无效的选择！请重试！\n");
                        break;
                }
            }
        }

        public static void QueryTermCourse()
        {
            Console.WriteLine("******** 查询学期课程记录 ********\n");
            Console.Write("请输入要查询的学期课程ID（输入all显示所有学期课程信息）：");
            string id = Console.ReadLine();
            if (id == "all")
            {
                TermCourse[] tm = TermCoursesBLL.GetAllTermCourses();
                Console.WriteLine("    学期课程ID        课程名称        任课教师");
                Console.WriteLine("----------------    -------------    --------------");
                foreach (TermCourse tr in tm)
                {
                    string teacher = AdminBLL.Retrieveteacher2(tr.TeacherID);
                    string course = CourseBLL.Retrievecourse2(tr.CourseID);
                    Console.WriteLine("    {0}        {1}           {2}", tr.ID, course, teacher);
                }
                Console.WriteLine("     共得到 {0} 个查询结果", tm.Length);
            }
            else
            {
                TermCoursesBLL.RetrieveTermCourse(id);
            }
            Console.WriteLine("******************************");
        }

        private static void ModifyTermCourse()
        {
            Console.WriteLine("******** 学期课程学生选课统计记录 ********\n");
            TermCourse[] tm = TermCoursesBLL.GetAllTermCourses();
            Console.WriteLine("        学期课程ID          选课人数");
            foreach (TermCourse tr in tm)
            {
                Console.WriteLine("        {0}          {1}", tr.ID, tr.Students.Count);
            }
            Console.WriteLine("****************************");
        }

        private static void DeleteTermCourse()
        {
            Console.WriteLine("******** 删除学期课程记录 ********\n");
            Console.Write("请输入要删除的学期课程ID：");
            string id = Console.ReadLine();
            if (TermCoursesBLL.Retrievetermcourse(id) == false)
            {
                return;
            }
            Console.Write("确认要删除该课程吗？（Y/N）：");
            string s = Console.ReadLine();
            if (s == "Y")
            {
                if (TermCoursesBLL.Removetermcourse(id))
                    Console.WriteLine("<<<<删除操作成功完成！");
            }
            else if (s == "N")
                Console.WriteLine("<<<<删除操作被取消！");
            else
                Console.WriteLine("操作错误！");
            Console.WriteLine("*******************************");
        }

        private static void AddTermCourse()
        {
            Console.WriteLine("******** 新增学期课程记录 ********\n");
            string c, s;
            int m;
            while (true)
            {
                Console.Write("请输入学期要开设课程的ID(输入all查询课程信息):");
                c = Console.ReadLine();
                if (c == "all")
                {
                    QueryCourse();
                    continue;
                }
                Console.Write("请输入课程任课教师的ID(输入all查询教师信息):");
                s = Console.ReadLine();
                if (s == "all")
                {
                    QueryTeacher();
                    continue;
                }
                Console.Write("请输入该课程最大选课人数:");
                m = Convert.ToInt32(Console.ReadLine());
                break;
            }
            if (TermCoursesBLL.Addtermcourse(c, s, m))
            {
                Console.WriteLine(">>>>成功添加学期开设课程记录");
            }
            else
            {
                Console.WriteLine(">>>>错误提示：没有课程或者没有老师或者该课程已开设！");
            }
            Console.WriteLine("*****************************");
        }

        private static void ShowTermCourseAdminUI()
        {
            Console.WriteLine(@"
╔══════════════════════════════════════════════════════════════╗
║                       学期课程管理菜单                       ║
║                   ====================                       ║
║                1——新增         2——删除                   ║
║                3——选课统计     4——查询                   ║
║        0——返回至系统管理菜单   help——显示本菜单          ║
╚══════════════════════════════════════════════════════════════╝

");
        }
        #endregion
        #region 课程管理
        private static void CourseAdmin()
        {
            ShowCourseAdminUI();
            while (true)
            {
                Console.Write("请选择要进行的操作(0-4)：");
                string s = Console.ReadLine();
                switch (s.ToLower())
                {
                    case "help":
                        ShowCourseAdminUI();
                        break;
                    case "0":
                        return;
                    case "1":
                        AddCourse();
                        break;
                    case "2":
                        DeleteCourse();
                        break;
                    case "3":
                        ModifyCourse();
                        break;
                    case "4":
                        QueryCourse();
                        break;
                    default:
                        Console.WriteLine(">>>>无效的选择！请重试！\n");
                        break;
                }
            }
        }

        private static void QueryCourse()
        {
            Console.WriteLine("******** 查询课程记录 ********\n");

            while (true)
            {
                Console.Write("请输入要查询的课程ID（输入all显示所有课程信息）:");
                string id = Console.ReadLine();
                if (id == "all")
                {
                    CourseBLL.Retrieveall();
                }
                else
                {
                    CourseBLL.Retrievecourse1(id);
                    break;
                }
            }
        }

        private static void ModifyCourse()
        {
            Console.WriteLine("******** 课程授课记录 ********\n");
            CourseBLL.Show();
            Console.WriteLine("****************************");
        }

        private static void DeleteCourse()
        {
            Console.WriteLine("******** 删除课程记录 ********\n");
            Console.Write("请输入要删除的课程ID:");
            string id = Console.ReadLine();
            if (CourseBLL.Retrievecourse(id) == false)
            {
                return;
            }
            Console.Write("确认要删除该课程吗？（Y/N）");
            string s = Console.ReadLine();
            if (s == "Y")
            {
                if (CourseBLL.Removecourse(id))
                    Console.WriteLine("<<<<删除操作成功完成！");
            }
            else if (s == "N")
            {
                Console.WriteLine("<<<<删除操作被取消！");
            }
            else
            {
                Console.WriteLine("操作错误!");
            }
            Console.WriteLine("****************************");
        }

        private static void AddCourse()
        {
            Console.WriteLine("******** 新增课程记录 ********\n");
            Console.Write("请输入新课程的ID:");
            string id = Console.ReadLine();
            Console.Write("请输入新课程的名称:");
            string name = Console.ReadLine();
            if (CourseBLL.Addnewcourse(id, name))
            {
                Console.WriteLine(">>>>成功添加新课程记录\n*********************");
            }
            else
            {
                Console.WriteLine(">>>>该课程已存在，请重试!");
            }
        }

        private static void ShowCourseAdminUI()
        {
            Console.WriteLine(@"
╔══════════════════════════════════════════════════════════════╗
║                       课程管理菜单                           ║
║                   ====================                       ║
║                1——新增         2——删除                   ║
║                3——课程授课     4——查询                   ║
║        0——返回至系统管理菜单   help——显示本菜单          ║
╚══════════════════════════════════════════════════════════════╝

");
        }
        #endregion
        #region 学生管理
        private static void StudentAdmin()
        {
            ShowStudentAdminUI();
            while (true)
            {
                Console.Write("请选择要进行的操作(0-4)：");
                string s = Console.ReadLine();
                switch (s.ToLower())
                {
                    case "help":
                        ShowStudentAdminUI();
                        break;
                    case "0":
                        return;
                    case "1":
                        AddStudent();
                        break;
                    case "2":
                        DeleteStudent();
                        break;
                    case "3":
                        QueryStudent();
                        break;
                    default:
                        Console.WriteLine(">>>>无效的选择！请重试！\n");
                        break;
                }
            }
        }

        private static void QueryStudent()
        {
            Console.WriteLine("******** 查询学生记录 ********\n");
            while (true)
            {
                Console.Write("请输入要查询的学生ID（输入all显示所有学生信息）:");
                string id = Console.ReadLine();
                if (id == "all")
                {
                    AdminBLL.Retrieveallstudent();
                }
                else
                {
                    AdminBLL.Retrievestudent1(id);
                    break;
                }
            }
        }


        private static void DeleteStudent()
        {
            Console.WriteLine("********* 删除学生记录 ********\n");
            Console.Write("请输入要删除的学生ID:");
            string id = Console.ReadLine();
            if (AdminBLL.Retrievestudent(id) == false)
            {
                Console.WriteLine(">>>>错误提示:指定的学生不存在！");
                Console.WriteLine("**************************");
                return;
            }
            Console.Write("确认要删除该学生吗？(Y/N):");
            string s = Console.ReadLine();
            if (s == "Y")
            {
                if (AdminBLL.Removestudent(id))
                    Console.WriteLine("删除操作成功完成!");
            }
            else if (s == "N")
                Console.WriteLine("<<<<删除操作被取消！");
            else
            {
                Console.WriteLine("操作错误！");
            }
            Console.WriteLine("***************************");
        }

        private static void AddStudent()
        {
            Console.WriteLine("******** 新增学生记录 ********\n");
            Console.Write("请输入新学生的姓名:");
            string name = Console.ReadLine();
            AdminBLL.Addstudent(name);
            Console.WriteLine(">>>>成功添加新学生记录");
            Console.WriteLine("***************************");
        }

        private static void ShowStudentAdminUI()
        {
            Console.WriteLine(@"
╔══════════════════════════════════════════════════════════════╗
║                       学生管理菜单                           ║
║                   ====================                       ║
║                1——新增         2——删除                   ║
║                3——查询                                     ║
║        0——返回至系统管理菜单   help——显示本菜单          ║
╚══════════════════════════════════════════════════════════════╝

");
        }
        #endregion
        #region 教师管理
        private static void TeacherAdmin()
        {
            ShowTeacherAdminUI();
            while (true)
            {
                Console.Write("请选择要进行的操作(0-4)：");
                string s = Console.ReadLine();
                switch (s.ToLower())
                {
                    case "help": ShowTeacherAdminUI();
                        break;
                    case "0":
                        return;
                    case "1":
                        AddTeacher();
                        break;
                    case "2":
                        DeleteTeacher();
                        break;
                    case "3":
                        QueryTeacher();
                        break;
                    default:
                        Console.WriteLine(">>>>无效的选择！请重试！\n");
                        break;
                }
            }

        }

        private static void QueryTeacher()
        {
            Console.WriteLine("******** 查询教师记录 ********\n");
            Console.Write("请输入要查询的教师ID（输入all显示所有教师信息）:");
            string id = Console.ReadLine();
            if (id == "all")
            {
                AdminBLL.Retrieveallteacher();
            }
            else
            {
                AdminBLL.Retrieveteacher1(id);
            }
        }

        private static void DeleteTeacher()
        {
            Console.WriteLine("********* 删除教师记录 ********\n");
            Console.Write("请输入要删除的教师ID:");
            string id = Console.ReadLine();
            if (AdminBLL.Retrieveteacher(id) == false)
            {
                Console.WriteLine(">>>>错误提示:指定的教师不存在！");
                Console.WriteLine("**************************");
                return;
            }
            Console.Write("确认要删除该教师吗？(Y/N):");
            string s = Console.ReadLine();
            if (s == "Y")
            {
                if (AdminBLL.Removeteacher(id))
                    Console.WriteLine("删除操作成功完成!");
            }
            else if (s == "N")
                Console.WriteLine("<<<<删除操作被取消！");
            else
            {
                Console.WriteLine("操作错误！");
            }
            Console.WriteLine("***************************");
        }

        private static void AddTeacher()
        {
            Console.WriteLine("******** 新增教师记录 ********\n");
            Console.Write("请输入新教师的姓名:");
            string name = Console.ReadLine();
            if (AdminBLL.Addteacher(name))
            {
                Console.WriteLine(">>>>成功添加新教师记录");
            }
            else Console.WriteLine(">>>>教师已存在，添加失败！");
            Console.WriteLine("***************************");
        }

        private static void ShowTeacherAdminUI()
        {
            Console.WriteLine(@"
╔══════════════════════════════════════════════════════════════╗
║                       教师管理菜单                           ║
║                   ====================                       ║
║                1——新增         2——删除                   ║
║                3——查询                                     ║
║        0——返回至系统管理菜单   help——显示本菜单          ║
╚══════════════════════════════════════════════════════════════╝

");
        }
        #endregion
    }
}
