using layerd_architcure_web.Data;
using layerd_architcure_web.Data.Entities;
using layerd_architcure_web.Migrations;
using Microsoft.EntityFrameworkCore;

namespace LCMS.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly ApplicationDbContext _context;

        public CourseRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public List<Course> GetAllCourses()
        {
            var courses = _context.courses.Where(c=> c.DeletedAt == null).ToList();
            return courses;

        }

        public void CreateCourse(Course request)
        {
            request.Id = Guid.NewGuid();
            _context.Add(request);
            _context.SaveChanges();
        }

        public Course GetCourseById(Guid id)
        {
            var course = _context.courses
                .FirstOrDefault(m => m.Id == id);
            return course;
        }

        public void EditCourse(Course request)
        {
            _context.Update(request);
            _context.SaveChanges();
        }

        public void DeleteCourse(Course request)
        {
            request.DeletedAt = DateTime.Now;
            _context.Update(request);
            _context.SaveChanges();
        }
    }
}
