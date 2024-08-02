using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounts
{
    public class RedState:StateAccount
    {
        protected decimal _serviceFee;

        public RedState(decimal balance)
        {
            _balance = balance;

            _interest = 0.00m;
            _lowerLimit = -100.00m;
            _upperLimit = 0.00m;
            _serviceFee = 15.00m;
        }

        private StateAccount StateChangeCheck()
        {
            if (_balance > _upperLimit)
                return new SilverState(_balance);

            return this;
        }

        public override StateAccount Deposit(decimal amount)
        {
            _balance += amount;

            return StateChangeCheck();
        }

        public override StateAccount Subtraction(decimal amount)
        {
            _balance -= _serviceFee;

            return this;
        }

        public override StateAccount PayInterest()
        {
            return this;
        }
    }
}
