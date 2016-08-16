using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarManager.Service.Security
{
    public interface IPermissonService
    {
        bool Authorize(string permissionName, string userName);
    }
}
