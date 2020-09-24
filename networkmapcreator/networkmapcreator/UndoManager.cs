using NetworkMapCreator.EditorElements;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkMapCreator
{
    public class UndoManager
    {
        private int Position { get {return _pos; } set {
                if (value > Actions.Count)
                    _pos = Actions.Count;
                else if (value < 0)
                    _pos = 0;
                else
                    _pos = value;
            } }
        private int _pos = 0;
        private List<UndoAction> Actions = new List<UndoAction>();

        public delegate void UndoQueueChangedEventHandler();
        public event UndoQueueChangedEventHandler UndoQueueChanged;

        public void Push(UndoAction a)
        {
            DeleteAhead(Position++);
            Actions.Add(a);
        }

        private void DeleteAhead(int pos)
        {
            for (int i = Actions.Count - 1; i > pos; --i)
                Actions.RemoveAt(i);
        }

        public void Undo()
        {
            if (Actions.Count == 0 || Position == 0)
                return;

            Actions[Position--].Undo();
            UndoQueueChanged?.Invoke();
        }

        public void Redo()
        {
            if (Actions.Count == 0 || Position >= Actions.Count - 1)
                return;

            Actions[++Position].Redo();
            UndoQueueChanged?.Invoke();
        }

        internal void Reset()
        {
            Actions.Clear();
            Position = 0;
        }
    }

    public class UndoAction
    {
        UndoActionType Type;
        Undoable Subject;
        Point OffsetThen;
        UndoActionDataStation StationData;
        UndoActionDataSegment SegmentData;
        UndoActionDataSticker StickerData;
        List<UndoAction> MultipleActionList;

        public UndoAction(UndoActionType type, Undoable subject, object data = null, List<UndoAction> actions = null)
        {
            Subject = subject;
            Type = type;
            MultipleActionList = actions;

            if (type != UndoActionType.Multiple)
                OffsetThen = subject.Map.grid_offset;

            if (data is UndoActionDataStation)
            {
                StationData = (UndoActionDataStation)data;
            }
            if (data is UndoActionDataSegment)
                SegmentData = (UndoActionDataSegment)data;
        }

        public void Undo()
        {
            switch (Type)
            {
                case UndoActionType.Create:
                    Subject.Deleted = true;
                    break;

                case UndoActionType.Modify:
                    if (Subject is Station)
                    {
                        SwapLocation();
                    }
                    else if (Subject is Segment)
                    {
                        var s = (Segment)Subject;

                        var mode = s.LineMode;
                        //var display = s.DisplayLineLabel;

                        s.LineMode = SegmentData.LineMode;
                        //s.DisplayLineLabel = SegmentData.LineLabelMode;

                        SegmentData.LineMode = mode;
                        //SegmentData.LineLabelMode = display;
                    }
                    else if (Subject is Sticker)
                    {
                        var s = (Sticker)Subject;

                        SwapLocation();

                        var bounds = s.Bounds;
                        s.Bounds = StickerData.Bounds;
                        StickerData.Bounds = bounds;
                    }
                    break;

                case UndoActionType.Delete:
                    Subject.Deleted = false;
                    break;

                case UndoActionType.Multiple:
                    foreach (var a in MultipleActionList)
                        a.Undo();
                    break;
            }

            Form1.ActivePanel.Refresh();
        }

        public void Redo()
        {
            switch (Type)
            {
                case UndoActionType.Create:
                    Subject.Deleted = false;
                    break;

                case UndoActionType.Modify:
                    if (Subject is Station)
                    {
                        SwapLocation();
                    }
                    else if (Subject is Segment)
                    {
                        var s = (Segment)Subject;

                        var mode = s.LineMode;
                        //var display = s.DisplayLineLabel;

                        s.LineMode = SegmentData.LineMode;
                        //s.DisplayLineLabel = SegmentData.LineLabelMode;

                        SegmentData.LineMode = mode;
                        //SegmentData.LineLabelMode = display;
                    }
                    else if (Subject is Sticker)
                    {
                        var s = (Sticker)Subject;

                        SwapLocation();

                        var bounds = s.Bounds;
                        s.Bounds = StickerData.Bounds;
                        StickerData.Bounds = bounds;
                    }
                    break;

                case UndoActionType.Delete:
                    Subject.Deleted = true;
                    break;

                case UndoActionType.Multiple:
                    foreach (var a in MultipleActionList)
                        a.Redo();
                    break;
            }

            Form1.ActivePanel.Refresh();
        }

        private void SwapLocation()
        {
            if (!(Subject is EditorElement))
                return;

            var s = Subject as EditorElement;
            var loc = s.Location;
            var got = OffsetThen;

            if (s is Sticker)
            {
                s.Location = RestoreLocation(StickerData.Location, OffsetThen, Subject.Map.grid_offset);
                StickerData.Location = loc;
                OffsetThen = Subject.Map.grid_offset;
            }
            else if (s is Station)
            {
                s.Location = RestoreLocation(StationData.Location, OffsetThen, Subject.Map.grid_offset);
                StationData.Location = loc;
                OffsetThen = Subject.Map.grid_offset;
            }
        }

        private static Point RestoreLocation(Point relative, Point offset_then, Point offset_now)
        {
            return new Point(relative.X - offset_then.X + offset_now.X, relative.Y - offset_then.Y + offset_now.Y);
        }
    }

    public struct UndoActionDataStation
    {
        public Point Location;
    }

    public struct UndoActionDataSticker
    {
        public Point Location;
        public Rectangle Bounds;
    }

    public struct UndoActionDataSegment
    {
        public SegmentLineMode LineMode;
        public LineLabelDisplayMode LineLabelMode;
    }

    /*
        What kind of action is the original action?
        Was this element created, modified oder deleted?
    */
    public enum UndoActionType
    {
        Create,
        Modify,
        Delete,
        Multiple
    }
}
