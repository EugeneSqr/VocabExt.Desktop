using System;
using System.Collections.Generic;
using System.Linq;
using VX.Desktop.ServiceFacade.VocabExtService;
using VX.Domain.DataContracts.Interfaces;

namespace VX.Desktop.ServiceFacade
{
    public sealed class VocabServiceFacade : IVocabServiceFacade
    {
        private VocabServiceFacade()
        {
        }

        static VocabServiceFacade()
        {
            Instance = new VocabServiceFacade();
            ServiceClient = new VocabExtServiceClient();
        }

        public static IVocabServiceFacade Instance { get; set; }

        private static IVocabExtService ServiceClient { get; set; }

        public ITask GetTask()
        {
            return (ITask)ServiceClient.GetTask();
        }

        public IList<ITask> GetTasks(Guid token)
        {
            // TODO: retrieve vocabs here
            return ServiceClient.GetTasksAllVocabBanks().Cast<ITask>().ToList();
        }
    }
}
