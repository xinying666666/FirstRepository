﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarManager.Core.Domain
{
    /// <summary>
    /// 普通权限
    /// </summary>
    public   class Permission
    {
        public string Name { get; set; }
        public string Category { get; set; }

    }

    public class Role : BaseEntity
    {
        public string Name { get; set; }
    }
    //public int MyProperty { get; set; }
    public class RolePermission : BaseEntity
    {
         public int RoleID { get; set;}
         public int PermissionID { get; set;}
    }

    public class UserPermisson : BaseEntity
    {
        public int UserID { get; set; }

        public int Permisson { get; set; }
    }



}
