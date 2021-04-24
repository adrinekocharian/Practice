using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EF_GitHub_DB_First.Entites
{
    public partial class Profile
    {
        public Profile()
        {
            Repository = new HashSet<Repository>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Username { get; set; }
        public string Location { get; set; }
        public string Company { get; set; }

        public virtual ICollection<Repository> Repository { get; set; }
    }
}
