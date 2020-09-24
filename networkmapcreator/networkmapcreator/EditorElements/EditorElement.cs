using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkMapCreator
{
    public interface EditorElement
    {
        Point Location { get; set; }
        void SelectionModeChanged(bool selected);
    }
}
