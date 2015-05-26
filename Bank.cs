using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    class Bank
    {
        private Account[] accounts;
        private int maxTransactionsPerAccount;
        private string bankName;
        private int nextFree = 0;

        public Bank(string bankName, int maxAccounts, int maxTransactionsPerAccount)
        {
            this.bankName = bankName;
            this.maxTransactionsPerAccount = maxTransactionsPerAccount;
            this.accounts = new Account[maxAccounts];

        }

        public int FindAccount(string name)
        {
            for (int i = 0; i < accounts.Length; ++i)
            {
                if (accounts[i] == null)
                    break;
                
                if (name == accounts[i].GetName())
                    return i;
                
            }
            throw new Exception("Account "+ name+ " not found.");
        }

        public void CreateAccount(string name)
        {
            int length = accounts.Length;
            Account created = new Account(name,maxTransactionsPerAccount);

            if(length <= nextFree)
                throw new Exception(this + " cannot store more accounts.");

            accounts[nextFree] = created;
            ++nextFree;
            
        }

        public void Deposit(string toAccountName, int amount)
        {
            int cuenta = FindAccount(toAccountName);
            Deposit deposito = new Deposit(accounts[cuenta] ,amount);
        }

        public void ListAccounts()
        {
            for (int i = 0; i < accounts.Length; ++i)
            {
                if (accounts[i] != null)
                Console.WriteLine(accounts[i]);
            }
        }

        public void PrintAccount(string AccountToPrint)
        {
            int cuenta = FindAccount(AccountToPrint);
               Console.WriteLine(accounts[cuenta]);
        }

        public void PrintAccountDetails(string AccountToPrintDetails)
        {
            int cuenta = FindAccount(AccountToPrintDetails);
            Console.WriteLine(accounts[cuenta]);
            accounts[cuenta].PrintTransactions();
        }

        public override string ToString()
        {
            return "Bank " + bankName;
        }

        public void Withdraw(string accountForWithdrawalName,int amountToWithdraw)
        {
            int cuenta = FindAccount(accountForWithdrawalName);
            Withdrawal withdraw  = new Withdrawal(accounts[cuenta], amountToWithdraw);
        }

        public void Transfer(string sourceAccount, string destinationAccount, int amountToTransfer)
        {
            int cuentaOrigen = FindAccount(sourceAccount);
            int cuentaDestino = FindAccount(destinationAccount);
            Transfer transferencia = new Transfer(accounts[cuentaOrigen],accounts[cuentaDestino],amountToTransfer);
        }
    }
}
