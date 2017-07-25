using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project.Models;

namespace Project.Models
{
    public class DropRole
    {
        public string RoleID { get; set; }
        public IEnumerable<webpages_Roles> RoleCat { get; set; }
    }
}