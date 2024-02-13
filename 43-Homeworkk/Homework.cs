using Npgsql;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Npgsql.Replication.PgOutput.Messages.RelationMessage;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace _43_Homeworkk
{
    public class Homework
    {
        public NpgsqlConnection connection { get; set; }
        public string query { get; set; }
        public NpgsqlCommand command { get; set; }
        public Homework()
        {
            const string connectionstring = "Server=127.0.0.1;Port=5432;Database=MongoDb;username=postgres;Password=xushnud;";

            connection = new NpgsqlConnection(connectionstring);
        }
        //1. Create Table qilish
        public void Create_table(string TableName, string column1, string column2, string column3)
        {
            Open();
            string query = $"Create table {TableName} ({column1}, {column2}, {column3})";
            command =new NpgsqlCommand(query, connection);
            command.ExecuteNonQuery();
            Close();

        }

        //2. Tablega insert qilish 1 ta danniy insert qilish
        public void One_Insert(string Table_name, string column_name, string column_name2, string column_info, int column_info2)
        {
            Open();
            string query = $"Insert into {Table_name}({column_name}, {column_name2}) values ('{column_info}', {column_info2})";
            command = new NpgsqlCommand(query, connection);
            command.ExecuteNonQuery();
        }

        //3. ko'pkina ma'lumotlarni insert qilish
        public void Insert(string Table_name, IList<Darslar_info> info)
        {
            Open();
            query = $"insert into {Table_name} (mavzu, student_count) values";
            for (int i = 0; i < info.Count; i++)
            {
                query += $@"('{info[i].mavzu}', {info[i].student_count}),";
            }
            query = query.Remove(query.Length - 1);
            command = new NpgsqlCommand(query, connection);
            command.ExecuteNonQuery();
            Close();

        }

        //4. GetAll qilib ma'lumotlarni ko'rvolish5
        public void GetAll(string table_name)
        {
            string connectionstring = "Server=127.0.0.1;Port=5432;Database=MongoDb;username=postgres;Password=xushnud;";

            using (var connection = new NpgsqlConnection(connectionstring))
            {
                string sql = $"Select * From {table_name}";
                NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(sql, connection);

                DataSet ds = new DataSet();
                adapter.Fill(ds, table_name);

                foreach (DataRow item in ds.Tables[$"{table_name}"].Rows)
                {
                    Console.WriteLine($"{item["mavzu"]}");
                }
            }
        }

        //5. GetById qilib qaysidur Id siga tengini topib kelish
        public void GetById(string table_name, int id)
        {
            Open();
            query = $"select * from {table_name}\nwhere id = {id}";
            command = new NpgsqlCommand (query , connection);
            command.ExecuteNonQuery();
            Close();
        }

        //6. Delete qilish.
        public void Delete(string tableName, int id)
        {
            Open();
            query = $"delete from {tableName} where id = {id}";
            command = new NpgsqlCommand(query, connection);
            if (command.ExecuteNonQuery() == 0)
            {
                Console.WriteLine("Bunday Id yo'q!");
            }
            Close();
        }

        //7.Update for id column.
        public void UpdateById(int id, string name, int age)
        {
            Open();
            query = $"update users set name = {name}, age = {age} where id = {id}";
            command = new NpgsqlCommand(query, connection);
            Console.WriteLine(command.ExecuteNonQuery());
            Close();
        }
        //8.Update for name column.
        public void UpdateByName(string target, string name, int age)
        {
            Open();
            query = $"update users set name = {name}, age = {age} where name = {target}";
            command = new NpgsqlCommand(query, connection);
            Console.WriteLine(command.ExecuteNonQuery());
            Close();
        }
        //9.Get qilish LIKE text(column) ichidan search qilib opkelish
        public void GetLike(string like)
        {
            Open();
            query = $"select * from users where name like '{like}'";
            command = new NpgsqlCommand(query, connection);
            var data = command.ExecuteReader();
            while (data.Read())
            {
                Console.WriteLine($"id = {data["id"]}\nname = {data["name"]}\nage = {data["age"]}\n");
            }
            Close();
        }
        //10.yangi column qo'shish
        public void AddColumn(string tableName, string columnNameWithType)
        {
            Open();
            query = $"alter table {tableName} add column {columnNameWithType}";
            command = new NpgsqlCommand(query, connection);
            Console.WriteLine(command.ExecuteNonQuery());
            Close();
        }
        //11.yangi colummni default qiymati bilan qo'shish
        public void AddColumnDefault(string tableName, string columnName, string type, string defaultValue)
        {
            Open();
            query = $"alter table {tableName} add column {columnName} {type} default {defaultValue}";
            command = new NpgsqlCommand(query, connection);
            Console.WriteLine(command.ExecuteNonQuery());
            Close();
        }
        //12.columnni nomini update qilish
        public void UpdateColumn(string tableName, string columnName, string newColumnName)
        {
            Open();
            query = $"alter table {tableName} rename column {columnName} to {newColumnName}";
            command = new NpgsqlCommand(query, connection);
            Console.WriteLine(command.ExecuteNonQuery());
            Close();
        }
        //13.Tableni nomini update qilish.
        public void UpdateTable(string tableName, string newTableName)
        {
            Open();
            query = $"alter table {tableName} rename to {newTableName}";
            command = new NpgsqlCommand(query, connection);
            Console.WriteLine(command.ExecuteNonQuery());
            Close();
        }
        //14.Yo'g' database bor silar shu yangitdan yaratishilar kerak va uni ichiga 3 dona table yaratamiz.
        public void CreateDatabase(string databaseName, params string[] tableNames)
        {
            Open();
            query = $"create database if not exists {databaseName}\nuse {databaseName}\ncreate table if not exists ";
            foreach (var item in tableNames)
            {
                query += $"{item} (id serial primary key, name varchar(50), age int),";
            }
            command = new NpgsqlCommand(query, connection);
            Console.WriteLine(command.ExecuteNonQuery());
            Close();
        }
        //15.Truncate qilish.
        public void Truncate(string tableName)
        {
            Open();
            query = $"truncate {tableName}";
            command = new NpgsqlCommand(query, connection);
            Console.WriteLine(command.ExecuteNonQuery());
            Close();
        }
        //16.Join qilib ko'rish. 2 ta tableni join qilib ko'rish.
        public void Join(string tableName, string secondTableName, string column1, string column2)
        {
            Open();
            query = $"select * from {tableName} join {secondTableName} on {tableName}.{column1} = {secondTableName}.{column2}";
            command = new NpgsqlCommand(query, connection);
            var data = command.ExecuteReader();
            while (data.Read())
            {
                Console.WriteLine($"id = {data["id"]}\nname = {data["name"]}\nage = {data["age"]}\n");
            }
            Close();
        }
        //17.Index qo'shamiz.
        public void Index(string tableName, params string[] columns)
        {
            Open();
            query = $"create index on {tableName} (";
            foreach (var item in columns)
            {
                query += $"{item},";
            }
            query += query.Remove(query.Length - 1) + ")";
            command = new NpgsqlCommand(query, connection);
            Console.WriteLine(command.ExecuteNonQuery());
            Close();
        }


        private void Open()
        {
            connection.Open();
        }
        // Close database
        public void Close()
        {
            Console.Write("Database'ga muvaffaqiyatli ulandi.\n\n");
            connection.Close();
        }
    }
}
