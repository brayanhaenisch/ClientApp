using System.Data.Common;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using CliReg;

namespace ClientRep;

public class ClientRepository
{
    public List<Client> clients = new List<Client>();
    public void ClientPrint(Client client)
    {
        Console.WriteLine("ID.............   " + client.Id);
        Console.WriteLine("Nome...........   " + client.Name);
        Console.WriteLine("Desconto.......   " + client.Discount);
        Console.WriteLine("Data Nascimento   " + client.Birthday);
        Console.WriteLine("Data Cadastro..   " + client.RegistrationDate);
    }

    public void DataSave()
    {
        var json = System.Text.Json.JsonSerializer.Serialize(clients);

        File.WriteAllText("Client.txt", json);
    }

    public void GetData()
    {
        if (File.Exists("Client.txt"))
        {
        var dados = File.ReadAllText("Client.txt");
        var arqClient = System.Text.Json.JsonSerializer.Deserialize<List<Client>>(dados);

        clients.AddRange(arqClient);
        }

    }
    public void ClientRegister()
    {
        Console.Clear();

        Console.Write("Nome do cliente: ");
        var name = Console.ReadLine();
        Console.Write(Environment.NewLine);

        Console.Write("Desconto do cliente: ");
        var discount = decimal.Parse(Console.ReadLine());
        Console.Write(Environment.NewLine);

        Console.Write("Data de nascimento: ");
        var datebirth = DateOnly.Parse(Console.ReadLine());
        Console.Write(Environment.NewLine);

        var client = new Client();
        client.Id = clients.Count + 1;
        client.Name = name;
        client.Discount = discount;
        client.Birthday = datebirth;
        client.RegistrationDate = DateTime.Now;

        clients.Add(client);
        ClientPrint(client);
        Console.Write(Environment.NewLine);
        Console.WriteLine("Cliente cadastrado com sucesso! [Enter]");
    }

    public void ClientEdit()
    {

        Console.Write("Digite o ID do cliente: ");
        var number = Console.ReadLine();
        var client = clients.First(y => y.Id == int.Parse(number));

        ClientPrint(client);

        Console.Write("Mostrei o client");


        Console.Write("Nome do cliente: ");
        var name = Console.ReadLine();
        Console.Write(Environment.NewLine);

        Console.Write("Desconto do cliente: ");
        var discount = decimal.Parse(Console.ReadLine());
        Console.Write(Environment.NewLine);

        Console.Write("Data de nascimento: ");
        var datebirth = DateOnly.Parse(Console.ReadLine());
        Console.Write(Environment.NewLine);

        client.Name = name;
        client.Discount = discount;
        client.Birthday = datebirth;
        client.RegistrationDate = DateTime.Now;

        Console.WriteLine("Cliente alterado com sucesso! [Enter]");
        ClientPrint(client);
    }
    public void ClientDelete()
    {
        Console.Clear();
        Console.Write("Digite o ID do cliente: ");
        var number = Console.ReadLine();
        var client = clients.FirstOrDefault(y => y.Id == int.Parse(number));
        ClientPrint(client);
        clients.Remove(client);
        Console.WriteLine("-----------------");
        Console.WriteLine("Cliente excluído! [Enter]");
    }
    public void GetClients()
    {
        Console.Clear();
        Console.WriteLine("Clientes cadastrados: ");
        Console.Write(Environment.NewLine);
        foreach (var c in clients)
        {
            ClientPrint(c);
            Console.Write(Environment.NewLine);
        }
        Console.WriteLine("Menu [Enter]");
    }
}
