using layerd_architcure_web.Data.Entities;

namespace LCMS.Business
{
    public interface ICourseService
    {
        List<Course> GetAllCourses();

        void CreateCourse(Course request);

        Course GetCourseById(Guid id);

        void EditCourse(Course request);

        void DeleteCourse(Course request);
    }
}
