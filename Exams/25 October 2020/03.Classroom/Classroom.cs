using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassroomProject
{
    public class Classroom
    {
        private int capacity;
        private List<Student> students;

        public Classroom(int capacity)
        {
            this.Capacity = capacity;
            this.students = new List<Student>();
        }

        public int Capacity { get { return this.capacity; } set { this.capacity = value; } }

        public int Count => students.Count;

        public string RegisterStudent(Student student)
        {
            if (Count < Capacity)
            {
                students.Add(student);
                return $"Added student {student.FirstName} {student.LastName}";
            }
            else
            {
                return "No seats in the classroom";
            }
        }

        public string DismissStudent(string firstName, string lastName)
        {
            Student student = students.Where(x => x.FirstName == firstName && x.LastName == lastName).FirstOrDefault();
            if (student != null)
            {
                students.Remove(student);
                return $"Dismissed student {firstName} {lastName}";
            }
            else
            {
                return "Student not found";
            }
        }

        public string GetSubjectInfo(string subject)
        {
            List<Student> studentsInfo = students.Where(x => x.Subject == subject).ToList();
            if (studentsInfo.Count != 0)
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine($"Subject: {subject}");
                sb.AppendLine("Students:");
                foreach (var student in studentsInfo)
                {
                    sb.AppendLine($"{student.FirstName} {student.LastName}");
                }

                return sb.ToString().Trim();
            }
            else
            {
                return "No students enrolled for the subject";
            }
        }

        public Student GetStudent(string firstName, string lastName)
        {
            Student student = students.Where(x => x.FirstName == firstName && x.LastName == lastName).First();

            return student;
        }
    }
}
