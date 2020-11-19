using System.Collections.Generic;

namespace WorldOfCountriesMobile.Prism.Models
{
    public class CountryResponse
    {
        public string Name { get; set; }


        public IEnumerable<string> TopLevelDomain { get; set; }


        public string Alpha2Code { get; set; }


        public string Alpha3Code { get; set; }


        public IEnumerable<string> CallingCodes { get; set; }


        public string Capital { get; set; }


        public IEnumerable<string> AltSpellings { get; set; }


        public string Region { get; set; }


        public string Subregion { get; set; }


        public int Population { get; set; }


        public float[] Latlng { get; set; }


        public string Demonym { get; set; }


        public float Area { get; set; }


        public float Gini { get; set; }


        public IEnumerable<string> Timezones { get; set; }


        public IEnumerable<string> Borders { get; set; }


        public string NativeName { get; set; }


        public string NumericCode { get; set; }


        public IEnumerable<Currency> Currencies { get; set; }


        public IEnumerable<Language> Languages { get; set; }


        public Translations Translations { get; set; }


        public string Flag { get; set; }


        public IEnumerable<RegionalBloc> RegionalBlocs { get; set; }


        public string Cioc { get; set; }
    }
}
