using System.Threading.Channels;
using SpringHeroBank.entity;
using SpringHeroBank.repository;

namespace SpringHeroBank.controller;

public class UserController : UserRepo
{
    public UserRepo userRepository = new UserRepo();
    public TransactionRepo transactionRepository = new TransactionRepo();
    public MainMenu mainMenu = new MainMenu();

    public void Register()
    {
        User user = new User();
        Console.WriteLine("Write your information here :");
        Console.WriteLine("User Name :");
        user.userName = Console.ReadLine();
        Console.WriteLine("Input Full Name: ");
        user.fullName = Console.ReadLine();
        Console.WriteLine("Input Phone Number: ");
        user.phone = Console.ReadLine();
        Console.WriteLine("Input PassWord: ");
        user.password = Console.ReadLine();
        Console.WriteLine("Type of User 1 for 'User' or 2 for 'Admin'");
        var role = Console.ReadLine();
        if (role == "1")
        {
            user.role = User.UserType.User;
        }
        else if (role == "2")
        {
            user.role = User.UserType.Admin;
        }
        else
        {
            Console.WriteLine("Invalid choice");
            return;
        }
        
        
        Random random = new Random();
        String randomDigits = "";
        for (int i = 0; i < 10; i++)
        {
            randomDigits += random.Next(0, 10).ToString();
        }
        user.accountNumber = randomDigits;
        userRepository.AddUser(user);
    }
    public void Login()
    {
        User user = new User();
        Console.WriteLine("Username :");
        string userName = Console.ReadLine();
        Console.WriteLine("Password: ");
        string password = Console.ReadLine();
        user = userRepository.Login(userName, password);
        if (user != null)
        {
            if (user.role == User.UserType.Admin)
            {
                mainMenu.AdminMenu(user);
            }
            else
            {
                mainMenu.UserMenu(user);
                
            }
        }
    }

    public void ShowUserInformation(User user)
    {
        Console.WriteLine("{0, -5} | {1, -15} | {2, -15} | {3, -25} | {4, -15} | {5, -10} | {6, -10} | {7, -10} | {8, -10}",
            "ID", "User Name", "Password", "Full Name", "Account Number", "Phone", "Balance", "Role", "Status");
        Console.WriteLine(new string('-', 120)); // Separator line for better readability
        Console.WriteLine("{0, -5} | {1, -15} | {2, -15} | {3, -25} | {4, -15} | {5, -10} | {6, -10} | {7, -10} | {8, -10}",
            user.id, user.userName, user.password, user.fullName, user.accountNumber, user.phone, user.balance.ToString("F2"), user.role, user.status == 0 ? "Locked" : "Active");
    }

    public void ShowUser()
    {
        var users = userRepository.FindAll();
        if (users == null)
        {
            Console.WriteLine("No users found.");
            return;
        }

        Console.WriteLine("{0, -10} | {1, -20} | {2, -20} | {3, -20} | {4, -20} | {5, -20} | {6, -20} | {7, -20} | {8, -20} ",
            "Id", "User Name", "Password", "Full Name", "Account Number", "Phone", "Balance", "Role", "Status");

        foreach (var user in users)
        {
            Console.WriteLine("{0, -10} | {1, -20} | {2, -20} | {3, -20} | {4, -20} | {5, -20} | {6, -20} | {7, -20} | {8, -20} ",
                user.id, user.userName, user.password, user.fullName, user.accountNumber, user.phone, user.balance, user.role, user.status);
        }
    }

    public void findUserByFullName()
    {
        Console.WriteLine("Type Full Name :");
        var fullName = Console.ReadLine();
        var user = userRepository.findUserByFullName(fullName);
        ShowUserInformation(user);
    }

    public void findUserByAccountNumber()
    {
        Console.WriteLine("Type Account Number :");
        var accountNumber = Console.ReadLine();
        var user = userRepository.findUserByAccountNumber(accountNumber);
        ShowUserInformation(user);
    }

    public void findUserByPhone()
    {
        Console.WriteLine("Type Phone Number : ");
        var phoneNumber = Console.ReadLine();
        var user = userRepository.findUserByPhone(phoneNumber);
        ShowUserInformation(user);
    }
    
    public void Deposit()
    
    {
        
    }
    public void Withdraw()
    {
        
    }
    public void Transfer()
    {
        
    }
    

}