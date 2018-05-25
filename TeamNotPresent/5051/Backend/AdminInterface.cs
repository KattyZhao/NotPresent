using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using _5051.Models;

namespace _5051.Backend
{

    /// <summary>
    /// Datasource Interface for Avatars
    /// </summary>
    public interface IAdminInterface
    {
        AdminProfileModel Create(AdminProfileModel data);
        AdminProfileModel Read(string id);
        AdminProfileModel Update(AdminProfileModel data);
        bool Delete(string id);
        List<AdminProfileModel> StudentHome();
        void Reset();
    }
}