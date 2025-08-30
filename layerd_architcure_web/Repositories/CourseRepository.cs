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
            try
            {
                request.Id = Guid.NewGuid();
                _context.Add(request);
                _context.SaveChanges();

            }
            catch (Exception ex)
            {
                // send an email to dev
                // log to a file Seq  https://datalust.co/ or https://serilog.net/ or https://nlog-project.org/ or ILogger
                Console.WriteLine($"Unexpected error: { ex.Message}");
                throw;
            }

        }
        public Course GetCourseById(Guid id)
        {
            var course = _context.courses
                .FirstOrDefault(m => m.Id == id);
            return course;
        }

        public void EditCourse(Course request)
        {
            try
            {
                _context.Update(request);
                _context.SaveChanges();
            }catch(Exception ex)
            {
                // send an email to dev
                // log to a file Seq  https://datalust.co/ or https://serilog.net/ or https://nlog-project.org/ or ILogger
                Console.WriteLine($"Unexpected error: {ex.Message}");
                throw;
            }

        }

        public void DeleteCourse(Course request)
        {
            request.DeletedAt = DateTime.Now;
            _context.Update(request);
            _context.SaveChanges();
        }
    }
}
