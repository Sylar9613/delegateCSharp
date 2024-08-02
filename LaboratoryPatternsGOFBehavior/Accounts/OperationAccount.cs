using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounts
{
    public class OperationAccount
    {
        protected OperationsAccount _operation;
        protected float _identifier;
        protected string _owner;
        protected decimal _amount;

        public OperationAccount(OperationsAccount operation, float identifier, string owner, decimal amount)
        {
            _operation = operation;
            _identifier = identifier;
            _owner = owner;
            _amount = amount;
        }

        public string Operation
        {
            get { return _operation.ToString(); }
        }

        public string Identifier
        {
            get { return _identifier.ToString(); }
        }

        public string Owner
        {
            get { return _owner.ToString(); }
        }

        public string Amount
        {
            get { return _amount.ToString(); }
        }
    }
}
