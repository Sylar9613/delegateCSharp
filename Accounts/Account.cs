using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounts
{
    public class Account:ISubjectAccount
    {
        protected StateAccount _state;
        protected ChangeState _observers;
        protected string _owner;
        protected float _identifier;
        protected bool first = false;

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

            _state = new InitialState(0.00m);
                    
        }

        public void Deposit(decimal amount)
        {
            if (!first)
            {
                first = true;
                _state = new SilverState(0.00m);
                StateAccount auxiliar;
                auxiliar = _state;
                _state = _state.Deposit(amount);
                if (auxiliar != _state)
                {
                    Notify();
                }
            }
            else
            {
                StateAccount auxiliar;
                auxiliar = _state;
                _state = _state.Deposit(amount);
                if (auxiliar != _state)
                {
                    Notify();
                }
            }          
        }

        public void Subtraction(decimal amount)
        {
            if (!first)
            {
                first = true;
                _state = new SilverState(0.00m);
                StateAccount auxiliar;
                auxiliar = _state;
                _state = _state.Subtraction(amount);
                if (auxiliar != _state)
                {
                    Notify();
                }
            }
            else
            {
                StateAccount auxiliar;
                auxiliar = _state;
                _state = _state.Subtraction(amount);
                if (auxiliar != _state)
                {
                    Notify();
                }
            }
        }

        public void PayInterest()
        {
            if (!first)
            {
                first = true;
                _state = new SilverState(0.00m);                
                StateAccount auxiliar;
                auxiliar = _state;
                _state = _state.PayInterest();
                if (auxiliar != _state)
                {
                    Notify();
                }
            }
            else
            {
                StateAccount auxiliar;
                auxiliar = _state;
                _state = _state.PayInterest();
                if (auxiliar != _state)
                {
                    Notify();
                }
            }
            
        }

        public void Attach(IObserverAccount observer)
        {
            _observers += observer.UpdateAccount;
            //_observers.Add(observer);
        }

        public void Detach(IObserverAccount observer)
        {
            _observers -= observer.UpdateAccount;
            //_observers.Remove(observer);
        }

        public void Notify()
        {
            _observers();
            /*
            foreach (IObserverAccount item in _observers)
            {
                item.UpdateAccount();
            }
            */
        }
    }
}
