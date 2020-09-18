using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [Serializable]
    public class Student : Person
    {
        static int SID = 1;
        List<Course> courses;

        public List<Course> Courses
        {
            get { return courses; }
            set { courses = value; }
        }
        public Student(string name, string password)
            : base(name, password)
        {
            this.courses = new List<Course>();
            SID++;
        }

        public void AddCourse(Course c)
        {
            Courses.Add(c);
        }
        public bool setCourseMark(double a, Course c)
        {
            bool flag = false;
            for (int i = 0; i < courses.Count; i++)
            {
                if (courses[i].CourseID == c.CourseID)
                {
                    courses[i].CoursePoint = a;
                    flag = true;
                }
            }
            return flag;
        }
        public override string GetNewID()
        {
            string s = "S00" + SID;
            return s;
        }
        public override string GetUserType()
        {
            return "Student";
        }
        /// <summary>
        /// 退课
        /// </summary>
        /// <param name="c"></param>
        public void RemoveCourse(Course c)
        {
            for (int i = 0; i < courses.Count; i++)
            {
                if (courses[i].CourseID == c.CourseID)
                    Courses.Remove(courses[i]);
            }
        }
        public override string ToString()
        {
            string s = "身份：" + GetUserType() + "\n编号：" + GetNewID() + "\n姓名：" + Name + "\n共学了" + courses.Count + "门课程";
            return s;
        }
        /// <summary>
        /// 判断该学期课程是否在该学生课程里
        /// </summary>
        /// <param name="tm"></param>
        /// <returns></returns>
        public bool HaveChoosed(TermCourse tm)
        {
            foreach (Course c in Courses)
            {
                if (c.CourseID == tm.CourseID)
                    return true;
            }
            return false;
        }
    }
}
