using EF_GitHub.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace EF_GitHub.Repositories
{
    interface IGithubRepoRepository : IRepository<Entities.Repository, int>
    {

    }
}
