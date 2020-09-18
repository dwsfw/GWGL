using System;
using System.Collections.Generic;
using Model;

namespace MySchoolDAL
{
    /// <summary>
    /// TermCourseDAL 的摘要说明。
    /// </summary>
    [Serializable]
    public class TermCourseDAL
    {
        private List<TermCourse> termCourses;

        public TermCourseDAL()
        {
            this.termCourses = new List<TermCourse>();
        }

        /// <summary>
        /// 增加学期新课程
        /// </summary>
        /// <param name="newTermCourse"></param>
        /// <returns></returns>
        public bool AddNewTermCourse(TermCourse newTermCourse)
        {
            for (int i = 0; i < termCourses.Count; i++)
            {
                if (newTermCourse.ID == ((TermCourse)termCourses[i]).ID)
                    return false;
            }
            termCourses.Add(newTermCourse);
            return true;
        }


        /// <summary>
        /// 根据学期开设课程的ID取消该课程
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public bool RemoveTermCourse(string ID)
        {
            for (int i = 0; i < termCourses.Count; i++)
            {
                if (ID == ((TermCourse)termCourses[i]).ID)
                {
                    termCourses.RemoveAt(i);
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 根据学期开设课程的ID检索开设课程
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public TermCourse RetrieveTermCourse(string ID)
        {
            for (int i = 0; i < termCourses.Count; i++)
            {
                if (ID == termCourses[i].ID)
                {
                    return termCourses[i];
                }
            }
            return null;
        }

        /// <summary>
        /// 返回学期开设的所有课程
        /// </summary>
        /// <returns></returns>
        public TermCourse[] RetrieveAll()
        {
            return termCourses.ToArray();
        }

        /// <summary>
        /// 根据教师ID检索任课信息
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public TermCourse[] TeachCourses(string ID)
        {
            List<TermCourse> teachCourses = new List<TermCourse>();
            for (int i = 0; i < termCourses.Count; i++)
            {
                if (ID == termCourses[i].TeacherID)
                {
                    teachCourses.Add(termCourses[i]);
                }
            }
            return teachCourses.ToArray();
        }
        /// <summary>
        /// 根据学生ID检索选课信息
        /// </summary>
        /// <param name="studentID"></param>
        /// <returns></returns>
        public TermCourse[] StudyCourses(string studentID)
        {
            List<TermCourse> studyCourses = new List<TermCourse>();
            for (int i = 0; i < termCourses.Count; i++)
            {
                for (int j = 0; j < termCourses[i].Students.Count; j++)
                {
                    if (studentID == termCourses[i].Students[j].ID)
                    {
                        studyCourses.Add(termCourses[i]);
                    }
                }
            }
            return studyCourses.ToArray();
        }
        /// <summary>
        /// 根据学生id查找学生位置
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int findstudent(TermCourse tm, string id)
        {
            int s = 0;
            for (int i = 0; i < termCourses.Count; i++)
            {
                if (termCourses[i] == tm)
                {
                    for (int j = 0; j < termCourses[i].Students.Count; j++)
                    {
                        if (termCourses[i].Students[j].ID == id)
                            s = j;
                    }
                }
            }
            return s;
        }
    }
}
