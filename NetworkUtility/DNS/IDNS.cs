using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace NetworkUtility.DNS
{
    public interface IDNS
    {
        bool SendDNS();
        PingOptions GetDnsByTLS();
    }
}
