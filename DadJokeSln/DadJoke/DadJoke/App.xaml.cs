using DadJokes.Services;
using DadJokes.Services.Interfaces;
using DadJokes.ViewModels;
using Prism;
using Prism.Ioc;
using Prism.Unity;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DadJokes
{
    public partial class App 
    {
        public App() : this(null) { }
        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            InitializeComponent();
            await NavigationService.NavigateAsync("NavigationPage/MainView");
        }
        

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<ILocalDatabase, DadJokeDatabase>();
            containerRegistry.RegisterSingleton<IRemoteServer, DadJokeService>();
            
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainView, MainViewModel>();
            containerRegistry.RegisterForNavigation<JokeHistoryView, JokeHistoryViewModel > ();
            containerRegistry.RegisterForNavigation<JokeView, JokeViewModel>();
        }

    }
}
