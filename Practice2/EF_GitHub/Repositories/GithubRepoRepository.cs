using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EF_GitHub.Repositories
{
    class GithubRepoRepository : IGithubRepoRepository
    {
        private GitHubDbContext gitHubDbContext;
        public GithubRepoRepository()
        {
            this.gitHubDbContext = new GitHubDbContext();
        }
        public Entities.Repository Create(Entities.Repository entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Entities.Repository entity)
        {
            throw new NotImplementedException();
        }

        public IList<Entities.Repository> ReadAll()
        {
            return this.gitHubDbContext.Repositories.ToList();
        }

        public Entities.Repository ReadById(int id)
        {
            throw new NotImplementedException();
        }

        public Entities.Repository Update(Entities.Repository entity)
        {
            throw new NotImplementedException();
        }
    }
}
