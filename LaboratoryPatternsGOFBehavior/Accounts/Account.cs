using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounts
{
    public class Account
    {
        protected StateAccount _state;
        protected string _owner;
        protected float _identifier;

        public StateAccount State
        {
            get { return _state; }
        }

        public decimal Balance
        {
            get { return _state.Balance; }
        }

        public string Owner
        {
            get { return _owner; }
        }

        public float Identifier
        {
            get { return _identifier; }
        }

        public Account(float identifier, string owner)
        {
            _identifier = identifier;
            _owner = owner;

            _state = new SilverState(0.00m);            
        }

        public void Deposit(decimal amount)
        {
            _state = _state.Deposit(amount);
        }

        public void Subtraction(decimal amount)
        {
            _state = _state.Subtraction(amount);
        }

        public void PayInterest()
        {
            _state = _state.PayInterest();
        }            
    }
}
