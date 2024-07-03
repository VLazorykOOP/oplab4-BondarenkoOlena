using System;
using System.Data;
using MySql.Data.MySqlClient;

public class DatabaseHelper
{
    private string connectionString = "server=localhost;database=computersalesdb;user=root;password=Pa$$word;";

    public DataTable GetAllComputers()
    {
        using (MySqlConnection conn = new MySqlConnection(connectionString))
        {
            conn.Open();
            string query = "SELECT * FROM computers";
            MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            return dataTable;
        }
    }

    public void AddComputer(string name, string processorType, string clockSpeed, string ram, string hdd, string videoCard, string soundCard)
    {
        using (MySqlConnection conn = new MySqlConnection(connectionString))
        {
            conn.Open();
            string query = "INSERT INTO computers (Name, ProcessorType, ClockSpeed, RAM, HDD, VideoCard, SoundCard) VALUES (@name, @processorType, @clockSpeed, @ram, @hdd, @videoCard, @soundCard)";
            using (MySqlCommand cmd = new MySqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@processorType", processorType);
                cmd.Parameters.AddWithValue("@clockSpeed", clockSpeed);
                cmd.Parameters.AddWithValue("@ram", ram);
                cmd.Parameters.AddWithValue("@hdd", hdd);
                cmd.Parameters.AddWithValue("@videoCard", videoCard);
                cmd.Parameters.AddWithValue("@soundCard", soundCard);
                cmd.ExecuteNonQuery();
            }
        }
    }

    public void UpdateComputer(int id, string name, string processorType, string clockSpeed, string ram, string hdd, string videoCard, string soundCard)
    {
        using (MySqlConnection conn = new MySqlConnection(connectionString))
        {
            conn.Open();
            string query = "UPDATE computers SET Name=@name, ProcessorType=@processorType, ClockSpeed=@clockSpeed, RAM=@ram, HDD=@hdd, VideoCard=@videoCard, SoundCard=@soundCard WHERE Id=@id";
            using (MySqlCommand cmd = new MySqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@processorType", processorType);
                cmd.Parameters.AddWithValue("@clockSpeed", clockSpeed);
                cmd.Parameters.AddWithValue("@ram", ram);
                cmd.Parameters.AddWithValue("@hdd", hdd);
                cmd.Parameters.AddWithValue("@videoCard", videoCard);
                cmd.Parameters.AddWithValue("@soundCard", soundCard);
                cmd.ExecuteNonQuery();
            }
        }
    }

    public void DeleteComputer(int id)
    {
        using (MySqlConnection conn = new MySqlConnection(connectionString))
        {
            conn.Open();
            string query = "DELETE FROM computers WHERE Id=@id";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
        }
    }

    public DataTable SearchComputers(string searchQuery)
    {
        using (MySqlConnection conn = new MySqlConnection(connectionString))
        {
            conn.Open();
            string query = @"
            SELECT * FROM computers 
            WHERE Name LIKE @searchQuery 
            OR ProcessorType LIKE @searchQuery 
            OR ClockSpeed LIKE @searchQuery 
            OR RAM LIKE @searchQuery 
            OR HDD LIKE @searchQuery 
            OR VideoCard LIKE @searchQuery 
            OR SoundCard LIKE @searchQuery";
            MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
            adapter.SelectCommand.Parameters.AddWithValue("@searchQuery", "%" + searchQuery + "%");
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            return dataTable;
        }
    }
}
