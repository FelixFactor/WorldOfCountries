namespace WorldOfCountriesMobile.Prism.ViewModels
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;

    using global::Prism.Commands;
    using global::Prism.Navigation;

    using WorldOfCountriesMobile.Prism.Models;
    using WorldOfCountriesMobile.Prism.Services;
    using WorldOfCountriesMobile.ViewModels;

    public class CountriesPageViewModel : ViewModelBase
    {
        private readonly IApiService _apiService;
        private ObservableCollection<CountryResponse> _countries;
        private List<CountryResponse> _myCountries;
        private DelegateCommand _searchCommand;
        private string _search;
        private int _lenght;

        public CountriesPageViewModel(INavigationService navigationService,
            IApiService apiService)
            : base(navigationService)
        {
            _apiService = apiService;

            Title = "World of Countries";

            LoadingCountries();
        }


        #region PUBLIC PROPERTIES
        public ObservableCollection<CountryResponse> Countries
        {
            get => _countries;
            set => SetProperty(ref _countries, value);
        }

        public DelegateCommand SearchCommand => _searchCommand ?? (_searchCommand = new DelegateCommand(ShowCountries));

        public string Search
        {
            get => _search;
            set
            {
                SetProperty(ref _search, value);
                ShowCountries();
            }
        }

        public int Lenght
        {
            get => _lenght;
            set => SetProperty(ref _lenght, value);
        }
        #endregion



        #region PRIVATE METHODS
        private async void LoadingCountries()
        {
            var response = await _apiService.GetListAsync<CountryResponse>("all");

            if (!response.Success)
            {
                await App.Current.MainPage.DisplayAlert("Error", response.Message, "Accept");
                return;
            }

            _myCountries = (List<CountryResponse>)response.Result;
            ShowCountries();
        }

        private void ShowCountries()
        {
            if (!string.IsNullOrWhiteSpace(Search))
            {
                Countries = new ObservableCollection<CountryResponse>(_myCountries.Select(c =>
                    new CountryResponse()
                    {
                        Name = c.Name,
                        Flag = c.Flag,
                        Alpha3Code = c.Alpha3Code
                    })
                    .Where(s => s.Name.ToLower().Contains(Search.ToLower())));
                Lenght = Countries.Count();
            }
            else
            {
                Countries = new ObservableCollection<CountryResponse>(_myCountries.Select(c =>
                         new CountryResponse()
                         {
                             Name = c.Name,
                             Flag = c.Flag,
                             Alpha3Code = c.Alpha3Code
                         }));
                Lenght = Countries.Count();
            }
        }
        #endregion
    }
}
