using TrabalhoCRUD_MVC.Models;
using System.Data.SqlClient;
using TrabalhoCRUD_MVC.SQLClient;

namespace TrabalhoCRUD_MVC.DAl;

public class ClientDAL:ICRUD_DAL
{
    private SqlConnection sqlConnection;
    private SqlCommand sqlCommand;

    public bool Create(Cliente cliente)
    {
        sqlConnection = Data.conectarBancodados();
        string command = $"INSERT INTO [Cliente] (Nome,Email,Senha) VALUES ('{cliente.Nome}','{cliente.Email}','{cliente.Senha}')";
        sqlCommand = new SqlCommand(command, sqlConnection);
        var lines = sqlCommand.ExecuteNonQuery();
        Data.FecharConexaoBD();
        sqlCommand.Dispose();
        if(lines > 0) return true;
        return false;
    }

    public bool Delete(int id)
    {
        sqlConnection = Data.conectarBancodados();
        string command = $"DELETE FROM [Cliente] WHERE [Id] = {id}";
        sqlCommand = new SqlCommand(command, sqlConnection);
        var lines = sqlCommand.ExecuteNonQuery();
        Data.FecharConexaoBD();
        sqlCommand.Dispose();
        if (lines > 0) return true;
        return false;

    }

    public List<Cliente>? Read()
    {
        sqlConnection = Data.conectarBancodados();
        string command = $"SELECT * FROM [Cliente]";
        Cliente client;
        List<Cliente> clientList = new List<Cliente>();
        sqlCommand = new SqlCommand(command, sqlConnection);
       
        using(var  reader = sqlCommand.ExecuteReader())
        {
            while (reader.Read())
            {
                client = new Cliente()
                {
                    IdCliente = reader.GetInt32(0),
                    Nome = reader.GetString(1),
                    Email = reader.GetString(2),
                    Senha = reader.GetString(3)
                };
                clientList.Add(client);
            }
        }
        Data.FecharConexaoBD();
        sqlCommand.Dispose();

        if (clientList.Count > 0) return clientList;
        return null;

    }

    public Cliente ReadByID(int id)
    {
        sqlConnection = Data.conectarBancodados();
        string command = $"SELECT * FROM [Cliente] WHERE Id = {id}";
        Cliente client = null;
        sqlCommand = new SqlCommand(command, sqlConnection);

        using (var reader = sqlCommand.ExecuteReader())
        {
            while (reader.Read())
            {
                client = new Cliente()
                {
                    IdCliente = reader.GetInt32(0),
                    Nome = reader.GetString(1),
                    Email = reader.GetString(2),
                    Senha = reader.GetString(3)
                };
            }
        }
        Data.FecharConexaoBD();
        sqlCommand.Dispose();

        if (client != null) return client;
        return null;
    }

    public bool Update(Cliente cliente)
    {
        sqlConnection = Data.conectarBancodados();
        bool queryResult = false;
        string commandSql = $"UPDATE [Cliente] " +
                            $"SET [Nome] = '{cliente.Nome}', [Senha] = '{cliente.Senha}', [Email] = '{cliente.Email}' " +
                            $"WHERE [Id] = {cliente.IdCliente}";


        using(var sqlCommand = new SqlCommand(commandSql, sqlConnection))
        {
            queryResult = sqlCommand.ExecuteNonQuery() > 0;
        }
        return queryResult;
    }
}
