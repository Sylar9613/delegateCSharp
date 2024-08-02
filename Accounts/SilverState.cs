using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounts
{
    public class SilverState:StateAccount
    {
        public SilverState(decimal balance)
        {
            _balance = balance;

            _interest = 0.00m;
            _lowerLimit = 0.00m;
            _upperLimit = 1000.00m;
        }

        private StateAccount StateChangeCheck()
        {
            if (_balance < _lowerLimit)
                return new RedState(_balance);
            else if (_balance > _upperLimit)
                return new GoldState(_balance);

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
