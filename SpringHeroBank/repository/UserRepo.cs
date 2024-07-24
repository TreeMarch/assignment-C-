using System.Data;
using System.Data.Common;
using MySqlConnector;
using SpringHeroBank.entity;
using SpringHeroBank.Interface;

namespace SpringHeroBank.repository;

public class UserRepo : IUserRepository
{
    private const string MySqlConnectionString = "server=127.0.0.1;uid=root;" + "pwd=;database=springherobank";

    public void AddUser(User user)
    {
        var conn = new MySqlConnection(MySqlConnectionString);
        conn.Open();
        String query = "INSERT INTO users (user_name, password, full_name, account_number, phone, balance,created_at, role, status) " +
                       "VALUES (@userName, @password, @fullName, @phone, @accountNumber, @balance,@createdAt ,@role, @status)";
        var command = new MySqlCommand(query, conn);
        command.Parameters.AddWithValue("@userName", user.userName);
        command.Parameters.AddWithValue("@password", user.password);
        command.Parameters.AddWithValue("@fullName", user.fullName);
        command.Parameters.AddWithValue("@phone", user.phone);
        command.Parameters.AddWithValue("@accountNumber",user.accountNumber);
        command.Parameters.AddWithValue("@balance", 0);
        command.Parameters.AddWithValue("@role", user.role.ToString());
        command.Parameters.AddWithValue("@createdAt", user.createdAt);
        command.Parameters.AddWithValue("@status",1);
        command.ExecuteNonQuery();
        conn.Close();
        Console.WriteLine("Sign Up Successfully");
    }

    public List<User> FindAll()
    {
        var users = new List<User>();
        using (var conn = new MySqlConnection(MySqlConnectionString))
        {
            try
            {
                conn.Open();
                var query = "SELECT * FROM users";
                using (var command = new MySqlCommand(query, conn))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var user = new User
                        {
                            id = reader.GetInt32("id"),
                            userName = reader["user_name"] != DBNull.Value ? reader.GetString("user_name") : string.Empty,
                            password = reader["password"] != DBNull.Value ? reader.GetString("password") : string.Empty,
                            fullName = reader["full_name"] != DBNull.Value ? reader.GetString("full_name") : string.Empty,
                            accountNumber = reader["account_number"] != DBNull.Value ? reader.GetString("account_number") : string.Empty,
                            phone = reader["phone"] != DBNull.Value ? reader.GetString("phone") : string.Empty,
                            balance = reader["balance"] != DBNull.Value ? reader.GetDouble("balance") : 0.0,
                            role = (User.UserType)Enum.Parse(typeof(User.UserType), reader.GetString("role")),
                            status = reader["status"] != DBNull.Value ? reader.GetInt32("status") : 0
                        };
                        users.Add(user);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
            conn.Close();
        }

        return users;

    }

   
    public User Login(string userName, string passWord)
    {
        var conn = new MySqlConnection(MySqlConnectionString);
        conn.Open();
        var query = "SELECT * FROM users WHERE user_name = @Username AND password = @Password";
        var command = new MySqlCommand(query, conn);
        command.Parameters.AddWithValue("@Username", userName);
        command.Parameters.AddWithValue("@Password", passWord);
        var reader = command.ExecuteReader();
    
        if (reader.Read())
        {
            if (reader.GetInt32("Status") == 0)
            {
                Console.WriteLine("Account LOCKED");
                conn.Close();
                return null;
            }

            var user = new User
            {
                id = reader.GetInt32("Id"),
                userName = reader.GetString("user_name"),
                password = reader.GetString("password"),
                fullName = reader.GetString("full_name"),
                phone = reader.GetString("phone"),
                accountNumber = reader.GetString("account_number"),
                balance = reader.GetDouble("balance"),
                role = (User.UserType)Enum.Parse(typeof(User.UserType), reader.GetString("role")),
                status = reader.GetInt32("status")
            };
            Console.WriteLine("Login Success");
            conn.Close();
            return user;
        }

        Console.WriteLine("Wrong UserName Or PassWord");
        conn.Close();
        return null;
    }

    public User ShowUserInfo(string info, string value)
    {
        User user = null;
        try
        {
            using (var conn = new MySqlConnection(MySqlConnectionString))
            {
                conn.Open();
                var query = $"SELECT id, user_name,password, full_name, account_number, phone, balance, status FROM users WHERE {info} = @value";
                using (var command = new MySqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@value", value);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            user = new User
                            {
                                id = reader.GetInt32("id"),
                                userName = reader.GetString("user_name"),
                                password = reader.GetString("password"),
                                fullName = reader.GetString("full_name"),
                                accountNumber = reader.GetString("account_number"),
                                phone = reader.GetString("phone"),
                                balance = reader.GetDouble("balance"),
                                status = reader.GetInt32("status")
                            };
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }

        return user;
    } // cac thong tin cua user
    


    public User findUserByFullName(string fullName)
    {
        return ShowUserInfo("full_name",fullName);
    }

    public User findUserByAccountNumber(string accountNumber)
    {
        return ShowUserInfo("account_number",accountNumber);

    }

    public User findUserByPhone(string phone)
    {
        return ShowUserInfo("phone",phone);

    }
    
    
    
    public void Deposit(User user, double amount)
    {
        user.balance += amount;
        
    }

    public void Withdraw()
    {
        throw new NotImplementedException();
    }

    public void Transfer()
    {
        throw new NotImplementedException();
    }

    public List<Transaction> Transactions()
    {
        throw new NotImplementedException();
    }
    
}