using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EF_GitHub.Entities
{
    [Table("Profile")]
    public class UserProfile
    {
        public UserProfile()
        {
            this.Repositories = new List<Repository>();
        }
        [Key]
        public int Id { get; set; }

        [MaxLength(50)]
        [Column("Name")]
        public string FirstName { get; set; }

        [MaxLength(50)]
        [Column("Surname")]
        public string LastName { get; set; }

        [MaxLength(40)]
        public string Username { get; set; }
        public string Location { get; set; }

        [MaxLength(50)]
        [Required]
        public string Company { get; set; }

        public virtual List<Repository> Repositories { get; set; }
    }
}
