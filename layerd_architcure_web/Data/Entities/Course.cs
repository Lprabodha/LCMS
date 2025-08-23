using layerd_architcure_web.Helper;

namespace layerd_architcure_web.Data.Entities
{
    public class Course: CommonProps
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
