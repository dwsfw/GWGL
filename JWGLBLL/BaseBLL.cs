using System;
using Model;
using MySchoolDAL;

namespace MySchoolBLL
{
    /// <summary>
    /// BaseBLL 的摘要说明。
    /// </summary>
    [Serializable]
    public class BaseBLL
    {
        protected static Person user;
        protected static AdminDAL admins;
        protected static StudentDAL students;
        protected static TeacherDAL teachers;
        protected static CourseDAL courses;
        protected static TermCourseDAL termCourses;

        protected BaseBLL() { }
        static BaseBLL()
        {
            admins = DataFileAccess.GetAdmins();
            students = DataFileAccess.GetStudents();
            teachers = DataFileAccess.GetTeachers();
            courses = DataFileAccess.GetCourses();
            termCourses = DataFileAccess.GetTermCourses();
        }

        public static Person User
        {
            get { return user; }
        }

        public static void RetrieveTermCourse(string id)
        {
            TermCourse tm = termCourses.RetrieveTermCourse(id);
            if (tm == null)
            {
                Console.WriteLine(">>>>错误提示：指定的学期课程不存在！");
            }
            else
            {
                Console.WriteLine("学期课程ID：{0}    学期课程姓名：{1}", tm.CourseID, tm.TeacherID);
            }
        }

        public static void SaveAll()
        {
            DataFileAccess.SaveAdmins(admins);
            DataFileAccess.SaveCourses(courses);
            DataFileAccess.SaveStudents(students);
            DataFileAccess.SaveTeachers(teachers);
            DataFileAccess.SaveTermCourses(termCourses);
        }
    }


}
