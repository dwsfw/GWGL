using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using MySchoolDAL;

namespace MySchoolBLL
{
    public class CourseBLL : BaseBLL
    {
        public static bool Addnewcourse(string id, string name)
        {
            Course c = new Course(id, name);
            if (courses.AddNewCourse(c) == false)
            {
                return false;
            }
            courses.AddNewCourse(c);
            DataFileAccess.SaveCourses(courses);
            return true;
        }
        public static bool Removecourse(string id)
        {
            if (courses.RetrieveCourse(id) == null)
            {
                Console.WriteLine("课程不存在！删除失败！");
                return false;
            }
            else
            {
                foreach (TermCourse a in termCourses.RetrieveAll())
                {
                    if (courses.RetrieveCourse(id).CourseID == a.CourseID)
                    {
                        Console.WriteLine("此课程已开设学期课程！");
                        return false;
                    }
                }
                courses.RemoveCourse(id);
                DataFileAccess.SaveCourses(courses);
                return true;
            }
        }
        public static bool Retrievecourse(string id)
        {
            Course c = courses.RetrieveCourse(id);
            if (c == null)
            {
                Console.WriteLine(">>>>错误提示:指定的课程不存在！");
                return false;
            }
            else
            {
                Console.WriteLine("课程名称：{0}", c.CourseName);
                return true;
            }
        }
        public static void Retrieveall()
        {
            Course[] c = courses.RetrieveAll();
            Console.WriteLine("     课程ID            课程名称     ");
            Console.WriteLine("---------------     ----------------");
            foreach (Course s in c)
            {
                Console.WriteLine("   {0}                 {1}        ", s.CourseID, s.CourseName);
            }
            Console.WriteLine("       共得到 {0} 个查询结果", c.Count());
        }
        public static void Retrievecourse1(string id)
        {
            Course c = courses.RetrieveCourse(id);
            if (c == null)
            {
                Console.WriteLine("指定的课程不存在！");
            }
            else
            {
                Console.WriteLine("     课程ID：{0}       课程名称：{1}    ",
                    c.CourseID, c.CourseName);
            }
        }
        public static string Retrievecourse2(string id)
        {
            Course c = courses.RetrieveCourse(id);
            return c.CourseName;
        }

        public static void Show()
        {
            TermCourse[] tm = termCourses.RetrieveAll();
            Course[] c = courses.RetrieveAll();
            for (int i = 0; i < c.Length; i++)
            {
                bool flag = false;
                Console.Write("课程：{0}", c[i].CourseID);
                for (int j = 0; j < tm.Length; j++)
                {
                    if (c[i].CourseID == tm[j].CourseID)
                    {
                        flag = true;
                        Console.Write("教师：{0}", tm[j].TeacherID);
                    }
                }
                if (flag == false)
                    Console.Write("该课程未有老师授课！！");
                Console.WriteLine();
            }
        }
    }
}
