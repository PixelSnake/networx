using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkMapCreator
{
    class IconsBrowserItem
    {
        public Image Image { get; private set; }
        public String Description { get; private set; }

        public IconsBrowserItem(Image i, string descr)
        {
            Image = i;
            Description = descr;
        }
    }
}
