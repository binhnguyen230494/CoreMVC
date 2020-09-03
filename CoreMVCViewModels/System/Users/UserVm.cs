using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CoreMVCViewModels.System.Users
{
    public class UserVm
    {
        public Guid Id { get; set; }
        [Display(Name = "Ten")]
        public string FirstName { get; set; }
        [Display(Name = "Ho")]
        public string LastName { get; set; }
        [Display(Name = "So Dien Thoai")]
        public string PhoneNumber { get; set; }
        [Display(Name = "Tai Khoan")]
        public string UserName { get; set; }
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Display(Name = "Ngay Sinh")]
        public DateTime Dob { get; set; }
        public IList<string> Roles { get; set; }
    }
}
