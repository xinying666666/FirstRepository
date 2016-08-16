using CarManager.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace CarManager.Web.MVC
{
    public class Acls
    {
        public static readonly Permission StudentCreate = new Permission { Category = "Student", Name = nameof(StudentCreate)};

        public static readonly Permission StudentUpdate = new Permission { Category = "Student", Name = nameof(StudentUpdate) };

        public IEnumerable<Permission> GetPermisson()
        {

            var ps = this.GetType().GetFields(BindingFlags.Static&BindingFlags.Public).Where(ac=>ac.FieldType==typeof(Permission));

            return ps.Select(p=>p.GetValue(this) as Permission);
        }
    }
}