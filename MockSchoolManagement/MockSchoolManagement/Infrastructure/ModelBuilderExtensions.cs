using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MockSchoolManagement.Domain.Students;

namespace MockSchoolManagement.Infrastructure
{
    public static class ModelBuilderExtensions
    {
        public static void SeedData(this ModelBuilder builder)
        {
            builder.Entity<Student>().HasData(new Student()
            {
                Id = 1,
                Name = "kongGP",
                Email = "2733@qq.com"
            });
            builder.Entity<Student>().HasData(new Student()
            {
                Id = 2,
                Name = "李四",
                Email = "53333@qq.com"
            });
        }
    }
}
