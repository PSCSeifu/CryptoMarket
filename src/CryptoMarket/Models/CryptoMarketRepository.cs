using AutoMapper;
using CryptoMarket.ViewModels;

using Microsoft.EntityFrameworkCore;
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
       // private ILogger<CryptoMarketRepository> _logger;

        public CryptoMarketRepository(CryptoMarketContext context)
        {
            _context = context;
           //_logger = logger;
        }

        #region " COMMON "

        public bool SaveAll()
        {
            return _context.SaveChanges() > 0;
        }

        public int Commit()
        {
            return _context.SaveChanges();
        }

        #endregion

        #region " CLIENT "
        public Client GetClient()
        {
            throw new NotImplementedException();
        }

        public void AddClient(Client newClient)
        {
            _context.Add(newClient);
            _context.SaveChanges();
        }
        
        public Client GetClientById(int clientId)
        {
            try
            {
                return _context.Clients
                    .Include(w => w.Wallets)
                     .Where(c => c.Id == clientId)
                     .FirstOrDefault();
            }
            catch (Exception)
            {
               //_logger.LogError($"Could not get Client with Id {clientId}", ex);
                return null;
            }
        }
        
        public IEnumerable<Client> GetAllClients()
        {
            try
            {
                return _context.Clients
                    .Include( w => w.Wallets)
                    .Include( t => t.Transactions)
                    .Include( o => o.Offers)
                    .OrderBy(c => c.ClientType).ToList();
            }
            catch(Exception)
            {
               //_logger.LogError("Could not get Clients from database.",ex);
                return null;
            }
        }

        public ClientViewModel GetClient(int clientId)
        {
            try
            {
                var client =  _context.Clients
                                .Where(c => c.Id == clientId)
                                .FirstOrDefault();
                return AutoMapper.Mapper.Map<ClientViewModel>(client);
            }
            catch (Exception)
            {
               //_logger.LogError("Could not find the Clinet in data base", ex);
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
            catch (Exception)
            {
               //_logger.LogError("Could not get Clients with Wallets from Database.", ex);
                return null;
            }
        }

        #endregion

        #region " WALLET "  
        public void AddWallet(int clientId, Wallet newWallet)
        {
            //Add ordering information
            //E.g. if there was an int order property, 
            //var theClient = GetClientByClientId(clientId);
            //newWallet.Order = theClient.Wallets.Max( s => s.order) + 1;
            _context.Wallets.Add(newWallet);
        }

        public IEnumerable<WalletViewModel> GetAllWallets()
        {
            try
            {
               var allWallets = _context.Wallets.OrderBy(w => w.ClientId).ToList();
                return Mapper.Map<IEnumerable<WalletViewModel>>(allWallets);
            }
            catch (Exception)
            {
               //_logger.LogError("Could not getWallets from Database.", ex);
                return null;
            }

        }
        #endregion

        #region " FIAT CURRENCY " 
        public IEnumerable <FiatCurrency> GetAllFiatCurrencies()
        {
            try
            {
               return  _context.FiatCurrency;                 
            }
            catch (Exception)
            {
               //_logger.LogError("Could not get Fiat Currencies from database.", ex);
                return null;
            }
        }
        #endregion

        #region     " CURRENCY "

        public IEnumerable<Currency> GetAllCurrencies()
        {
            try
            {
                //needs linq to order currency by default base currency price.
                // return _context.Currencies.OrderBy(c => c.BaseCurrencies.Max(b =>b.Price)).ToList();
                var result = _context.Currencies;
                foreach (var currency in result)
                {
                    currency.CurrencyDataCollection = GetCurrencyDataList(currency.Id).ToList();
                }
                return _context.Currencies;

            }
            catch (Exception)
            {
               //_logger.LogError("Could not get Currencies from database.", ex);
                return null;
            }
            
        }
                
        public void AddCurrency(Currency newCurrency)
        {
           // newCurrency.Id = _context.Currencies.Max(c => c.Id) + 1;
            _context.Currencies.Add(newCurrency);
            _context.SaveChanges();
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
            catch(Exception)
            {
               //_logger.LogError($"Could not get Base Fiat currency with ApiCode : {newBaseCurrency.FiatCode}", ex);
                return 0;
            }
        }

        public void AddCurrencyData(CurrencyData newCurrencyData)
        {
            _context.CurrencyData.Add(newCurrencyData);
        }

        public Currency GetCurrency(int currencyId)
        {
            try
            {
                return _context.Currencies
                    .Where(c => c.Id == currencyId)
                    .FirstOrDefault();
            }
            catch (Exception)
            {
               //_logger.LogError($"Could not get currency  with Code : {currencyId}", ex);
                return null;
            }
        }

        public IEnumerable<CurrencyData> GetCurrencyDataList(int? currencyId)
        {
            try
            {
                string cryptoCode = _context.Currencies.Where(c => c.Id == currencyId).Select( c => c.CurrencyCode).SingleOrDefault();

                if(currencyId == 0)
                {
                    return _context.CurrencyData;
                }
                return _context.CurrencyData
                    .Where(cd => cd.CryptoCode == cryptoCode)
                    .ToList();
            }
            catch(Exception)
            {
               //_logger.LogError($"Could not get currency data for currecy with Id : {currencyId}", ex);
                return null;
            }
        }

        public void DeleteCurrency(int id)
        {
            var entity = _context.Currencies.Where(c => c.Id == id).SingleOrDefault();
            _context.Currencies.Remove(entity);
            _context.SaveChanges();

        }



        #endregion

        #region " OFFER "
        public IEnumerable<OfferViewModel> GetAllOffers()
        {
            try
            {
                var result = _context.Offers;
                return Mapper.Map <IEnumerable<OfferViewModel>>(result);
            }
            catch (Exception)
            {
               //_logger.LogError("Could not get Offers from database.", ex);
                return null;
            }
        }

        public IEnumerable<OfferViewModel> GetOfferByClientId(int clientId)
        {
            try
            {
                var result = _context.Offers
                    .Where(o => o.ClientId == clientId)
                    .Select(o => 0);

               return  Mapper.Map <IEnumerable<OfferViewModel>>(result);                    
            }
            catch (Exception)
            {
               //_logger.LogError("Could not get Offers from database.", ex);
                return null;
            }
        }
        #endregion


        #region " CUSTOM QUERIES "
        public List<Tuple<string,string>> GetCryptoFiatPairs()
        {
            List<Tuple<string, string>> result = new List<Tuple<string, string>>();

            try
            {
                var cryptoCodeList = _context.Currencies.Select(c => c.CurrencyCode).ToList();
                var fiatCodeList = _context.FiatCurrency.Select(f => f.Code).ToList();


                foreach (string crypto in cryptoCodeList)
                {
                    foreach (string fiat in fiatCodeList)
                    {
                        result.Add(new Tuple<string, string>(crypto, fiat));
                    }
                }
            }
            catch (Exception)
            {
               //_logger.LogError("Could not get rypto and fiat Currency code pairs from database.", ex);
                return null;
            }

            return result;
        }


        public List<Tuple<string, string>> GetRandomCryptoAndFiatPair()
        {
            Random random = new Random();
            List<Tuple<string, string>> result = new List<Tuple<string, string>>();

            try
            {               
                var randomCryptoCode = _context.Currencies                    
                    .OrderBy(r => random.Next())
                    .Select(c => c.CurrencyCode)
                    .Take(1)
                    .FirstOrDefault();
                //var cryptoCode= _context.Currencies
                //    .Where(c => c.Id == randomId)
                //    .Select(c => c.CurrencyCode)
                //    .FirstOrDefault();
                var fiatCodeList = _context.FiatCurrency.Select(f => f.Code).ToList();

                foreach (string fiat in fiatCodeList)
                {
                    result.Add(new Tuple<string, string>(randomCryptoCode, fiat));
                }
                
            }
            catch (Exception)
            {
               //_logger.LogError("Could not get rypto and fiat Currency code pairs from database.", ex);
                return null;
            }

            return result;
        }
        #endregion
    }
}
