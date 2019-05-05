using observingobjects;

namespace logicalexpressionconverter.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private bool m_firstCondition;

        public MainViewModel()
        {
            FirstCondition = true;
        }
    
        public bool FirstCondition
        {
            get => m_firstCondition;
            set => SetProperty(ref m_firstCondition, value);
        }
        public bool SecondCondition => true;
    }
}