using lcfc.auth.IModules.Role;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace lcfc.auth.data.Entities
{
    public class Role : IRole
    {
        public string Name { get; set; }
        public string Label { get; set; }
        public string Description { get; set; }
        [NotMapped]
        public string[] Modules { get; set; }
        public long Id { get; set; }
        public DateTime CreateTime { get; set; }
        public TimeSpan TimeStamp { get; set; }
        public DateTime UpdateTime { get; set; }
        public string Domain { get; set; }
        public string Location { get; set; }
        public bool Deleted { get; set; }
        public string Language { get; set; }
    }
}
