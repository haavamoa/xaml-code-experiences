namespace observingobjects
{
    public class FooBarViewModel : BaseViewModel
    {
        private string m_bar;

        public string Bar
        {
            get => m_bar;
            set => SetProperty(ref m_bar, value);
        }

        public void Foo()
        {
            Bar = "New value";
        }
    }
}