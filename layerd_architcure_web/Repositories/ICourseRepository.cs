using layerd_architcure_web.Data.Entities;

namespace LCMS.Repositories
{
    public interface ICourseRepository
    {
        List<Course> GetAllCourses();
        void CreateCourse(Course request);
        Course GetCourseById(Guid id);

        void EditCourse(Course request);

        void DeleteCourse(Course request);
    }
}
