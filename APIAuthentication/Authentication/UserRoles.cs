using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace APIAuthentication.Authentication
{
    [Table("AspNetRoles")]
    public class UserRoles
    {
        public const string Admin = "Admin";
        public const string User = "User";
    }
}
