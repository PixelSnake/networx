using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkMapCreator.EditorElements
{
    public abstract class AbstractStationLabel
    {
        public abstract Point Location { get; set; }
        public abstract string Content { get; set; }

        public abstract void Paint(Graphics g);
    }
}
