using System;
using System.Windows;
using viewmodelbased.Services;
using viewmodelbased.ViewModels;

namespace viewmodelbased.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainView
    {
        private MainViewModel m_mainViewModel;

        public MainView()
        {
            InitializeComponent();
            
            //Dependency inject lightweight style
            m_mainViewModel = new MainViewModel(new FriendService());
            
            DataContext = m_mainViewModel;

            Loaded += OnLoaded;
        }

        private async void OnLoaded(object sender, EventArgs e)
        {
            await m_mainViewModel.Initialize();
        }
    }
}