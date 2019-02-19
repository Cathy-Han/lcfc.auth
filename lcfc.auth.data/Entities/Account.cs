using lcfc.auth.IModules.Account;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace lcfc.auth.data.Entities
{
    public class Account : IAccount
    {
        public long Number { get; set; }
        public string Email { get; set; }
        public string MobileNum { get; set; }
        public string Type { get; set; }
        public string TargetKey { get; set; }
        public IAccount Parent { get; set; }
        public string NickName { get; set; }
        public string Status { get; set; }
        public bool Enabled { get; set; }
        public bool IsSystemed { get; set; }
        [NotMapped]
        public Dictionary<long, string> Roles { get; set; }
        public DateTime CreateTime { get; set; }
        public TimeSpan TimeStamp { get; set; }
        public DateTime UpdateTime { get; set; }
        public bool Deleted { get; set; }
        public string Domain { get; set; }
        public string Location { get; set; }
    }
}
