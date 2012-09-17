using System.Collections.Generic;
using VX.Domain.Entities;

namespace VX.Desktop.ServiceFacade
{
    public interface IVocabServiceFacade
    {
        ITask GetTask();

        IList<ITask> GetTasks(string username, string password);
    }
}
