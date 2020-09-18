using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [Serializable]
    public class Course
    {
        string courseID;
        string courseName;
        double coursePoint;
        public string CourseID
        {
            get { return courseID; }
        }
        public string CourseName
        {
            get { return courseName; }
        }
        public double CoursePoint
        {
            get { return coursePoint; }
            set { coursePoint = value; }
        }
        public Course(string courseID, string courseName)
        {
            this.courseID = courseID;
            this.courseName = courseName;
        }
    }
}
