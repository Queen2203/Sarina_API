using System;
namespace Sarina_API.Models.Enum
{
    public enum ChequeStatusEnum
    {
        Pending = 0,
        Issued = 1,
        Cleared = 2,
        Returned = 3,
        Bounced = 4,
        All = 5,
    };
}