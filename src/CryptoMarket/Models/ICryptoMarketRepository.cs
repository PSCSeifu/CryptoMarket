using System.Collections.Generic;

namespace CryptoMarket.Models
{
    public interface ICryptoMarketRepository
    {
        IEnumerable<Client> GetAllClients();
        IEnumerable<Client> GetAllClientsWithWallets();
        IEnumerable<Currency> GetAllCurrencies();
        IEnumerable<Wallet> GetAllWallets();
    }
}