using System.Collections.Generic;
using VX.Domain.DataContracts.Interfaces;

namespace VX.Desktop.ServiceFacade
{
    public interface IVocabServiceFacade
    {
        ITask GetTask();

        IList<ITask> GetTasks();
    }
}
