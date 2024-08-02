using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounts
{
    public abstract class StateAccount
    {
        protected decimal _balance;
        protected decimal _interest;
        protected decimal _lowerLimit;
        protected decimal _upperLimit;

        public decimal Balance
        {
            get { return _balance; }
        }

        public abstract StateAccount Deposit(decimal amount);

        public abstract StateAccount Subtraction(decimal amount);

        public abstract StateAccount PayInterest();
    }
}
