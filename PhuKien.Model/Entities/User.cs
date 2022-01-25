using System;
using System.Collections.Generic;

#nullable disable

namespace PhuKien.Model.Entities
{
    public partial class User
    {
        public int UsersId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public string Avatar { get; set; }
        public string Email { get; set; }
        public bool? Active { get; set; }
    }
}
