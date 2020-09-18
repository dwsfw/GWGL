using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using MySchoolDAL;

namespace MySchoolBLL
{
    public class StudentBLL:BaseBLL{
     public StudentBLL() : base() { }
        public static void Retrieveall()
        {
            Console.WriteLine("        课程ID        课程成绩       ");
            Console.WriteLine("    -------------  ---------------   ");
            Student s = (Student)user;
            for(int i=0;i<s.Courses.Count;i++)
            {
                if(s.Courses[i].CoursePoint==0.0){
                    string ww="在修";
                    Console.WriteLine("        {0}        {1}       ",s.Courses[i].CourseID,ww);
                }
                else
                {
                    Console.WriteLine("        {0}        {1}       ", s.Courses[i].CourseID, s.Courses[i].CoursePoint);
                }
            }
        }
        public static int ChooseCourse(string termcourseID)
        {
            Student s = user as Student;
            TermCourse tm = termCourses.RetrieveTermCourse(termcourseID);
            if (tm == null)
            {
                return 1;
            }
            if (s.HaveChoosed(tm))
            {
                return 2;
            }
            else if (tm.Students.Count < tm.Max)
            {
                Course c = courses.RetrieveCourse(tm.CourseID);
                s.AddCourse(c);
                tm.AddStudent(s);
                DataFileAccess.SaveCourses(courses);
                DataFileAccess.SaveStudents(students);
                DataFileAccess.SaveTermCourses(termCourses);
                return 3;
            }
            else
            {
                return 4;
            }
        }
        /// <summary>
        /// 学期课程id退选
        /// </summary>
        /// <param name="id"></param>
        public static void Quitcourse(string id)
        {
            Student s = user as Student;
            TermCourse tm = termCourses.RetrieveTermCourse(id);
            if (s.HaveChoosed(tm)==false)
            {
                Console.WriteLine("未选修这门课");
            }
            else
            {
                Course c = courses.RetrieveCourse(tm.CourseID);
                if (c.CoursePoint == 0.0)
                {
                    s.RemoveCourse(c);
                    tm.RemoveStudent(s);
                    DataFileAccess.SaveCourses(courses);
                    DataFileAccess.SaveStudents(students);
                    DataFileAccess.SaveTermCourses(termCourses);
                    Console.WriteLine(">>>>成功退选指定课程！");
                }
                else
                {
                    Console.WriteLine("该课程已有成绩，无法退选！");
                }
                
            }
        }
        public static void Querycourse()
        {
            Console.WriteLine("******** 查询已选学期课程记录 ********\n");
            Console.WriteLine("      学期课程ID            课程ID          任课教师");
            Console.WriteLine("    --------------      --------------     -------------");
            TermCourse[] tm = termCourses.StudyCourses(user.ID);
            for(int i=0;i<tm.Length;i++)
            {
                Console.WriteLine("      {0}          {1}          {2}", tm[i].ID, tm[i].CourseID, tm[i].TeacherID);
            }
            Console.WriteLine("      共得到 {0} 个查询结果", tm.Length);
            Console.WriteLine("***********************************");
        }

        public static void GetInfo()
        {
            Console.WriteLine(user.ToString());
        }

        public static void countmark()
        {
            double sum = 0;
            Student s = (Student)user;
            for (int i = 0; i < s.Courses.Count; i++)
            {
                if (s.Courses[i].CoursePoint == 0.0)
                {
                    continue;
                }
                else
                {
                    sum+=s.Courses[i].CoursePoint;
                }
            }
            Console.WriteLine("我的总分是{0}", sum);
        }
    }
}
