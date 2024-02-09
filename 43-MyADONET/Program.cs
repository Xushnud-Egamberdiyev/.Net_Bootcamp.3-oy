using Npgsql;
using System.Net;

internal class Program
{
    private static void Main(string[] args)
    {
        string connectionString = "Host=localhost;Port=5432;Database=MongoDb;User Id=postgres;Password=xushnud;";

        NpgsqlConnection db_context = new NpgsqlConnection(connectionString);
        db_context.Open();

        string query = "create table skypedars(id serial, mavzu varchar(40), start_date date, student_count int)";

        NpgsqlCommand command = new NpgsqlCommand(query, db_context);

        command.ExecuteNonQuery();

        Console.WriteLine("db ulandi");


        db_context.Close();

    }
}