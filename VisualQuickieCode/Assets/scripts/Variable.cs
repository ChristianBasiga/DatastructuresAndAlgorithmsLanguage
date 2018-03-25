using System.Collections;
using System.Collections.Generic;


namespace DataStructureLanguage.Syntax.Util
{
    //This will be used by view and model,
    public class Variable 
    {

        public readonly string name;
        int value;

        public int Value
        {
            get { return value; }
            set
            {
                this.value = value;
            }
        }

        public Variable(string name)
        {
            this.name = name;
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

        public static Variable operator+(Variable a, Variable b)
        {
            //Making a literal
            Variable c = new Variable(null);
            c.value = a.value + b.value;
            return c;
        }
        public static Variable operator -(Variable a, Variable b)
        {
            Variable c = new Variable(null);
            c.value = a.value - b.value;
            return c;
        }
        public static Variable operator /(Variable a, Variable b)
        {
            Variable c = new Variable(null);
            c.value = a.value / b.value;
            return c;
        }
        public static Variable operator *(Variable a, Variable b)
        {
            Variable c = new Variable(null);
            c.value = a.value * b.value;
            return c;
        }
        public static Variable operator %(Variable a, Variable b)
        {
            Variable c = new Variable(null);
            c.value = a.value % b.value;
            return c;
        }

    }

    
}