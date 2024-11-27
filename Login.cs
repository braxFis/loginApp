using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Npgsql;

namespace lorn_sql;

public class Login
{
    private string connectionString;

    private string uname { get; } = "nick";
    private string pw { get; } = "password";

    private string localhost = "localhost";

    private string user = "postgres";

    private string pass = "NewPass123";

    private string db = "individual_assignment_db";

    private string tbl = "users";
    
    //Summarized you basically validate input with two form fields...
    public Login()
    {
        connectionString = $"host={localhost};username={user};password={pass};database={db}";
        using var connection = new NpgsqlConnection(connectionString);
        connection.Open();
        var login = $@"select @username, @password from {tbl}";
        var cmd = new NpgsqlCommand(login, connection);
        cmd.Parameters.AddWithValue("username", uname);
        cmd.Parameters.AddWithValue("password", pw);
        var reader = cmd.ExecuteReader();
        if (reader.Read())
        {
            var username = reader.GetString(0);
            var password = reader.GetString(1);
            if (username == uname && password == pw)
            {
            //approve login
            Console.WriteLine("You have successfully authenticated.");
            //redirect to dashboard
            }
        }
    }
}