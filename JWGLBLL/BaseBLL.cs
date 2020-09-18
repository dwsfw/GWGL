using System;
using Model;
using MySchoolDAL;

namespace MySchoolBLL
{
    /// <summary>
    /// BaseBLL ��ժҪ˵����
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
                Console.WriteLine(">>>>������ʾ��ָ����ѧ�ڿγ̲����ڣ�");
            }
            else
            {
                Console.WriteLine("ѧ�ڿγ�ID��{0}    ѧ�ڿγ�������{1}", tm.CourseID, tm.TeacherID);
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
