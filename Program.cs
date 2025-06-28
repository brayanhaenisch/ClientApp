using System.ComponentModel.Design;
using ClientRep;
using EmployerRep;

namespace AppCliente;

class Program
{
    static ClientRepository _clientrepository = new ClientRepository();
    static EmployerRepository _employerrepository = new EmployerRepository();

    static void Main(string[] args)
    {

        _clientrepository.GetData();
        _employerrepository.GetData();

        while (true)
        {
            Menu();
            Console.ReadKey();
        }
    }


    static void Menu()
    {
        Console.Clear();
        Console.WriteLine("-------------------");
        Console.WriteLine("Brayan ERP");
        Console.WriteLine("Escolha uma das seguintes opções:");
        Console.WriteLine("-------------------");
        Console.WriteLine("1 - Produtos");
        Console.WriteLine("2 - Funcionários");
        Console.WriteLine("3 - Clientes");
        Console.WriteLine("4 - Vendas");
        Console.WriteLine("5 - Sair");
        var option = Console.ReadLine();
        switch (int.Parse(option))
        {
            case 1:
                {
                    Console.Clear();
                    Console.WriteLine("Esta função ainda não está disponível! [Enter]");
                    break;
                }
            case 2:
                {
                    MenuEmployer();
                    break;
                }
            case 3:
                {
                    MenuClient();
                    break;
                }
            case 4:
                {
                    Console.Clear();
                    Console.WriteLine("Esta função ainda não está disponível! [Enter]");
                    break;
                }
            case 5:
                {
                    _clientrepository.DataSave();
                    _employerrepository.DataSave();
                    Console.Clear();
                    Console.WriteLine("Sistema finalizado");
                    Environment.Exit(0);
                    break;
                }
            default:
                {
                    Console.Clear();
                    Console.WriteLine("Opção inválida! Tente novamente. [Enter]");
                    break;
                }
        }

    }

    static public void MenuClient()
    {
        Console.Clear();
        Console.WriteLine("-------------------");
        Console.WriteLine("Cadastro de clientes");
        Console.WriteLine("Escolha uma das seguintes opções:");
        Console.WriteLine("-------------------");
        Console.WriteLine("1 - Cadastrar Clientes");
        Console.WriteLine("2 - Exibir Clientes");
        Console.WriteLine("3 - Editar Cliente");
        Console.WriteLine("4 - Excluir Cliente");
        Console.WriteLine("5 - Voltar ao Menu Principal");

        var option = Console.ReadLine();

        switch (int.Parse(option))
        {
            case 1:
                {
                    _clientrepository.ClientRegister();
                    Console.ReadKey();
                    MenuClient();
                    break;
                }
            case 2:
                {
                    _clientrepository.GetClients();
                    MenuClient();
                    break;
                }
            case 3:
                {
                    _clientrepository.ClientEdit();
                    Console.ReadKey();
                    MenuClient();
                    break;
                }
            case 4:
                {
                    _clientrepository.ClientDelete();
                    Console.ReadKey();             
                    MenuClient();
                    break;
                }
            case 5:
                {
                    Console.Clear();
                    Menu();
                    break;

                }
            default:
                {
                    Console.WriteLine("Opção inválida! Tente novamente. [Enter]");
                    break;
                }
        }
    }

    static public void MenuEmployer()
        {
            Console.Clear();
            Console.WriteLine("-------------------");
            Console.WriteLine("Cadastro de Funcionários");
            Console.WriteLine("Escolha uma das seguintes opções:");
            Console.WriteLine("-------------------");
            Console.WriteLine("1 - Cadastrar Funcionário");
            Console.WriteLine("2 - Exibir Funcionários");
            Console.WriteLine("3 - Editar Funcionário");
            Console.WriteLine("4 - Excluir Funcionário");
            Console.WriteLine("5 - Voltar ao Menu Principal");

            var option = Console.ReadLine();

            switch (int.Parse(option))
            {
                case 1:
                    {
                        _employerrepository.EmployerRegister();
                        Console.ReadKey();
                        MenuEmployer();
                        break;
                    }
                case 2:
                    {
                        _employerrepository.GetEmployer();
                        Console.ReadKey();
                        MenuEmployer();
                        break;
                    }
                case 3:
                    {
                        _employerrepository.EmployerEdit();
                        Console.ReadKey();
                        MenuEmployer();
                        break;
                    }
                case 4:
                    {
                        _employerrepository.EmployerDelete();
                        Console.ReadKey();
                        MenuEmployer();
                        break;
                    }
                case 5:
                    {
                        Console.Clear();
                        Menu();
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Opção inválida! Tente novamente. [Enter]");
                        break;
                    }
            }
        }

}