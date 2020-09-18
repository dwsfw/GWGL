using System;
using System.Collections;
using Model;
namespace MySchoolDAL
{
	/// <summary>
	/// TeacherDAL ��ժҪ˵����
	/// </summary>
	[Serializable]
    public class TeacherDAL : BaseDAL
    {
        /// <summary>
        /// �ҵ�ѧ���иÿγ̵�λ�ã���ʦ¼��ɼ�
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
