using System.IO.Pipelines;
using System.Net.WebSockets;
using System.Text.Json.Nodes;
using EmployerReg;

namespace EmployerRep;

public class EmployerRepository
{
    public List<Employer> employers = new List<Employer>();


    public void DataSave()
    {
        var json = System.Text.Json.JsonSerializer.Serialize(employers);

        File.WriteAllText("Funcionarios.txt", json);
    }

    public void GetData()
    {
        if (File.Exists("Funcionarios.txt"))
        {      
        var dados = File.ReadAllText("Funcionarios.txt");
        var arqEmployer = System.Text.Json.JsonSerializer.Deserialize<List<Employer>>(dados);
        employers.AddRange(arqEmployer);
        }
    }
    public void EmployerPrint(Employer employer)
    {
        Console.WriteLine("ID.............   " + employer.Id);
        Console.WriteLine("Nome...........   " + employer.Name);
        Console.WriteLine("Data Nascimento   " + employer.Birthday);
        Console.WriteLine("Data Admissão..   " + employer.Admission);
    }


    public void EmployerRegister()
    {
        Console.Clear();

        Console.Write("Nome do funcionário: ");
        var name = Console.ReadLine();
        Console.Write(Environment.NewLine);

        Console.Write("Data de Nascimento: ");
        var birthday = DateOnly.Parse(Console.ReadLine());
        Console.Write(Environment.NewLine);

        Console.Write("Data de Admissão: ");
        var admission = DateOnly.Parse(Console.ReadLine());
        Console.Write(Environment.NewLine);

        var employer = new Employer();

        employer.Id = employers.Count + 1;
        employer.Name = name;
        employer.Birthday = birthday;
        employer.Admission = admission;

        employers.Add(employer);
        EmployerPrint(employer);

        Console.Write(Environment.NewLine);
        Console.WriteLine("Funcionário cadastrado com sucesso! [Enter]");
    }

    public void EmployerEdit()
    {
        Console.Clear();

        Console.Write("Digite o ID do funcionário: ");
        var number = Console.ReadLine();
        var employer = employers.FirstOrDefault(y => y.Id == int.Parse(number));

        EmployerPrint(employer);

        Console.Write("Nome do funcionário: ");
        var name = Console.ReadLine();
        Console.Write(Environment.NewLine);

        Console.Write("Data de Nascimento: ");
        var birthday = DateOnly.Parse(Console.ReadLine());
        Console.Write(Environment.NewLine);

        Console.Write("Data de Admissão: ");
        var admission = DateOnly.Parse(Console.ReadLine());
        Console.Write(Environment.NewLine);

        employer.Name = name;
        employer.Birthday = birthday;
        employer.Admission = admission;

        EmployerPrint(employer);

        Console.WriteLine("Funcionário alterado com sucesso! [Enter]");
    }

    public void EmployerDelete()
    {
        Console.Clear();
        var number = Console.ReadLine();
        var employer = employers.FirstOrDefault(y => y.Id == int.Parse(number));
        EmployerPrint(employer);
        employers.Remove(employer);
        Console.WriteLine("Funcionário exluído com sucesso! [Enter]");
        

    }

    public void GetEmployer()
    {

        Console.Clear();
        Console.WriteLine("Funcionários cadastrados: ");
        Console.Write(Environment.NewLine);
        employers?.ForEach(y => EmployerPrint(y));
        Console.WriteLine("Menu [Enter]");
    }

}