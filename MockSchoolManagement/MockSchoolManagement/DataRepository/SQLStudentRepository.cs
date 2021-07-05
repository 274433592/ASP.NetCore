using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MockSchoolManagement.Domain.Students;
using MockSchoolManagement.Infrastructure;

namespace MockSchoolManagement.DataRepository
{
    public class SQLStudentRepository:IStudentRepository
    {
        private readonly AppDbContext _appDbContext;

        public SQLStudentRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public Student GetStudentById(int id)
        {
            return _appDbContext.Students.Find(id);
        }

        public IEnumerable<Student> GetAllStudents()
        {
            return _appDbContext.Students;
        }

        public Student Insert(Student student)
        {
            _appDbContext.Students.Add(student);
            _appDbContext.SaveChanges();
            return student;
        }

        public Student Update(Student updateStudent)
        {
            var student= _appDbContext.Students.Attach(updateStudent);
            student.State = EntityState.Modified;
            _appDbContext.SaveChanges();
            return updateStudent;
        }

        public int Delete(int id)
        {
            var result = -1;
            var student=_appDbContext.Students.Find(id);
            if (student != null)
            {
                _appDbContext.Students.Remove(student);
                result = _appDbContext.SaveChanges();
            }

            return result;

        }
    }
}
