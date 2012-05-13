using System;
using VX.Domain.DataContracts.Interfaces;

namespace VX.Desktop
{
    public interface IDynamicTasksStorage
    {
        event EventHandler RunningLowOfItems;

        event EventHandler OutOfItems;

        bool IsReplenishInProgress { get; }

        ITask RetrieveTask();
    }
}
