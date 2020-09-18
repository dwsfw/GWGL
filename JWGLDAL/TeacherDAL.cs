using System;
using System.Collections;
using Model;
namespace MySchoolDAL
{
	/// <summary>
	/// TeacherDAL 的摘要说明。
	/// </summary>
	[Serializable]
    public class TeacherDAL : BaseDAL
    {
        /// <summary>
        /// 找到学生中该课程的位置，教师录入成绩
        /// </summary>
        /// <param name="a"></param>
        /// <param name="s"></param>
        /// <returns></returns>
        public static int findcourse(Course a, Student s)
        {
            for (int i = 0; i < s.Courses.Count; i++)
            {
                if (a.CourseID == s.Courses[i].CourseID)
                    return i;
            }
            return 0;
        }
    }
}
