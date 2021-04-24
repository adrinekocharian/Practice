using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EF_GitHub_DB_First.Entites
{
    public partial class Repository
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ProfileId { get; set; }
        public int Stars { get; set; }

        public virtual Profile Profile { get; set; }
    }
}
