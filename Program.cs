using System;

namespace ATMApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //PRINT THE OPTIONS
            void printOptions()
            {
                Console.WriteLine("Please choose one from following options");
                Console.WriteLine("1. Deposit");
                Console.WriteLine("2. Withdraw");
                Console.WriteLine("3. Show Balance");
                Console.WriteLine("4. Exit");
            }
            //DESPOSIT FUNCTION
            void deposit(CardHolder currentUser)
            {
                Console.WriteLine("How much money would you like to deposit: ");
                double deposit = Double.Parse(Console.ReadLine());
                currentUser.setBalance(deposit);
                Console.WriteLine("Thank you for your $$. Your new balance is: " + currentUser.getBalance());
            }

            //WITHDRAW FUNCTION
            void withDraw(CardHolder currentUser)
            {
                Console.WriteLine("How much money do you want to withdraw: ");
                double withdrawal = Double.Parse(Console.ReadLine());
                //check if the user has enough money
                if (currentUser.getBalance() < withdrawal)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You don't have enough money");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    currentUser.setBalance(currentUser.getBalance() - withdrawal);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Giving you the money....");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            //BALANCE FUNCTION
            void balance(CardHolder currentUser)
            {
                Console.WriteLine("Current banalce is " + currentUser.getBalance());
            }

            //SOMETHING LIKE DB, NAMES, PINS, BALANCES AND ETC.
            List<CardHolder> cardHolders = new List<CardHolder>();
            cardHolders.Add(new CardHolder("124654566897134271", 4321, "Irina", "Mkrtchyan", 564042.64));
            cardHolders.Add(new CardHolder("154646564589731238", 0123, "Varuzhan", "Mkrtchyan", 45613.78));
            cardHolders.Add(new CardHolder("129897465132798132", 3050, "Harutyun", "Mkrtchyan", 12540.2));
            cardHolders.Add(new CardHolder("123456789123456789", 1234, "Mari", "Mkrtchyan", 2120.5));

            //Prompt user
            Console.WriteLine("Welcome to SimpleATM!");
            Console.WriteLine("Please, insert your debit card");
            string debitCardNum = "";
            CardHolder currentUser;

            while (true)
            {
                try
                {
                    debitCardNum = Console.ReadLine();
                    //Check againt our DB
                    currentUser = cardHolders.FirstOrDefault(a => a.cardNum == debitCardNum);
                    if (currentUser != null)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Card not recogised. Please, register in the bank");
                    }
                }
                catch
                {
                    Console.WriteLine("Card not recogised. Please, register in the bank");
                }
            }
            Console.WriteLine("Please enter you pin");
            int userPin = 0;
            while (true)
            {
                try
                {
                    userPin = int.Parse(Console.ReadLine());
                    //Check againt our DB
                    if (currentUser.getPin() == userPin)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Incorrect pin. Please, try again");
                    }
                }
                catch
                {
                    Console.WriteLine("Card not recogised. Please, register in the bank");
                }
            }
            Console.WriteLine("Welcome " + currentUser.getFirstName());
            int option = 0;
            while(option != 4)
            {
                printOptions();
                try
                {
                    option = int.Parse(Console.ReadLine());
                }
                catch { }
                if (option == 1)
                    deposit(currentUser);
                else if (option == 2)
                    withDraw(currentUser);
                else if (option == 3)
                    balance(currentUser);
                else
                    option = 0;
            }
            Console.WriteLine("Thank you! See you again! ");
        }

    }

}