using EF_GitHub.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EF_GitHub.Repository
{
    class ProfileRepository : IProfileRepository
    {
        private GitHubDbContext gitHubDbContext;
        public ProfileRepository()
        {
            this.gitHubDbContext = new GitHubDbContext();
        }
        public UserProfile Create(UserProfile entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(UserProfile entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserProfile> GetAllProfiles()
        {
            return this.gitHubDbContext.UserProfiles.ToList();
        }

        public IEnumerable<UserProfile> GetProfileAndRepos()
        {
            return this.gitHubDbContext.UserProfiles.Include(p => p.Repositories).ToList();
        }

        public IEnumerable<UserProfile> GetProfileFromLondon(string location)
        {
            var users = this.gitHubDbContext.UserProfiles.Where(x => x.Location == location).ToList();
            foreach (var item in users)
            {
                this.gitHubDbContext
                    .Entry<UserProfile>(item)
                    .Collection<Entities.Repository>(x => x.Repositories)
                    .Load();
            }
            return users;
        }



        public IList<UserProfile> ReadAll()
        {
            throw new NotImplementedException();
        }

        public UserProfile ReadById(int id)
        {
            var userProfile = this.gitHubDbContext.UserProfiles.Find(id);
            return userProfile;
        }

        public UserProfile Update(UserProfile entity)
        {
            // after updating corresponding entity

            this.gitHubDbContext.Entry<UserProfile>(entity).State = EntityState.Modified;
            this.gitHubDbContext.SaveChanges();
            
            // after that should return updated entity
            throw new NotImplementedException();
        }
    }
}
