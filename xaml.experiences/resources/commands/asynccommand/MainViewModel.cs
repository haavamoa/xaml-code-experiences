using System.Threading.Tasks;
using System.Windows.Input;
using asynccommand.Resources;
using asynccommand.Resources.Commands;
using observingobjects;

namespace asynccommand
{
    public class MainViewModel : BaseViewModel
    {
        private bool m_isBusy;
        private string m_text;

        public MainViewModel()
        {
            ChangeTextAsyncCommand = new AsyncCommand(ChangeTextAsync);
        }

        public ICommand ChangeTextAsyncCommand { get; }

        public string Text
        {
            get => m_text;
            set => SetProperty(ref m_text, value);
        }

        public bool IsBusy
        {
            get => m_isBusy;
            set => SetProperty(ref m_isBusy, value);
        }

        private async Task ChangeTextAsync(object newText)
        {
            if (newText is string stringinput)
            {
                IsBusy = true;
                await Task.Delay(4200);
                Text = stringinput;
                IsBusy = false;
            }
        }
    }
}