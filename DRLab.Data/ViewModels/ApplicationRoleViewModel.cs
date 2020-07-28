using System.Collections.Generic;
using System.Security.Claims;

namespace DRLab.Data.ViewModels
{
    public class ApplicationRoleViewModel
    {
        public ApplicationRoleViewModel()
        {
            RoleClaims = new List<Claim>();
        }

        public int Id { set; get; }

        public string Name { set; get; }

        public string Description { set; get; }

        public List<Claim> RoleClaims { get; set; }
    }
}
