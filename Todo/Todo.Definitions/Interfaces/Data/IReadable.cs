using System;
namespace NsuGo.Definition.Interfaces.Data
{
    public interface IReadable
    {
        bool IsUnread { get; set; }
        DateTime FirstRead { get; set; }
    }
}
