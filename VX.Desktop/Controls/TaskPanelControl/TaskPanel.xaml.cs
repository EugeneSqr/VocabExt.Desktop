using System.Windows;
using System.Windows.Controls;
using VX.Desktop.Infrastructure;
using VX.Domain.DataContracts.Interfaces;

namespace VX.Desktop.Controls.TaskPanelControl
{
    public partial class TaskPanel
    {
        private ITask currentTask;

        public TaskPanel()
        {
            InitializeComponent();
        }

        public bool Refresh()
        {
            if (!DynamicTasksStorage.Instance.IsReplenishInProgress)
            {
                currentTask = DynamicTasksStorage.Instance.RetrieveTask();
            }

            if (currentTask != null)
            {
                FillTask(currentTask);
                return true;
            }

            return false;
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