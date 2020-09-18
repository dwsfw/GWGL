using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [Serializable]
    public class TermCourse
    {
        string courseID;
        string id;
        int max;

        public int Max
        {
            get { return max; }
            set { max = value; }
        }
        List<Student> students;

        public List<Student> Students
        {
            get { return students; }
            set { students = value; }
        }
        string teacherID;
        public TermCourse(string courseID, string teacherID, int max)
        {
            this.max = max;
            this.courseID = courseID;
            this.id = courseID + teacherID;
            this.teacherID = teacherID;
            students = new List<Student>();
        }
        public string CourseID
        {
            get { return courseID; }
        }
        public string ID
        {
            get { return id; }
        }
        public string TeacherID
        {
            get { return teacherID; }
        }
        public void AddStudent(Student s)
        {
            Students.Add(s);
        }
        public void GetStudents()
        {
            foreach (Student s in Students)
            {
                Console.WriteLine("{0} {1}", s.ID, s.Name);
            }
        }
        public void RemoveStudent(Student s)
        {
            for (int i = 0; i < students.Count; i++)
            {
                if (students[i].ID == s.ID)
                    Students.Remove(students[i]);
            }
        }
    }
}
