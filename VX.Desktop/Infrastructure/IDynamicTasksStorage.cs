using System;
using VX.Domain.Entities;

namespace VX.Desktop.Infrastructure
{
    public interface IDynamicTasksStorage
    {
        event EventHandler RunningLowOfItems;

        bool IsReplenishInProgress { get; }

        ITask RetrieveTask();
    }
}
