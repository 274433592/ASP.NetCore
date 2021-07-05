using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MockSchoolManagement.Domain.Students;

namespace MockSchoolManagement.DataRepository
{
    public class MockStudentRepository:IStudentRepository
    {
        private readonly List<Student> _students;

        public MockStudentRepository()
        {
            _students = new List<Student>()
            {
                new Student(){Id = 1,Name = "张三",Email = "zhangsan@qq.com"},
                new Student(){Id = 2,Name = "李四",Email = "lisi@qq.com"},
                new Student(){Id = 3,Name = "王五",Email = "wangwu@qq.com"}
            };
        }
        public Student GetStudentById(int id)
        {
            return _students.FirstOrDefault(c => c.Id == id);
        }

        public IEnumerable<Student> GetAllStudents()
        {
            return _students;
        }

        public Student Insert(Student student)
        {
            student.Id = _students.Max(c => c.Id) + 1;
            _students.Add(student);
            return student;
        }

        public Student Update(Student updateStudent)
        {
            var stu = _students.FirstOrDefault(s => s.Id == updateStudent.Id);
            if (stu != null)
            {
                stu.Name = updateStudent.Name;
                stu.Email = updateStudent.Email;
            }

            return stu;
        }

        public int Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
