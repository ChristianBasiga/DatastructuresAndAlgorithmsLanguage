using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace DataStructureLanguage.Syntax.Util
{
    //This will be used by view and model,
    public class Variable<T> : MonoBehaviour
    {

        T value;

        public T Value
        {
            get { return value; }
            set
            {
                this.value = value;
            }
        }


        public static bool operator <(Variable<T> a, Variable<T> b)
        {
            return a.Value < b.Value;

        }

        public static bool operator >(Variable<T> a, Variable<T> b)
        {
            return a.Value > b.Value;
        }

        public static bool operator ==(Variable<T> a, Variable<T> b)
        {
            return a.Value == b.Value;

        }
        public static bool operator !=(Variable<T> a, Variable<T> b)
        {
            return a.Value != b.Value;

        }
        public static bool operator >=(Variable<T> a, Variable<T> b)
        {
            return a.Value >= b.Value;

        }
        public static bool operator <=(Variable<T> a, Variable<T> b)
        {
            return a.Value <= b.Value;

        }

    }

    
}