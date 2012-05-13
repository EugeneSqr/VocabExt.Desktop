using System.Threading;
using System.Windows;
using System.Windows.Controls;
using VX.Desktop.ServiceFacade;
using VX.Domain.DataContracts;
using VX.Domain.DataContracts.Interfaces;

namespace VX.Desktop
{
    public partial class TaskPanel
    {
        private ITask currentTask;

        public TaskPanel()
        {
            InitializeComponent();
            
            DynamicTasksStorage.Instance.OutOfItems += Instance_OutOfItems;
        }

        void Instance_OutOfItems(object sender, System.EventArgs e)
        {
            // run waiting animation
            while (DynamicTasksStorage.Instance.IsReplenishInProgress)
            {
                Thread.Sleep(1000);
            }
            
            Refresh();
        }

        public void Refresh()
        {
            currentTask = DynamicTasksStorage.Instance.RetrieveTask();
            if (currentTask != null)
            {
                FillTask(currentTask);
            }
        }

        private void UserControlLoaded(object sender, RoutedEventArgs e)
        {
            Refresh();
        }

        private void FillTask(ITask task)
        {
            questionSpelling.Content = task.Question.Spelling;
            questionTranscription.Content = task.Question.Transcription;
            answers.ItemsSource = task.Answers;
            answers.ItemContainerStyleSelector = BuildStyleSelector(false);
        }

        private void AnswersSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            answers.ItemContainerStyleSelector = BuildStyleSelector(true);
        }

        private AnswerStyleSelector BuildStyleSelector(bool showAnswers)
        {
            var styleSelector = new AnswerStyleSelector
                       {
                           HideAnswersStyle = (Style)Resources["HideAnswersStyle"],
                           ShowAnswersStyleCorrect =
                               (Style)Resources["ShowAnswersStyleCorrect"],
                           ShowAnswersStyleWrong =
                               (Style)Resources["ShowAnswersStyleWrong"]
                       };
            if (showAnswers)
            {
                styleSelector.CorrectAnswer = currentTask.CorrectAnswer;
            }

            return styleSelector;
        }
    }
}