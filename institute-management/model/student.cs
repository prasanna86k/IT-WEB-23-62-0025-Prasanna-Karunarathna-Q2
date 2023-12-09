using System.ComponentModel.DataAnnotations;

namespace institute_management.model
{
    public class student
    {
        [Key] public int StudentId { get; set; }
        public string StudentName { get; set; }

        public string StudentCity { get; set; }

        public int CourseID { get; set;}
    }
}
