using EF_GitHub.Entities;
using EF_GitHub.Repositories;
using EF_GitHub.Repository;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace EF_GitHub
{
    class Program
    {
        static void Main(string[] args)
        {
            ProfileRepository profileRepository = new ProfileRepository();
            GithubRepoRepository gitrepository = new GithubRepoRepository();

            var userProfiles = profileRepository.GetAllProfiles();
            //var userProfilesAndRepos = profileRepository.GetProfileAndRepos();
            //var londonUsers = profileRepository.GetProfileFromLondon("USA");



            var gitRepos = gitrepository.ReadAll();

            foreach (var profile in userProfiles)
            {
                foreach (var repo in profile.Repositories)
                {
                    Console.WriteLine(repo.Name);
                }
                Console.WriteLine($"{profile.Username} {profile.FirstName} {profile.LastName} {profile.Location}");
            }
            Console.ReadLine();
            //SeedData();
        }


        private static void SeedData()
        {
            using (var dbcontext = new GitHubDbContext())
            {
                UserProfile u2 = new UserProfile()
                {
                    Username = "jonskeet",
                    FirstName = "Jon",
                    LastName = "Skeet",
                    Location = "London",
                    Company = "Google"
                };
                UserProfile u3 = new UserProfile()
                {
                    Username = "unclebob",
                    FirstName = "Robert",
                    LastName = "Martin",
                    Location = "USA",
                    Company = "CleanCode",
                    
                };
                dbcontext.UserProfiles.Add(u2);
                dbcontext.UserProfiles.Add(u3);
                dbcontext.SaveChanges();

                Entities.Repository repo1 = new Entities.Repository() { Name = "Homework1", Stars = 5, Profile = u3 };
                Entities.Repository repo2 = new Entities.Repository() { Name = "Homework2", Stars = 0, Profile = u3 };
                Entities.Repository repo3 = new Entities.Repository() { Name = "CSharpFeatures", Stars = 55, Profile = u2 };

                dbcontext.Repositories.Add(repo1);
                dbcontext.Repositories.Add(repo2);
                dbcontext.Repositories.Add(repo3);
                dbcontext.SaveChanges();
            }
        }
    }
}
