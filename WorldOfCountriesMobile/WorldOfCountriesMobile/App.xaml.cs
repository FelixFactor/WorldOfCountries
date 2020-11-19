using Prism;
using Prism.Ioc;
using WorldOfCountriesMobile.Prism.Services;
using WorldOfCountriesMobile.Prism.ViewModels;
using WorldOfCountriesMobile.Prism.Views;
using Xamarin.Essentials.Implementation;
using Xamarin.Essentials.Interfaces;
using Xamarin.Forms;

namespace WorldOfCountriesMobile
{
    public partial class App
    {
        public App(IPlatformInitializer initializer)
            : base(initializer)
        {
        }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateAsync("NavigationPage/CountriesPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IAppInfo, AppInfoImplementation>();
            containerRegistry.RegisterSingleton<IApiService, ApiService>();

            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<CountriesPage, CountriesPageViewModel>();
            containerRegistry.RegisterForNavigation<CountryDetailsPage, CountryDetailsPageViewModel>();
        }
    }
}
