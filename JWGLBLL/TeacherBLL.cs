using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using MySchoolDAL;

namespace MySchoolBLL
{
    public class TeacherBLL : BaseBLL
    {
        public TeacherBLL() : base() { }
        public static void Retrievetall()
        {
            Console.WriteLine("    学期课程ID        课程名称         已选课人数");
            Console.WriteLine("----------------    -------------    --------------");
            TermCourse[] tm = termCourses.TeachCourses(user.ID);
            for (int i = 0; i < tm.Length; i++)
            {
                string course = CourseBLL.Retrievecourse2(tm[i].CourseID);
                Console.WriteLine("    {0}         {1}         {2} ", tm[i].ID, course, tm[i].Students.Count);
            }
        }
        /// <summary>
        /// 学期课程id
        /// </summary>
        /// <param name="id"></param>
        public static void Retrievetinall(string id)
        {
            TermCourse tm = termCourses.RetrieveTermCourse(id);
            Course c = courses.RetrieveCourse(tm.CourseID);
            for (int i = 0; i < tm.Students.Count; i++)
            {
                Console.WriteLine("{0}的成绩：", tm.Students[i].ID);
                double a = Convert.ToDouble(Console.ReadLine());
                int s = TeacherDAL.findcourse(c, tm.Students[i]);
                Student ss = (Student)students.Retrieve(tm.Students[i].ID);
                ss.Courses[s].CoursePoint = a;
                DataFileAccess.SaveStudents(students);
            }
            DataFileAccess.SaveTermCourses(termCourses);
            DataFileAccess.SaveCourses(courses);
            Console.WriteLine("<<<<成功输入学生成绩！");
        }
        /// <summary>
        /// h为学号，id为学期课程id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="h"></param>
        public static void Retrieveobyocourses(string id, string h, double a)
        {
            TermCourse tm = termCourses.RetrieveTermCourse(id);
            Course c = courses.RetrieveCourse(tm.CourseID);
            int i = termCourses.findstudent(tm, h);
            int s = TeacherDAL.findcourse(c, tm.Students[i]);
            Student ss = (Student)students.Retrieve(tm.Students[i].ID);
            ss.Courses[s].CoursePoint = a;
            DataFileAccess.SaveStudents(students);
            DataFileAccess.SaveTermCourses(termCourses);
            DataFileAccess.SaveCourses(courses);
        }

        public static void GetInfo()
        {
            Console.WriteLine(user.ToString());
        }
    }
}
