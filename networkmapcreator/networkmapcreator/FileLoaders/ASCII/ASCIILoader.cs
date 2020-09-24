using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace NetworkMapCreator.FileLoaders.ASCII
{
    public abstract class ASCIILoader
    {
        public abstract bool IsDeprecated { get; }

        public abstract Map Load(XmlDocument doc);

        public static ASCIILoader CreateSuitableLoader(XmlDocument doc)
        {
            var tnm = doc["transport_network_map"];

            /* if the document root is not of type "transport_network_map", then the file must be of version 6, where it was called "content" */
            if (tnm == null)
            {
                if (doc["content"] == null)
                    return null;
                else
                    return new ASCIILoaderV6();
            }

            var version = tnm.GetAttribute("version");

            switch (version)
            {
                case "7":
                    return new ASCIILoaderV7();

                default:
                    return null;
            }
        }
    }
}
