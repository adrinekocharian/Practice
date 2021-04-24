using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EF_GitHub.Entities
{
    [Table("Repository")]
    public class Repository
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int Stars { get; set; }

        // We will cover this next week
        //public ICollection<Language> Language { get; set; } //Csharp,java

        [ForeignKey("Profile")]
        public int ProfileId { get; set; }
        public virtual UserProfile Profile { get; set; }
    }
}
