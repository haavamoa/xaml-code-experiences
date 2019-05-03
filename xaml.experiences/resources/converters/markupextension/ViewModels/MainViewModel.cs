using System.Windows.Input;
using commands;
using markupextension.Annotations;
using observingobjects;

namespace markupextension.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private bool m_shouldDisplay;

        public MainViewModel()
        {
            ShouldDisplay = false;
        }
        
        public bool ShouldDisplay
        {
            get => m_shouldDisplay;
            set => SetProperty(ref m_shouldDisplay, value);
        }
    }
}   