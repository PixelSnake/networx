using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkMapCreator.Utilities
{
    /// <summary>
    /// Takes a various amount of objects of type T and compares them for equality
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class EqualityCollector<T>
    {
        public bool AllEqual
        {
            get
            {
                return _allequal;
            }
            private set
            {
                _allequal = value;
            }
        }
        private bool _allequal = true;
        private bool ValueSet = false;
        public T Value
        {
            get
            {
                return _value;
            }
            set
            {
                _value = value;
            }
        }
        private T _value;

        public T Push(T t)
        {
            if (!ValueSet)
            {
                Value = t;
                ValueSet = true;
            }

            //System.Diagnostics.Debug.WriteLine("Pushed new Value: " + t + ". It is " + (t.Equals(Value) ? "" : "not ") + "equal to the others.");
            AllEqual &= t.Equals(Value);
            return t;
        }
    }
}
