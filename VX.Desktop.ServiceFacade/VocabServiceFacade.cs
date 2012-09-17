using System.Collections.Generic;
using System.Linq;
using VX.Desktop.ServiceFacade.VocabExtService;
using VX.Domain.Entities;

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

        public IList<ITask> GetTasks(string username, string password)
        {
            var banks = MembershipServiceFacade.Instance.GetVocabBanks(username, password);
            var result = banks == null || banks.Length == 0
                             ? ServiceClient.GetTasksAllVocabBanks()
                             : ServiceClient.GetTasksSpecifiedVocabBanks(banks);
            return result
                .Cast<ITask>()
                .ToList();
        }
    }
}
