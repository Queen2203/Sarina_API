using System;
namespace Sarina_API.Models.Enum
{
    public enum OrderStatusEnum
    {
        Draft = -1,
        Open = 1,
        OpenInProgress = 2,
        Completed = 3,
        Cancelled = 4,
        All = 5
    };
}