using System.Collections.Generic;

namespace CryptoMarket.Models
{
    public interface ICryptoMarketRepository
    {
        IEnumerable<Client> GetAllClients();
        Client GetClient();
        IEnumerable<Customer> GetAllCustomers();
        IEnumerable<Client> GetAllClientsWithWallets();
        IEnumerable<Currency> GetAllCurrencies();
        IEnumerable<Wallet> GetAllWallets();
        void AddClient(Client newClient);
        bool SaveAll();
        Client GetClientById(int clientId);
        void AddWallet(int clientId,Wallet newWallet);
        void AddCurrency(Currency newCurrency);
        int CurrencyData( CurrencyData newBaseCurrency);
        void AddCurrencyData(CurrencyData newCurrencyData);
    }
}