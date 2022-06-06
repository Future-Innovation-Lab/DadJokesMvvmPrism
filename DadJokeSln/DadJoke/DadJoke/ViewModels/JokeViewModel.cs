using DadJokes.Models.Service;
using DadJokes.Services.Interfaces;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace DadJokes.ViewModels
{
    public class JokeViewModel : ViewModelBase
    {
        private IRemoteServer _remoteServer;
        private IPageDialogService _dialogService;
        
        private DelegateCommand _newJokeCommand;
        public DelegateCommand NewJokeCommand =>
            _newJokeCommand ?? (_newJokeCommand = new DelegateCommand(PersistedJokeCommand));

        private DadJoke _joke;

        public DadJoke Joke
        {
            get { return _joke; }
            set
            {
                SetProperty(ref _joke, value);
            }
        }
        

        public JokeViewModel(INavigationService navigationService, ILocalDatabase database, IRemoteServer remote, IPageDialogService dialogService) : base(navigationService, database)
        {
            _remoteServer = remote;
            _dialogService = dialogService;
        }

        public async override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);

            await GetPersistedJoke();
        }

        public async void PersistedJokeCommand()
        {
            await GetPersistedJoke();
        }

        public async Task GetPersistedJoke()
        {
            if (Connectivity.NetworkAccess != NetworkAccess.None)
            {
                var joke = await _remoteServer.GetRemoteJoke();

                Joke = joke;

                Models.DadJoke dbJoke = new Models.DadJoke();
                dbJoke.JokeDate = DateTime.Now;
                dbJoke.Joke = joke.joke;
                Database.SaveDadJoke(dbJoke);
            }
            else
            {
                await _dialogService.DisplayAlertAsync("Internet", "Connectivity not available.", "Ok");
            }
        }
    }
}
