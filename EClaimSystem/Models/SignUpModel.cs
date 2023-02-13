using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EClaimSystem.Models
{
    public class SignUpModel
    {
        public string FName { get; set; }
        public string LName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Mobile { get; set; }
        public int EmployeeId { get; set; }
        public string Gender { get; set; }
        public int Is_Active { get; set; }
        public string ManagerId { get; set; }
        public string ProfileImage { get; set; }
    }
}
