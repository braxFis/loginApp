namespace Login.Models;
using Npgsql;

public class Register2
{
    private string connectionString;

    public string username { get; set; } = "";
    public string password { get; set; } = "";
    public string email { get; set; } = "";
    
    private string localhost = "localhost";

    private string user = "postgres";

    private string pass = "NewPass123";

    private string db = "individual_assignment_db";

    private string tbl = "users";
    
    //Summarized you basically validate input with two form fields...
    public Register2()
    {
        connectionString = $"host={localhost};username={user};password={pass};database={db}";
        using var connection = new NpgsqlConnection(connectionString);
        connection.Open();
        var register = $@"insert into {tbl}(username, email, password) values(@username, @email, @password)";
        var cmd = new NpgsqlCommand(register, connection);
        cmd.Parameters.AddWithValue("username", username);
        cmd.Parameters.AddWithValue("email", email);
        cmd.Parameters.AddWithValue("password", password);
        cmd.ExecuteNonQuery();
    }    
}