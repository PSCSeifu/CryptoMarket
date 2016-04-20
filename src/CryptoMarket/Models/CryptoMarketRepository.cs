using Microsoft.Data.Entity;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoMarket.Models
{
    public class CryptoMarketRepository : ICryptoMarketRepository
    {
        private CryptoMarketContext _context;
        private ILogger<CryptoMarketRepository> _logger;

        public CryptoMarketRepository(CryptoMarketContext context,ILogger<CryptoMarketRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public IEnumerable<Client> GetAllClients()
        {
            try
            {
                return _context.Clients.OrderBy(c => c.ClientType).ToList();
            }
            catch(Exception ex)
            {
                _logger.LogError("Could not get Clients from database.",ex);
                return null;
            }
        }

        public IEnumerable<Client> GetAllClientsWithWallets()
        {
            try
            {
                return _context.Clients
                    .Include(w => w.Wallets)
                    .OrderBy(c => c.ClientType)
                    .ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError("Could not get Clients with Wallets from Database.", ex);
                return null;
            }
        }

        public IEnumerable<Currency> GetAllCurrencies()
        {
            try
            {
                return _context.Currencies.OrderBy(c => c.Price).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError("Could not get Currencies from database.", ex);
                return null;
            }
            
        }

        public IEnumerable<Wallet> GetAllWallets()
        {
            try
            {
                return _context.Wallets.OrderBy(w => w.ClientId).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError("Could not getWallets from Database.", ex);
                return null;
            }
            
        }

       
    }
}
