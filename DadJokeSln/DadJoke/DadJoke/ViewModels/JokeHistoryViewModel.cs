using DadJokes.Models;
using DadJokes.Services.Interfaces;
using Prism.AppModel;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;

namespace DadJokes.ViewModels
{
    public class JokeHistoryViewModel : ViewModelBase, IPageLifecycleAware
    {
        private List<DadJoke> _jokes;

        public JokeHistoryViewModel(INavigationService navigationService, ILocalDatabase database) : base(navigationService, database)
        {
        }

        public List<DadJoke> Jokes
        {
            get { return _jokes; }
            set
            {
                SetProperty(ref _jokes, value);
            }
        }

        public void OnAppearing()
        {
            Jokes = Database.GetJokes();
        }

        public void OnDisappearing()
        {
           
        }
    }
}
