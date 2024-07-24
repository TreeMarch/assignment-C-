namespace SpringHeroBank.entity;

public class Transaction
{
    public int id { get; set; }
    public DateTime createdAt { get; set; }
    public typeOfTransaction type { get; set; }
    public double amount { get; set; }
    public string senderAccountNumber { get; set; }
    public string receiverAccountNumber { get; set; }
    public double balanceAfter { get; set; }
    public enum typeOfTransaction // chi duoc phep nhap 3 gia tri o duoi 
    {
        Deposit, Withdraw, Transfer
    }
    
    public Transaction(){}

    public Transaction(int id = default, DateTime createdAt = default, typeOfTransaction type = default, double amount = default, string senderAccountNumber = null, string receiverAccountNumber = null, double balanceAfter = default)
    {
        this.id = id;
        this.createdAt = createdAt;
        this.type = type;
        this.amount = amount;
        this.senderAccountNumber = senderAccountNumber;
        this.receiverAccountNumber = receiverAccountNumber;
        this.balanceAfter = balanceAfter;
    }
}