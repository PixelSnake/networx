using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace NetworkMapCreator.Utilities
{
    public static class ApplicationLocking
    {
        private static List<string> MACLocks = new List<string>();

        public static void AddMACLock(string mac_addr)
        {
            MACLocks.Add(mac_addr);
        }

        public static bool CheckLocks()
        {
            var mac_addr = GetMACAddr();

            if (!MACLocks.Contains(mac_addr))
                return false;

            return true;
        }

        public static string GetMACAddr()
        {
            NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
            String sMacAddress = string.Empty;
            foreach (NetworkInterface adapter in nics)
            {
                if (sMacAddress == String.Empty)
                {
                    sMacAddress = adapter.GetPhysicalAddress().ToString();
                }
            }

            return sMacAddress;
        }
    }
}
