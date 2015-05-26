using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    class Transfer : Transaction
    {

        private int amount;
        private Account fromAccount;
        private Account toAccount;

        public override int GetInfluence(Account account)
        {
            if (fromAccount == account)
                return -amount;
            if (toAccount == account)
                return amount;
         
            throw new Exception("Unknown account: " + account);
        }

        public Transfer(Account fromAccount, Account toAccount, int amount)
        {
            if (amount<=0 )
                throw new Exception("Amount to transfer has to be positive.");

            if (amount > fromAccount.GetBalance())
                throw new Exception("The account " + fromAccount + " has insufficient balance.");

           this.fromAccount = fromAccount;
           this.toAccount = toAccount;
           this.amount = amount;
           fromAccount.AssignTransaction(this);
           toAccount.AssignTransaction(this);

        }
                 
        public override string ToString()
        {
         return "Transfer of " + amount + " from "+ fromAccount + " to "+ toAccount;
        }
    }
}



