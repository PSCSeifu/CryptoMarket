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

        public Client GetClient(int clientId)
        {
            try
            {
                return _context.Clients
                                .Where(c => c.Id == clientId)
                                .FirstOrDefault();
            }
            catch (Exception ex)
            {
                _logger.LogError("Could not find the Clinet in data base", ex);
                return null;
            }
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            try
            {
                return _context.Customers.OrderBy(c => c.LastName).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError("Could not get Customers from data base.", ex);
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
                //needs linq to order currency by default base currency price.
                // return _context.Currencies.OrderBy(c => c.BaseCurrencies.Max(b =>b.Price)).ToList();
                return _context.Currencies;

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

        public Client GetClient()
        {
            throw new NotImplementedException();
        }

        public void AddClient(Client newClient)
        {           
            _context.Add(newClient);
        }

        public bool SaveAll()
        {
            return _context.SaveChanges() > 0;
        }

        public Client GetClientById(int clientId)
        {
            try
            {                
                return _context.Clients
                    .Include( w => w.Wallets)
                     .Where(c => c.Id == clientId)
                     .FirstOrDefault();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Could not get Client with Id {clientId}", ex);
                return null;
            }
        }

        public void AddWallet(int clientId,Wallet newWallet)
        {
            //Add ordering information
            //E.g. if there was an int order property, 
            //var theClient = GetClientByClientId(clientId);
            //newWallet.Order = theClient.Wallets.Max( s => s.order) + 1;
            _context.Wallets.Add(newWallet);
        }

        
        public void AddCurrency(Currency newCurrency)
        {
            _context.Currencies.Add(newCurrency);
        }
     

        public int CurrencyData(CurrencyData newBaseCurrency)
        {
            try
            {
                return _context.CurrencyData
                    .Where(b => b.FiatCode == newBaseCurrency.FiatCode)   
                    .Select( b => b.Id)                
                    .FirstOrDefault();
            }
            catch(Exception ex)
            {
                _logger.LogError($"Could not get Base Fiat currency with ApiCode : {newBaseCurrency.FiatCode}", ex);
                return 0;
            }
        }

        public void AddCurrencyData(CurrencyData newCurrencyData)
        {
            _context.CurrencyData.Add(newCurrencyData);
        }
    }
}
