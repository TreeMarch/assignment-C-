using SpringHeroBank.controller;
using SpringHeroBank.entity;

namespace SpringHeroBank;

public class MainMenu
{
    public void Main()
    {
        UserController userController = new UserController();
        while (true)
        {
            Console.WriteLine("------------Spring Hero Bank------------");
            Console.WriteLine("1. Register.");
            Console.WriteLine("2. Login.");
            Console.WriteLine("3. Exit.");
            Console.WriteLine("——————————————————-");
            Console.Write("Type your choice (1,2,3): ");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    userController.Register();
                    break;
                case "2":
                    userController.Login();
                    break;
                case "3":
                    break;
                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }
        }
    }

    public void AdminMenu(User user)
    { 
        UserController userController = new UserController();
        TransactionController transactionController = new TransactionController();
        while (true)
        {
            Console.Clear();
            Console.WriteLine("------ Spring Hero Bank ------");
            Console.WriteLine($"Welcome back Admin {user.fullName}");
            Console.WriteLine("1. User List.");
            Console.WriteLine("2. Transaction List");
            Console.WriteLine("3. Find User By Name");
            Console.WriteLine("4. Find User By Account Number");
            Console.WriteLine("5. Find User by Phone Number");
            Console.WriteLine("6. Add New User.");
            Console.WriteLine("7. Lock and Unlock Account");
            Console.WriteLine("8. Find Transaction History by Account Number ");
            Console.WriteLine("9. Change Account Information");
            Console.WriteLine("10. Change Account Password");
            Console.WriteLine("11. Exit.");
            Console.WriteLine("----------------------------------------");
            Console.Write("Type your choice (1 to 11): ");
            var choice = Console.ReadLine();
            Console.WriteLine(choice);
            switch (choice)
            {
                case "1":
                    userController.ShowUser();
                    break;
                case "2":
                    // transactionController.DisplayTransaction();
                    break;
                case "3":
                    userController.findUserByFullName();
                    break;
                case "4":
                    userController.findUserByAccountNumber();
                    break;
                case "5":
                    userController.findUserByPhone();
                    break;
                case "6":
                    userController.Register(); // them nguoi moi 
                    break;
                case "7":
                    // userController.LockUnlockUserAccount();
                    break;
                case "8":
                    // transactionController.DisplayTransactionByAccountNumber();
                    break;
                case "9":
                    // userController.UpdatePersonalInfo();
                    break;
                case "10":
                    // userController.UpdatePassword();
                    break;
                case "11":
                    break;
                default:
                    Console.WriteLine("Invalid choice, Try Again!");
                    break;
            }
            Console.WriteLine("Enter to continue!");
            Console.ReadLine();
        }
    }

    public void UserMenu(User user)
    {
        UserController userController = new UserController();
        TransactionController transactionController = new TransactionController();
        while (true)
        {
            // Console.Clear();
            Console.WriteLine("------ Spring Hero Bank ------");
            Console.WriteLine($"Welcome back User {user.userName}");
            Console.WriteLine("1. Deposit.");
            Console.WriteLine("2. Withdraw.");
            Console.WriteLine("3. Transfer.");
            Console.WriteLine("4. Balance");
            Console.WriteLine("5. Change Information");
            Console.WriteLine("6. Change Password");
            Console.WriteLine("7. Transaction History.");
            Console.WriteLine("8. Exit.");
            Console.WriteLine("----------------------------------------");
            Console.Write("Enter your choice (1 to 8): ");

            var choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    userController.Deposit();
                    break;
                case "2":
                    userController.Withdraw();
                    break;
                case "3":
                    userController.Transfer();
                    break;
                case "4":
                    // userController.QueryBalance();
                    break;
                case "5":
                    // userController.UpdatePersonalInfo();
                    break;
                case "6":
                    // userController.UpdatePassword();
                    break;
                case "7":
                    // transactionController.DisplayTransactionByAccountNumber();
                    break;
                case "8":
                    break;
                default:
                    Console.WriteLine("Invalid choice, Try Agian");
                    Console.ReadLine();
                    break;
            }
        }
    }
}