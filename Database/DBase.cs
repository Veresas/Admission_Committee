using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Threading.Tasks;
using Contracts.Interfaces;
using Contracts.Models;

namespace Database
{
    /// <inheritdoc cref="IStudentStorage"/>
    public class DBase : IStudentStorage
    {
        async Task<Student> IStudentStorage.Add(Student student)
        {
            using (var context = new DataContext())
            {
                context.Students.Add(student);
                await context.SaveChangesAsync();
            }
            return student;
        }
        async Task<bool> IStudentStorage.Delete(Guid id)
        {
            using (var context = new DataContext())
            {
                var student = await context.Students.FirstOrDefaultAsync(x => x.Id == id);
                if (student != null)
                {
                    context.Students.Remove(student);
                    await context.SaveChangesAsync();
                    return true;
                }
            }

            return false;
        }
        async Task IStudentStorage.Edit(Student student)
        {
            using (var context = new DataContext())
            {
                context.Students.AddOrUpdate(student);
                await context.SaveChangesAsync();
            }
        }
        async Task<IReadOnlyCollection<Student>> IStudentStorage.GetAll()
        {
            using (var context = new DataContext())
            {
                var items = await context.Students
                    .ToListAsync();
                return items;
            }
        }
    }
}
