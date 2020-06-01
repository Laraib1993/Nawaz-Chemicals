using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace reportgeneration
{
    class gridviewvalue
    {
        public string Text
        {
            get;
            set;
        }
        public int Value
        {
            get;
            set;
        }
        public override string ToString()
        {
            return Text;
        }

        public gridviewvalue(string text, int value)
        {
            this.Text = text;
            this.Value = value;
        }

    }
}