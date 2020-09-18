using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using MySchoolDAL;

namespace MySchoolBLL
{
    public class TermCoursesBLL : BaseBLL
    {
        public static TermCourse[] GetAllTermCourses()
        {
            return termCourses.RetrieveAll();
        }
        public static string GetCourseDatail(TermCourse tm)
        {
            Course c = courses.RetrieveCourse(tm.CourseID);
            Teacher t = (Teacher)teachers.Retrieve(tm.TeacherID);
            return string.Format("{0,}{1}{2}{3}", tm.ID, c.CourseName, c.CoursePoint, t.Name);
        }
        public static bool Addtermcourse(string cid, string tid, int m)
        {
            TermCourse tm = new TermCourse(cid, tid, m);
            Course c = courses.RetrieveCourse(cid);
            if (c == null)
            {
                Console.WriteLine("没有找到该课程，无法添加到学期课程！");
                return false;
            }
            Teacher t = (Teacher)teachers.Retrieve(tid);
            if (t == null)
            {
                Console.WriteLine("没有找到该老师，无法添加到学期课程！");
                return false;
            }
            termCourses.AddNewTermCourse(tm);
            DataFileAccess.SaveTermCourses(termCourses);
            return true;
        }

        public static bool Retrievetermcourse(string id)
        {
            TermCourse tm = termCourses.RetrieveTermCourse(id);
            if (tm == null)
            {
                Console.WriteLine(">>>>错误提示：指定的学期课程不存在！");
                return false;
            }
            else
            {
                Console.WriteLine("学期课程信息：{0}", tm.ID);
                return true;
            }
        }

        public static bool Removetermcourse(string id)
        {
            if (termCourses.RetrieveTermCourse(id) == null)
            {
                Console.WriteLine("课程不存在！无法删除！");
                return false;
            }
            else
            {
                if (termCourses.RetrieveTermCourse(id).Students.Count != 0)
                {
                    Console.WriteLine("已有存在学生选课，无法删除！");
                    return false;
                }
                else
                {
                    termCourses.RemoveTermCourse(id);
                    DataFileAccess.SaveTermCourses(termCourses);
                    return true;
                }
            }
        }
    }
}

