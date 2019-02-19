using lcfc.auth.IModules.Passport;
using System;
using System.Collections.Generic;
using System.Text;

namespace lcfc.auth.data.Entities
{
    public class Passport : IPassport
    {
        public Guid Id { get; set; }
        public long Account { get; set; }
        public string LoginName { get; set; }
        public string Password { get; set; }
        public string EncryptType { get; set; }
        public bool IsExternal { get; set; }
        public string Token { get; set; }
        public DateTime CreateTime { get; set; }
        public TimeSpan TimeStamp { get; set; }
        public DateTime UpdateTime { get; set; }
        public bool Deleted { get; set; }
        public string Domain { get; set; }
        public string Location { get; set; }
    }
}
