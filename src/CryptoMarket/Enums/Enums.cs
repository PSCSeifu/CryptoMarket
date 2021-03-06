using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoMarket.Enums
{
    public class Enums
    {
        public enum BaseCurrency
        {
            usd,
            gbp,
            eur
        }

        public enum ClientType
        {
            customer,
            vendor
        }            

        public enum WebUserType
        {
            adminstrator,
            customer,
            vendor
        }
    }
}
