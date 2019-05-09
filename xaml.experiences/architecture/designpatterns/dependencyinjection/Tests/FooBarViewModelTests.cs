using dependencyinjection.ViewModels.DependencyInjection;
using dependencyinjection.ViewModels.DependencyInjection.Interfaces;
using Moq;

namespace dependencyinjection.Tests
{
    public class FooBarViewModelTests
    {
        private FooViewModel m_cut;
        private Mock<IBarViewModel> mocked_barViewModel;

        public FooBarViewModelTests()
        {
            mocked_barViewModel = new Mock<IBarViewModel>();
            m_cut = new FooViewModel(mocked_barViewModel.Object);
        }
        
        // Add desired test methods to test FooBarViewModel in isolation with a mocked version of IBarViewModel

        public void MyTest()
        {
            //mocked_barViewModel.Setup(s => s.SomeProperty).Returns(somevalue);
            //m_cut.DoSomeThing();
            //Assert.IsSame(m_cut.SomePropertyThatGetsSet, somevalue)
        }
    }
}