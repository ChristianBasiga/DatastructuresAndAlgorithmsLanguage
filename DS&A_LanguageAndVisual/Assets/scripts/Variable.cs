using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace DataStructureLanguage.Syntax.Util
{
    //This will be used by view and model,
    public class Variable : MonoBehaviour
    {

        int value;

        public int Value
        {
            get { return value; }
            set
            {
                this.value = value;
            }
        }


        public static bool operator <(Variable a, Variable b)
        {
            return a.Value < b.Value;

        }

        public static bool operator >(Variable a, Variable b)
        {
            return a.Value > b.Value;
        }

        public static bool operator ==(Variable a, Variable b)
        {
            return a.Value == b.Value;

        }
        public static bool operator !=(Variable a, Variable b)
        {
            return a.Value != b.Value;

        }
        public static bool operator >=(Variable a, Variable b)
        {
            return a.Value >= b.Value;

        }
        public static bool operator <=(Variable a, Variable b)
        {
            return a.Value <= b.Value;

        }

    }

    
}