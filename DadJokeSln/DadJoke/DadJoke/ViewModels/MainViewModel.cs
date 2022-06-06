using DadJokes.Services.Interfaces;
using Prism.Navigation;

namespace DadJokes.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel(INavigationService navigationService, ILocalDatabase database) : base(navigationService, database)
        {
        }
    }
}
