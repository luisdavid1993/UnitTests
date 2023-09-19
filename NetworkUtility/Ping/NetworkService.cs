using NetworkUtility.DNS;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace NetworkUtility.Ping
{
    public class NetworkService
    {
        private readonly IDNS _dNS;

        public NetworkService(IDNS dNS)
        {
            this._dNS = dNS;
        }
        public string SendPing()
        {
            // long code with complex logic
            bool sendResult =  _dNS.SendDNS();
            if (sendResult)
                return "ping sent";
            else
                return "ping not sent";
        }

        public int PingTimeOut(int a, int b)
        {
            // long code with complex logic
            return a + b;
        }
        public DateTime LastPingDate()
        {
            return DateTime.Now;
        }

        public PingOptions GetPingOptions()
        {

            return new PingOptions() { DontFragment = true, Ttl = 1 };
        }

        public IEnumerable<PingOptions> LastPings()
        {
            IEnumerable<PingOptions> pings = new List<PingOptions>()
            {
             new PingOptions() { DontFragment = true, Ttl = 1},
              new PingOptions() { DontFragment = false, Ttl = 2},
               new PingOptions() { DontFragment = true, Ttl = 3}
            };
            return pings;
        }

        public PingOptions GetPingOptionsByDns()
        {
            PingOptions options = _dNS.GetDnsByTLS();
            if(options.Ttl == 1)
                return options;
            else
                return null;
        }
    }
}
