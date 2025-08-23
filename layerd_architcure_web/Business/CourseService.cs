using layerd_architcure_web.Data.Entities;
using LCMS.Repositories;

namespace LCMS.Business
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;

        public CourseService(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }
        public List<Course> GetAllCourses()
        {
            var courses = _courseRepository.GetAllCourses();
            return courses;
        }

        public void CreateCourse(Course request)
        {
            _courseRepository.CreateCourse(request);
        }

        public Course GetCourseById(Guid id)
        {
            var course = _courseRepository.GetCourseById(id);
            return course;
        }

        public void EditCourse(Course request)
        {
            request.ModifiedAt = DateTime.Now;
            _courseRepository.EditCourse(request);
        }

        public void DeleteCourse(Course request)
        {
            _courseRepository.DeleteCourse(request);
        }
    }
}
