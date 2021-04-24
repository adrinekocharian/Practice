using EF_GitHub.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EF_GitHub.Repository
{
    interface IProfileRepository : IRepository<UserProfile, int>
    {
        IEnumerable<UserProfile> GetAllProfiles();

        IEnumerable<UserProfile> GetProfileAndRepos();
    }
}
