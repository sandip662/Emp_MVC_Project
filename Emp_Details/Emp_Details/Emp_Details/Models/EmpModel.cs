using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Emp_Details.Models
{
    public class EmpModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public decimal Salary { get; set; }
    }




}
