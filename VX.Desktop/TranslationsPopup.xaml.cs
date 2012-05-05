using System.Windows;
using System.Windows.Controls;
using VX.Desktop.ServiceFacade;
using VX.Domain.DataContracts.Interfaces;

namespace VX.Desktop
{
    public partial class TranslationsPopup
    {
        private readonly IVocabServiceFacade serviceFacade;

        private ITask currentTask;

        public TranslationsPopup(IVocabServiceFacade serviceFacade)
        {
            this.serviceFacade = serviceFacade;
            InitializeComponent();
        }

        private void UserControlLoaded(object sender, RoutedEventArgs e)
        {
            currentTask = serviceFacade.GetTask();
            FillTask(currentTask);
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