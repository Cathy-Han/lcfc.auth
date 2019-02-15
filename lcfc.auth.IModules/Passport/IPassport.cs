using lcfc.auth.IModules.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace lcfc.auth.IModules.Passport
{
    public interface IPassport:ICreateTime,IUpdateTime,IDeleted,IDomainKey
    {
        Guid Id { get; set; }

        long Account { get; set; }

        string LoginName { get; set; }

        string Password { get; set; }

        string EncryptType { get; set; }

        bool IsExternal { get; set; }

        string Token { get; set; }
    }
}
