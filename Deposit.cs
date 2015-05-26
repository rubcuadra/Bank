using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    class Deposit : Transaction
    {

        private int amount;
        private Account toAccount;

        public Deposit(Account toAccount, int Amount)
        {
            if (Amount <= 0)
                throw new Exception("Amount to deposit has to be positive.");



            this.amount = Amount;
            this.toAccount = toAccount;
            toAccount.AssignTransaction(this);

            

        }

        public override int GetInfluence(Account account)
        {

            if (toAccount != account)
                throw new Exception("Unknown account: " + account);

            return amount;

        }

        public override string ToString()
        {
            return "Deposit of " + amount + " to " + toAccount;
        }

    }

}

