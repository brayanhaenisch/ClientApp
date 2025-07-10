using System.ComponentModel.Design;
using ClientRep;
using EmployerRep;
using ProdRep;
using StockReg;

namespace AppCliente;

class Program
{
    static ClientRepository _clientrepository = new ClientRepository();
    static EmployerRepository _employerrepository = new EmployerRepository();
    static ProductRepository _productrepository = new ProductRepository();
    static StockRepository _stockrepository = new StockRepository();

    static void Main(string[] args)
    {

        _clientrepository.GetData();
        _employerrepository.GetData();
        _productrepository.GetData();
        _stockrepository.GetData();

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
        Console.WriteLine("4 - Estoque");
        Console.WriteLine("5 - Sair");
        var option = Console.ReadLine();
        switch (int.Parse(option))
        {
            case 1:
                {
                    MenuProduct();
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
                    MenuStock();
                    break;
                }
            case 5:
                {
                    _clientrepository.DataSave();
                    _employerrepository.DataSave();
                    _productrepository.DataSave();
                    _stockrepository.DataSave();
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


    static public void MenuProduct()
    {
        Console.Clear();
        Console.WriteLine("-------------------");
        Console.WriteLine("Cadastro de produtos");
        Console.WriteLine("Escolha uma das seguintes opções:");
        Console.WriteLine("-------------------");
        Console.WriteLine("1 - Cadastrar Produto");
        Console.WriteLine("2 - Exibir Produtos");
        Console.WriteLine("3 - Editar Produto");
        Console.WriteLine("4 - Excluir Produto");
        Console.WriteLine("5 - Voltar ao Menu Principal");

        var option = Console.ReadLine();

        switch (int.Parse(option))
        {
            case 1:
                {
                    _productrepository.ProductRegister();
                    Console.ReadKey();
                    MenuProduct();
                    break;
                }
            case 2:
                {
                    _productrepository.GetProduct();
                    Console.ReadKey();
                    MenuProduct();
                    break;
                }
            case 3:
                {
                    _productrepository.ProductEdit();
                    Console.ReadKey();
                    MenuProduct();
                    break;
                }
            case 4:
                {
                    _productrepository.ProductDelete();
                    Console.ReadKey();             
                    MenuProduct();
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


static public void MenuStock()
    {
        Console.Clear();
        Console.WriteLine("-------------------");
        Console.WriteLine("Estoque");
        Console.WriteLine("Escolha uma das seguintes opções:");
        Console.WriteLine("-------------------");
        Console.WriteLine("1 - Adicionar Estoque");
        Console.WriteLine("2 - Exibir Estoque");
        Console.WriteLine("3 - Editar Estoque");
        Console.WriteLine("5 - Voltar ao Menu Principal");

        var option = Console.ReadLine();

        switch (int.Parse(option))
        {
            case 1:
                {
                    _stockrepository.StockAdd();
                    Console.ReadKey();
                    MenuStock();
                    break;
                }
            case 2:
                {
                    _stockrepository.GetStock();
                    Console.ReadKey();
                    MenuStock();
                    break;
                }
            case 3:
                {
                    _stockrepository.StockEdit();
                    Console.ReadKey();
                    MenuStock();
                    break;
                }
            case 4:
                {
                    _productrepository.ProductDelete();
                    Console.ReadKey();             
                    MenuStock();
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
                    Console.ReadKey();
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