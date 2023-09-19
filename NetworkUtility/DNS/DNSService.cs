using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace NetworkUtility.DNS
{
    public class DNSService : IDNS
    {
        public PingOptions GetDnsByTLS()
        {
            return new PingOptions() { DontFragment = false, Ttl = 1};
        }

        public bool SendDNS()
        {
            return true;
        }
    }
}
