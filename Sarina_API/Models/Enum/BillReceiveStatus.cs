using System;
namespace Sarina_API.Models.Enum
{
    public enum BillReceiveStatus
    {
        Returned = -1,
        Open = 1,
        Partial = 2,
        Closed = 3,
        All = 4
    };
}