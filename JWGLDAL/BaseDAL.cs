using System;
using System.Collections.Generic;
using Model;
namespace MySchoolDAL
{
	/// <summary>
	/// BaseDAL ��ժҪ˵����
	/// </summary>
	[Serializable]
    public class BaseDAL
    {
        public List<Person> persons;

        public BaseDAL()
        {
            this.persons = new List<Person>();
        }

        /// <summary>
        /// ����
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        public bool Add(Person person)
        {
            for (int i = 0; i < persons.Count; i++)
            {
                if (person.ID == persons[i].ID)
                {
                    Console.WriteLine("{0}:{1}", person.ID, persons[i].ID);
                    return false;
                }
            }
            persons.Add(person);
            return true;
        }

        /// <summary>
        /// ����IDɾ��
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public bool Remove(string ID)
        {
            for (int i = 0; i < persons.Count; i++)
            {
                if (ID == persons[i].ID)
                {
                    persons.RemoveAt(i);
                    return true;
                }
            }
            return false;
        }

        public bool setmark(double a, Course c, Student s)
        {
            for (int i = 0; i < persons.Count; i++)
            {
                if ((Student)persons[i] == s)
                {
                    if (s.setCourseMark(a, c) == true)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        /// <summary>
        /// ����ID��ѯ
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public Person Retrieve(string ID)
        {
            for (int i = 0; i < persons.Count; i++)
            {
                if (ID == persons[i].ID)
                {
                    return persons[i];
                }
            }
            return null;
        }
        public bool ChangPW(Person p, string newPw)
        {
            Person thePerson = Retrieve(p.ID);
            if (thePerson != null)
            {
                thePerson.Password = newPw;
                return true;
            }
            return false;

        }
        public bool ChangPW(string pid, string newPw)
        {
            Person thePerson = Retrieve(pid);
            if (thePerson != null)
            {
                thePerson.Password = newPw;
                return true;
            }
            return false;

        }
        public Person[] RetrieveAll()
        {
            return persons.ToArray();
        }


    }
}
