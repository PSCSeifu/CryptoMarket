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
    }
}