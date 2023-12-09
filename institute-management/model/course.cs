using System.ComponentModel.DataAnnotations;

namespace institute_management.model
{
    public class course
    {
        [Key] public int CourseID { get; set; }

        public string CourseName { get; set; }

        public string LectureName { get; set; }
    }
}
