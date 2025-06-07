using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Education.Models
{
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Name cannot be longer than 100 characters.")]
        public string Name { get; set; }

        [StringLength(250, ErrorMessage = "Description cannot be longer than 250 characters.")]
        public string Description { get; set; }

        public virtual ICollection<Course> Courses { get; set; } = new List<Course>();
    }
}
