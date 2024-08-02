using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounts
{
    public class AccountsHelper
    {
        protected List<string> _owners = new List<string>() {
            "Alonso Infante Carlos Adrian ",
            "Blanco González Lorna Ylenia",
            "Díaz Rodríguez Victor Manuel ",
            "Domínguez Pérez  Osniel Orlando",
            "García Abreu Yurema del Pilar",
            "García Cabrera Alex",
            "Gilo Carrasco Lilianet de Lourdes",
            "González Fundora Carlos Javier",
            "Hernández Alonso Joel Francisco",
            "Hernández Betancourt Angélica María",
            "Martínez Bravo Darío",
            "Mesa Pedroso Keila",
            "Morales Estorino Frank Ernesto",
            "Ordoñez Rodríguez Luis Miguel",
            "Padrón González Andy",
            "Pérez Omaña Lizanet",
            "Rico Rodríguez Frank David",
            "Ronquillo García Orelbis",
            "Sotolongo Alonso Keythy",
            "Terán Moreno Laura",
            "Yanes De la Cruz Alejandro"
        };        

        protected List<Account> _acounts = new List<Account>();

        public List<Account> Accounts
        {
            get { return _acounts; }
        }

        protected Random _random = new Random();

        protected List<OperationAccount> _operations = new List<OperationAccount>();     

        public AccountsHelper() { }

        private OperationsAccount GetOperation()
        {
            switch (_random.Next(0, 4))
            {
                default:
                case 0: return OperationsAccount.Create;
                case 1: return OperationsAccount.Deposit;
                case 2: return OperationsAccount.Substract;
                case 3: return OperationsAccount.PayInterest;               
            }
        }

        private string GetOwner()
        {
            if (_owners.Count == 0)
                return "";
             
            int index = _random.Next(0, _owners.Count - 1);

            string owner = _owners[index];

            _owners.RemoveAt(index);           

            return owner;
        }

        private float GetIdentifier()
        {
            return Environment.TickCount;
        }

        private Account GetAccount()
        {
            if (_acounts.Count == 0)
                return null;

            return _acounts[_random.Next(0, _acounts.Count - 1)];
        }

        private decimal GetAmount()
        {            
            return _random.Next(1, 1000);
        }

        private void OperationLog(OperationsAccount operation, string owner, float identifier, decimal amount)
        {
            _operations.Insert(0,new OperationAccount(operation,identifier,owner,amount));
        }

        public List<OperationAccount> SimulatingOperation()
        {
            OperationsAccount operation = GetOperation();
            Account account = GetAccount();
            decimal amount = GetAmount();            

            switch (operation)
            {
                default:
                case OperationsAccount.Create:
                    string owner = GetOwner();

                    if (owner != "")
                    {
                        account = new Account(GetIdentifier(), owner);                        

                        amount = account.State.Balance;

                        _acounts.Insert(0, account);
                    }
                                    
                    break;
                case OperationsAccount.Deposit:
                    if (account != null)
                        account.Deposit(amount);
                    break;
                case OperationsAccount.Substract:
                    if (account != null)
                        account.Deposit(GetAmount());
                    break;
                case OperationsAccount.PayInterest:
                    if (account != null)
                        account.Deposit(GetAmount());
                    break;
            }

            if(account!=null)
                OperationLog(operation, account.Owner, account.Identifier, amount);

            return _operations;
        }
    }
}
