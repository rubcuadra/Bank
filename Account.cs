using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    class Account
    {
        private string name;
        private int nextFree = 0;
        private Transaction[] transactions;

        public Account(string name, int maxTransactions)
        {

            if (maxTransactions <= 0)
                throw new Exception("Number of transactions has to be positive.");

            this.name = name;
            transactions = new Transaction[maxTransactions];

        }

        public string GetName()
        {
            return name;
        }

        public int GetBalance()
        {
            int balance = 0;
            for (int i = 0; i < transactions.Length; ++i)
            {
                if (transactions[i] == null)
                    break;
                else
                    balance += transactions[i].GetInfluence(this);
                
            }
                return balance;
        }

        public void AssignTransaction(Transaction transaction)
        {
            if(nextFree == transactions.Length)
                    throw new Exception(this + " cannot store more transactions.");

            transactions[nextFree] = transaction;
            ++nextFree;
        }

        public override string ToString()
        {
            string cuenta = "Account " + name +", balance: " + this.GetBalance();
            return cuenta;
        }
        public void PrintTransactions()
        {
            for (int i = 0; i < transactions.Length; ++i)
            {
                if (transactions[i] == null)
                    break;

                   Console.WriteLine(transactions[i] + ", influence: " + transactions[i].GetInfluence(this));
            }
        }
    }
}
