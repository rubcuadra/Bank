using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    class Withdrawal: Transaction
 {
        private int amount;
        private Account fromAccount;
        
        public override int GetInfluence(Account account)
        {

            if (fromAccount != account)
                throw new Exception("Unknown account: " + account);

            return -amount;

        }
        public override string ToString()
        {
                                         
            return "Withdrawal of " + amount + " from " + fromAccount;

        }

        public Withdrawal(Account fromAccount, int amount)
        {

            if (amount<=0 )
                throw new Exception("Amount to withdraw has to be positive.");

            if (amount > fromAccount.GetBalance())
                throw new Exception("The account " + fromAccount + " has insufficient balance.");

           this.amount = amount;
           this.fromAccount = fromAccount;
           fromAccount.AssignTransaction(this);      
        }
    }
}


