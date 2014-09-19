using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Model
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        
        [Required]
        [MinLength(3)]
        [MaxLength(15,ErrorMessage="First Name cannot be more than 15 characters.")]
        public string FirstName { get; set; }
        public string LastName { get; set; }

        //public int Age { get; set; }

        
        public int DepartmentId { get; set; }

        [ForeignKey("DepartmentId")]
        public virtual Department Department { get; set; }

    }
}
