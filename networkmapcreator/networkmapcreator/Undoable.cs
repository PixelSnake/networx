using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkMapCreator
{
    public class Undoable
    {
        public Map Map { get; set; }
        public bool Deleted = false;

        public void Delete(bool push = true)
        {
            Deleted = true;

            if (push)
                Map.UndoManager.Push(new UndoAction(UndoActionType.Delete, this));
        }
    }
}
