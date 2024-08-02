using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounts
{
    public class GoldState:StateAccount
    {
        public GoldState(decimal balance)
        {
            _balance = balance;

            _interest = 0.05m;
            _lowerLimit = 1000.00m;
            _upperLimit = 10000000.00m;
        }
        private StateAccount StateChangeCheck()
        {
            if (_balance < 0.00m)
                return new RedState(_balance);
            else if (_balance < _lowerLimit)
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
            _balance -= amount;

            return StateChangeCheck();
        }

        public override StateAccount PayInterest()
        {
            _balance = _interest * _balance;

            return StateChangeCheck();
        }
    }
}
