using SpringHeroBank.entity;

namespace SpringHeroBank.Interface;

public interface IUserRepository
{
    public void AddUser(User user);
    User findUserByAccountNumber(string accountNumber);
    public User findUserByFullName(string fullName);
    User findUserByPhone(string phone);
    List<User> FindAll();
    public User changeInformation(User user, string accountNumber);

    public void UpdateBalance(User user)
    {
    }
    public User Login(string userName, string password);
    public void Deposit(User user, double amount);
    public void Withdraw();
    public void Transfer();
    List<Transaction> Transactions();
}