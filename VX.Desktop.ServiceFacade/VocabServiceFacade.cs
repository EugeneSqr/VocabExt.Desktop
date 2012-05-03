using VX.Desktop.ServiceFacade.VocabExtService;
using VX.Domain.DataContracts.Interfaces;

namespace VX.Desktop.ServiceFacade
{
    public class VocabServiceFacade : IVocabServiceFacade
    {
        private readonly IVocabExtService service = new VocabExtServiceClient();

        public ITask GetTask()
        {
            return (ITask)service.GetTask();
        }
    }
}
