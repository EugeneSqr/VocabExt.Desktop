using System;
using System.Collections.Generic;
using System.Linq;
using VX.Desktop.ServiceFacade;
using VX.Domain.DataContracts.Interfaces;

namespace VX.Desktop.Infrastructure
{
    public sealed class DynamicTasksStorage : IDynamicTasksStorage
    {
        private const int LowTasksCount = 5;
        private const int EmptyStorageTasksCount = 0;

        public event EventHandler RunningLowOfItems;
        
        private DynamicTasksStorage()
        {
            items = new List<ITask>();
            RunningLowOfItems += ReplenishItemsAsync;
        }

        static DynamicTasksStorage()
        {
            Instance = new DynamicTasksStorage();
        }

        public static IDynamicTasksStorage Instance { get; set; }

        private readonly List<ITask> items;

        public bool IsReplenishInProgress { get; private set; }

        public ITask RetrieveTask()
        {
            if (items.Count <= EmptyStorageTasksCount)
            {
                ReplenishItemsAsync(null, null);
                return null;
            }

            if (items.Count <= LowTasksCount)
            {
                RunningLowOfItems(this, null);
            }

            var itemToRetrieve = items.First();

            // TODO: possible threading issues
            items.Remove(itemToRetrieve);
            return itemToRetrieve;
        }

        private void ReplenishItemsAsync(object sender, EventArgs args)
        {
            GetTasksDelegate asyncDelegate = VocabServiceFacade.Instance.GetTasks;
            IsReplenishInProgress = true;
            asyncDelegate.BeginInvoke(
                CredentialsProvider.Instance.CurrentToken,
                CallbackMethod, 
                asyncDelegate);
        }

        private delegate IList<ITask> GetTasksDelegate(Guid token);

        void CallbackMethod(IAsyncResult asyncResult)
        {
            var asyncDelegate = (GetTasksDelegate)asyncResult.AsyncState;
            items.AddRange(asyncDelegate.EndInvoke(asyncResult));
            IsReplenishInProgress = false;
        }
    }
}
