using System.Windows;
using System.Windows.Controls;
using VX.Domain.Entities;

namespace VX.Desktop.Infrastructure
{
    public class AnswerStyleSelector : StyleSelector
    {
        public IWord CorrectAnswer { get; set; }

        public Style ShowAnswersStyleCorrect { get; set; }

        public Style ShowAnswersStyleWrong { get; set; }

        public Style HideAnswersStyle { get; set; }
        
        public override Style SelectStyle(object item, DependencyObject container)
        {
            if (CorrectAnswer == null)
            {
                return HideAnswersStyle;
            }

            var answer = item as IWord;
            return answer != null && answer.Id == CorrectAnswer.Id  
                ? ShowAnswersStyleCorrect 
                : ShowAnswersStyleWrong;
        }
    }
}
