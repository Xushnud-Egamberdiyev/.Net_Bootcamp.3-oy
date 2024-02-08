using Npgsql;
class Program
{
    static void Main()
    {
        GetByName(Console.ReadLine());

        Main();
    }


    public static void GetAll()
    {
        string connectionString = "Host=localhost;Port=5432;Database=MonDb;User Id=postgres;Password=xushnud;";

        using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
        {
            connection.Open();

            string query = "select * from TestTable1;";
            using NpgsqlCommand cmd = new NpgsqlCommand(query, connection);

            var result = cmd.ExecuteReader();

            while (result.Read())
            {
                Console.WriteLine(result[0]);
            }
        }
    }

    public static void GetByName(string name)
    {
        string connectionString = "Host=localhost;Port=5432;Database=MongoDb;User Id=postgres;Password=xushnud;";

        using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
        {
            connection.Open();

            string query = $"select * from TestTable1 where Name = '{name}';";
            using NpgsqlCommand cmd = new NpgsqlCommand(query, connection);

            var result = cmd.ExecuteReader();

            while (result.Read())
            {
                Console.WriteLine(result[0]);
            }
        }
    }

    public static void Insert(string name)
    {
        string connectionString = "Host=localhost;Port=5432;Database=MongoDb;User Id=postgres;Password=xushnud;";


        using NpgsqlConnection connection = new NpgsqlConnection(connectionString);
        connection.Open();

        string query = $"insert into Testtable1(Name) values('{name}');insert into Testtable1(Name) values('{name}');";
        using NpgsqlCommand cmd = new NpgsqlCommand(query, connection);

        var countRow = cmd.ExecuteNonQuery();

        Console.WriteLine(countRow + " qator qo'shildi");
    }

    public static void Delete(string name)
    {
        string connectionString = "Host=localhost;Port=5432;Database=MongoDb;User Id=postgres;Password=xushnud;";


        using NpgsqlConnection connection = new NpgsqlConnection(connectionString);
        connection.Open();

        string query = $"delete from TestTable1 where Name='{name}'";
        using NpgsqlCommand cmd = new NpgsqlCommand(query, connection);

        var rowCount = cmd.ExecuteNonQuery();

        Console.WriteLine(rowCount + "Shuncha row muvaffaqiyatli o'chirildi");
    }
    public static void Update()
    {
        Console.WriteLine("Qaysi id ozgarrtirmoqchisz");
        string id = Console.ReadLine();

        Console.WriteLine("Qaysi columinini");
        string column = Console.ReadLine();

        Console.WriteLine("Ozgarishni kiriti");
        string newvalue = Console.ReadLine();

        string connectionString = "User ID=postgres;Password=xushnud;Host=localhost;Port=5432;Database=ApiHome;IncludeErrorDetail = true;";


        using NpgsqlConnection connection = new NpgsqlConnection(connectionString);
        connection.Open();

        string query = $"UPDATE inventory SET {column} = '{newvalue}' WHERE id = '{id}'";

        using NpgsqlCommand cmd = new NpgsqlCommand(query, connection);

        var rowCount = cmd.ExecuteNonQuery();
        Console.WriteLine("Shuncha row muvaffaqiyatli o'chirildi");

        GetAll();
    }
}
