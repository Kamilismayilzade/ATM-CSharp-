using System;


public class cardHolder
{
    public string cardNumber;
    public int cardPin;
    public string firstName;
    public string lastName;
    public double cardBalance;


    public cardHolder (string cardNumber, int cardPin, string firstName, string lastName, double cardBalance)
    {
        this.cardNumber = cardNumber;
        this.cardPin = cardPin;
        this.firstName = firstName;
        this.lastName = lastName;
        this.cardBalance = cardBalance;
    }

    // Getters

    public string GetCardNumber ()
    {
        return cardNumber;
    }

    public int GetCardPin ()
    {
        return cardPin;
    }

    public string GetFirstName ()
    {
        return firstName;
    }

    public string GetLastName ()
    {
        return lastName;
    }

    public double GetCardBalance ()
    {
        return (cardBalance);
    }

    // Setters

    public void  SetCardNumber (string myCardNumber)
    {
        cardNumber = myCardNumber;
    }

    public void setCardPin(int myCardPin)
    {
        cardPin = myCardPin;
    }

    public void SetFirstName (string myFirstName)
    {
        firstName = myFirstName;
    }

    public void SetLastName(string myLastName)
    {
        lastName = myLastName;
    }

    public void SetCardBalance (double myCardBalance)
        {
            cardBalance = myCardBalance;
        }


    //  ---------------------Main-------------------------

    public static void Main(string[] args)
    {
        void PrintCardOptions ()
        {
            Console.WriteLine("*** Please Select One of the Transactions below *** \n");

            Console.WriteLine("* 1. Deposit 💸 *");
            Console.WriteLine("* 2. Cash Withdrawal 💰 *");
            Console.WriteLine("* 3. Balance Inquiry 💵 *");
            Console.WriteLine("* 4. Exit My ATM  🤑  *");
        }

        void Deposit (cardHolder currentUser)
        {
            Console.WriteLine("How much money 💰 would you like to Deposit? ");
            double myDeposit = Double.Parse(Console.ReadLine());

            currentUser.SetCardBalance(currentUser.GetCardBalance() + myDeposit);
            Console.WriteLine("🤑🤑🤑. New Balance 💰 : " + currentUser.GetCardBalance());
        }

        void WithDraw (cardHolder currentUser)
        {
            Console.WriteLine("How much money 💰 would you like to WithDraw? ");
            double myWithdrawal = double.Parse(Console.ReadLine());

            if (currentUser.GetCardBalance() < myWithdrawal)
            {
                Console.WriteLine("Sorry 😥. Not Enough Money in your Balance!!!");
            }

            else
            {
                double myNewBalance = currentUser.GetCardBalance() - myWithdrawal;
                currentUser.SetCardBalance(myNewBalance);
                Console.WriteLine("Have a Nice Day 😊. Thank you 🙏.");
            }

        }

        void Balance (cardHolder currentUser)
        {
            Console.WriteLine("Your Current Balance 💸 : " + currentUser.GetCardBalance());
        }

        //-------------------------------List------------------------------

        List<cardHolder> cardHolders = new List<cardHolder> ();

        cardHolders.Add(new cardHolder("6011000991300009", 6789, "Bruce", "Wayne", 900.99));
        cardHolders.Add(new cardHolder("5425233430109903", 1234, "Alfred", "Pennyworth", 800.99));
        cardHolders.Add(new cardHolder("4001919257537193", 1001, "Selina", "Kyle", 387.34));
        cardHolders.Add(new cardHolder("6062826786276634", 9988, "Oswald ", "Cobblepot", 782.19));


        // --------------------------------Start-------------------------------

        Console.WriteLine("🦇🦇🦇 Welcome to the GothamCityATM 🦇🦇🦇 \n");
        Console.WriteLine("😇 Please Insert your Debit Card to the ATM 😇 \n");

        string myDebitCardNumber = "";
        cardHolder currentUser;

        // 1.

        while (true)
        {

            try
            {
                myDebitCardNumber = Console.ReadLine();
                currentUser = cardHolders.FirstOrDefault(a => a.cardNumber == myDebitCardNumber); // search in List match for item

                if (currentUser != null)
                {
                    break;
                }

                else
                {
                    Console.WriteLine("Error✨✨✨. Your Card is not Recognized. 😔 . Please Try Again.");
                }
            } 
            catch
            {
                Console.WriteLine("Error✨✨✨. Your Card is not Recognized. 😔 . Please Try Again.");
            }

        }

        // 2.

        Console.WriteLine("Please Enter your PIN: 🦇");
        int currentUserPin = 0;

        while (true)
        {

            try
            {
                currentUserPin = int.Parse(Console.ReadLine());
               

                if (currentUser.GetCardPin() == currentUserPin)
                {
                    break;
                }

                else
                {
                    Console.WriteLine("Error✨✨✨. Your PIN is Incorrect. 😔 . Please Try Again.");
                }
            }
            catch
            {
                Console.WriteLine("Error✨✨✨. Your PIN is Incorrect. 😔 . Please Try Again.");
            }

        }

        // 3.

        Console.WriteLine("Welcome " + currentUser.GetFirstName() + "🤗");

        int options = 0;

        do
        {

            PrintCardOptions();

            try
            {
                options = int.Parse(Console.ReadLine());
            }

            catch
            {

            }

            if (options == 1)
            {
                Deposit(currentUser);
            }

            else if (options == 2)
            {
                WithDraw(currentUser);
            }

            else if (options == 3)
            {
                Balance(currentUser);
            }

            else if (options == 4)
            {
                break;
            }

            else
            {
                options = 0;
            }


        } while (options != 4);

        Console.WriteLine("😄😄😄 Thank You for Your Service. Have a Good Day. 😄😄😄");

    }

}