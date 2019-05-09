using System.Windows.Input;
using delegatecommand.Resources.Commands;
using observingobjects;

namespace delegatecommand.ViewModels
{
    internal class MainViewModel : BaseViewModel
    {
        private string m_text;

        public MainViewModel()
        {
            Text = "Foo";
            UpdateTextCommand = new DelegateCommand(UpdateText);
        }

        private void UpdateText(object obj)
        {
            Text = obj.ToString();
        }

        public ICommand UpdateTextCommand { get; private set; }

        public string Text
        {
            get => m_text;
            set => SetProperty(ref m_text, value);
        }
    }
}