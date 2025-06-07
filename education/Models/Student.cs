using System.ComponentModel.DataAnnotations;

namespace Education.Models
{
    public class Student
    {
        
        public int Id { get; set; }

     
        [Required]
        [StringLength(100)]
        public string FirstName { get; set; }

       
        [Required]
        [StringLength(100)]
        public string LastName { get; set; }

      
        [Required]
        [EmailAddress]
        public string Email { get; set; }

       
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

       
        [StringLength(15)]
        public string PhoneNumber { get; set; }

       
        [StringLength(200)]
        public string Address { get; set; }

        public virtual ICollection<Enrollment> Enrollments { get; set; }

    }
}
