namespace WorldOfCountriesMobile.Prism.Services
{
    using System.Threading.Tasks;

    using WorldOfCountriesMobile.Prism.Models;

    public interface IApiService
    {
        Task<Response> GetListAsync<T>(string controller);
    }
}
