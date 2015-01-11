using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class CsCalculator
    {
		public CsCalculator()
        {
            OutputValue = 0;
        }

        public double OutputValue
        {
            get;
            private set;
        }

        public void add(double value)
        {
            this.OutputValue += value;
        }

        public void subtract(double value)
        {
            this.OutputValue -= value;
        }

        public void multiply(double value)
        {
            this.OutputValue *= value;
        }

        public void divide(double value)
        {
            if (value == 0)
            {
                //do nothing
            }
            else
            {
                this.OutputValue /= value;
            }
            
        }
    }
}
