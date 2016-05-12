using CryptoMarket.ViewModels;
using System.Collections.Generic;

namespace CryptoMarket.Models
{
    public interface ICryptoMarketRepository
    {
        int Commit();
        bool SaveAll();

        IEnumerable<Client> GetAllClients();
        
        Client GetClient();
        IEnumerable<Client> GetAllClientsWithWallets();
        void AddClient(Client newClient);
        ClientViewModel GetClient(int clientId);
        Client GetClientById(int clientId);

        void AddWallet(int clientId, Wallet newWallet);
        IEnumerable<Wallet> GetAllWallets();

        IEnumerable<Currency> GetAllCurrencies();
        void AddCurrency(Currency newCurrency);
        int CurrencyData( CurrencyData newBaseCurrency);
        void AddCurrencyData(CurrencyData newCurrencyData);
        Currency GetCurrency(int currencyId);
        IEnumerable<CurrencyData> GetCurrencyDataList(int? currencyId);
        void DeleteCurrency(int id);
        IEnumerable<OfferViewModel> GetAllOffers();
        IEnumerable<OfferViewModel> GetOfferByClientId(int clientId);
    }
}