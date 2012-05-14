using System;
using VX.Domain.DataContracts.Interfaces;

namespace VX.Desktop.Infrastructure
{
    public interface IDynamicTasksStorage
    {
        event EventHandler RunningLowOfItems;

        bool IsReplenishInProgress { get; }

        ITask RetrieveTask();
    }
}
