using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using MySchoolDAL;

namespace MySchoolBLL
{
    public class AdminBLL : BaseBLL
    {
        public static bool Addstudent(string name)
        {
            Student s = new Student(name, "123");
            if (students.Add(s))
            {
                DataFileAccess.SaveStudents(students);
                return true;
            }
            else
                return false;
        }
        public static bool Retrievestudent(string id)
        {
            Student s = (Student)students.Retrieve(id);
            if (s == null)
            {
                Console.WriteLine(">>>>错误提示:指定学生不存在！");
                return false;
            }
            else
            {
                Console.WriteLine("       学生姓名:{0}", s.Name);
                return true;
            }
        }
        public static bool Removestudent(string id)
        {
            if (students.Retrieve(id) != null)
            {
                Student s = (Student)students.Retrieve(id);
                if (s.Courses.Count != 0)
                {
                    Console.WriteLine("此学生已经选课，无法删除！");
                    return false;
                }
                students.Remove(id);
                DataFileAccess.SaveStudents(students);
                return true;
            }
            else
            {
                Console.WriteLine("此学生不存在！");
                return false;
            }
        }

        public static void Retrieveallstudent()
        {
            Person[] s = students.RetrieveAll();
            Console.WriteLine("     学生ID         学生名称");
            Console.WriteLine("--------------   ---------------");
            foreach (Student c in s)
            {
                Console.WriteLine("     {0}            {1}      ", c.ID, c.Name);
            }
            Console.WriteLine("     共得到 {0} 个查询结果", s.Count());
        }

        public static void Retrievestudent1(string id)
        {
            Student s = (Student)students.Retrieve(id);
            if (s == null)
            {
                Console.WriteLine(">>>>错误提示:指定学生不存在！");
            }
            else
            {
                Console.WriteLine("     学生ID:{0}  学生姓名:{1}", s.ID, s.Name);
            }
        }
        public static bool Addteacher(string name)
        {
            if (teachers.Add(new Teacher(name, "123")))
            {
                DataFileAccess.SaveTeachers(teachers);
                return true;
            }
            else
            {
                return false;
            }

        }

        public static bool Retrieveteacher(string id)
        {
            Teacher s = (Teacher)teachers.Retrieve(id);
            if (s == null)
            {
                Console.WriteLine(">>>>错误提示:指定教师不存在！");
                return false;
            }
            else
            {
                Console.WriteLine("       教师姓名:{0}", s.Name);
                return true;
            }
        }

        public static bool Removeteacher(string id)
        {
            if (teachers.Retrieve(id) != null)
            {
                if (termCourses.TeachCourses(id).Length != 0)
                {
                    Console.WriteLine("此老师已开设课程，无法删除！");
                    return false;
                }
                teachers.Remove(id);
                DataFileAccess.SaveTeachers(teachers);
                return true;
            }
            else
            {
                Console.WriteLine("此老师不存在！");
                return false;
            }
        }

        public static void Retrieveallteacher()
        {
            Person[] s = teachers.RetrieveAll();
            Console.WriteLine("     教师ID         教师名称");
            Console.WriteLine("--------------   ---------------");
            foreach (Teacher c in s)
            {
                Console.WriteLine("     {0}            {1}      ", c.ID, c.Name);
            }
            Console.WriteLine("     共得到 {0} 个查询结果", s.Count());
        }

        public static void Retrieveteacher1(string id)
        {
            Teacher s = (Teacher)teachers.Retrieve(id);
            if (s == null)
            {
                Console.WriteLine(">>>>错误提示:指定教师不存在！");
            }
            else
            {
                Console.WriteLine("    教师ID{0}   教师姓名:{1}", s.ID, s.Name);
            }
        }
        public static string Retrieveteacher2(string id)
        {
            Teacher s = (Teacher)teachers.Retrieve(id);
            return s.Name;
        }
    }
}
