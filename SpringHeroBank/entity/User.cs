namespace SpringHeroBank.entity;

public class User
{
    public int id { get; set; }
    public string userName { get; set; }
    public string password { get; set; }
    public string fullName { get; set; }
    public string accountNumber { get; set; }
    public string phone { get; set; }
    public double balance { get; set; } = 0;
    public DateTime createdAt { get; set; }
    public List<Transaction> Transaction { get; set; } = new List<Transaction>();
    public UserType role { get; set; }
    public int status { get; set; } 
    public enum UserType
    {
        User, Admin
    }
    
    public User(){}
    public User(int id, string userName, string password, string fullName, string accountNumber, string phone, double balance, DateTime createdAt, UserType role, int status)
    {
        this.id = id;
        this.userName = userName;
        this.password = password;
        this.fullName = fullName;
        this.accountNumber = accountNumber;
        this.phone = phone;
        this.balance = balance;
        this.createdAt = createdAt;
        this.role = role;
        this.status = status;
    }
}