﻿using System.ComponentModel.DataAnnotations.Schema;

namespace Demo.Project2.Models
{
    [Table("Role")]
    public partial class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool? Status { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; } = new HashSet<UserRole>();
    }
}
