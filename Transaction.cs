using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank

{
   abstract class Transaction
    {
       
        public abstract int GetInfluence(Account account);
       
        public override abstract string ToString();
    }
}

