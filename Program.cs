using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    class Program
    {
        static string ReadString(string prompt)
        {
            Console.WriteLine(prompt + ":");
            return Console.ReadLine();
        }

        static int ReadInt(string prompt)
        {
            return int.Parse(ReadString(prompt));
        }

        static int AskChoice()
        {
            Console.WriteLine("1) Create account");
            Console.WriteLine("2) Deposit");
            Console.WriteLine("3) Withdraw");
            Console.WriteLine("4) Transfer");
            Console.WriteLine("5) List accounts");
            Console.WriteLine("6) Print account");
            Console.WriteLine("7) Print account details");
            Console.WriteLine("0) Exit");
            return ReadInt("Your choice");
        }

        static void Main()
        {

            string bankName = ReadString("Bank name");
            int maxAccounts = ReadInt("Max. accounts");
            int maxTransactionsPerAccount = ReadInt("Max. transactions per account");
            Bank bank = new Bank(bankName, maxAccounts, maxTransactionsPerAccount);

            int usersChoice;
            do
            {
                Console.WriteLine(bank);
                usersChoice = AskChoice();
                try
                {
                    switch (usersChoice)
                    { 
                        case 1:
                            string newAccountName = ReadString("New account name");
                            bank.CreateAccount(newAccountName);
                            break;
                        case 2:
                            string accountForDepositName = ReadString("Name of account for the deposit");
                            int amountToDeposit = ReadInt("Amount to deposit");
                            bank.Deposit(accountForDepositName, amountToDeposit);
                            break;
                        case 3:
                            string accountForWithdrawalName = ReadString("Name of account for the withdrawal");
                            int amountToWithdraw = ReadInt("Amount to withdraw");
                            bank.Withdraw(accountForWithdrawalName, amountToWithdraw);
                            break;
                        case 4:
                            string sourceAccountForTransferName = ReadString("Name of source account for the transfer");
                            string destinationAccountForTransferName = ReadString("Name of destination account for the transfer");
                            int amountToTransfer = ReadInt("Amount to transfer");
                            bank.Transfer(sourceAccountForTransferName, destinationAccountForTransferName, amountToTransfer);
                            break;
                        case 5:
                            bank.ListAccounts();
                            break;
                        case 6:
                            string accountToPrintName = ReadString("Name of account to print");
                            bank.PrintAccount(accountToPrintName);
                            break;
                        case 7:
                            string accountToPrintDetailsName = ReadString("Name of account to print details");
                            bank.PrintAccountDetails(accountToPrintDetailsName);
                            break;
                        case 0:
                            break;
                        default:
                            throw new Exception("Unknown choice.");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error: " + e.Message);
                }
            }
            while (usersChoice != 0);
        }
    }
}
